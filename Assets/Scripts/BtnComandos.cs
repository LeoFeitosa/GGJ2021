using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnComandos : MonoBehaviour
{   
    public GameObject painel1, painel2;
    SoundController _soundController;

    void Start()
    {
        _soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        _soundController.SceneMusic("Menu");
        _soundController.ChangeVolumeMusic(0.6f);
    }

    //Método que vai para a outra cena 
    public void IrParaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    //Método que fecha o jogo (Só funciona em PC e Mobile)
    public void Sair()
    {
        Application.Quit();
    }

    public void Creditos(bool onOff)
    {
        painel1.SetActive(!onOff);
        painel2.SetActive(onOff);
    }

}
