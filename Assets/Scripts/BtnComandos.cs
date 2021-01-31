using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnComandos : MonoBehaviour
{    
    public void IrParaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

}
