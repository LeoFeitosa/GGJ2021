using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    PlayerAnimator _playerAnimator;
    SpriteRenderer _spriteRenderer;
    SoundController _soundController;
    CollectPieces _collectpieces;

    //forca do pulo
    [SerializeField]
    float jumpForce = 400;

    //direcao do layer
    public bool isLookLeft;

    //layer que identifica o chao
    [SerializeField]
    LayerMask layerGround;

    //objeto que fica em baixo do player, usado para posicionar a colisao com o chao
    [SerializeField]
    Transform groundCheck;

    //tamanho do circulo usado para verificar a colisao com o chao
    [SerializeField]
    float groundCheckRadius = 0.02f;

    //true = enconstando no chao, false = nao encosta no chao
    [SerializeField]
    bool isGround;

    //true = botao de pulo precionado
    [SerializeField]
    bool isJump;

    //cor quando toma dano
    [SerializeField]
    Color hitColor;

    //cor padrao
    [SerializeField]
    Color defaultColor;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        _collectpieces = FindObjectOfType(typeof(CollectPieces)) as CollectPieces;
    }

    // Update is called once per frame
    void Update()
    {
        //chama aofuncao de pulo caso a tecla espaco for precionada e o player estiver tocando o chao
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isJump = true;
        }

        RunAnimations();
    }

    private void FixedUpdate()
    {
        CheckGround();
        Jump();
    }

    void Jump()
    {
        if (isJump)
        {
            _soundController.EffectSound("Jump");

            //zera a velocidade antes de aplicar a forca do pulo, isso mantem os pulos sempre da mesma altura
            _rigidbody2D.velocity = Vector2.zero;

            // aplica forca em Y
            _rigidbody2D.AddForce(Vector2.up * jumpForce);

            isJump = false;
        }

        //se soltar o botao de pulo a velocidade Y é subtraida
        if (_rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidbody2D.velocity += Vector2.up * -0.8f;
        }
    }

    void CheckGround()
    {
        //gera um circulo com posicao e tamanhao e que colide somente na layer informada
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerGround);
    }

    void RunAnimations()
    {
        // envia os parametros para as funcoes que vao acionar as animacoes
        _playerAnimator.SetGrounded(isGround);
        _playerAnimator.SetSpeedY(_rigidbody2D.velocity.y);
    }

    public void Flip()
    {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
    }

    public void Damage()
    {
        _soundController.EffectSound("Damage");
        StartCoroutine(DamageController());
        _collectpieces.PieceScore(2);
    }

    IEnumerator DamageController()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");

        _spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(0.3f);
        _spriteRenderer.color = defaultColor;

        for (int i = 0; i <= 5; i++)
        {
            _spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            _spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }

        this.gameObject.layer = LayerMask.NameToLayer("Player");
        _spriteRenderer.color = Color.white;
    }
}
