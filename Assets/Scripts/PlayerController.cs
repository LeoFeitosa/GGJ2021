using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    PlayerAnimator _playerAnimator;

    //forca do pulo
    [SerializeField]
    float jumpForce = 400;

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

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        //chama aofuncao de pulo caso a tecla espaco for precionada e o player estiver tocando o chao
        if (Input.GetButtonDown("Jump") && isGround)
        {
            Jump();
        }

        RunAnimations();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Jump()
    {
        //zera a velocidade antes de aplicar a forca do pulo, isso mantem os pulos sempre da mesma altura
        _rigidbody2D.velocity = Vector2.zero;

        // aplica forca em Y
        _rigidbody2D.AddForce(Vector2.up * jumpForce);
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
}
