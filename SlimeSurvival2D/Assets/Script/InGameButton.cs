using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButton : MonoBehaviour
{

    public void BackToGame()
    {
        GameManager.instance.isPause = false;
    }

    public void QuitToTitle()
    {
        GameManager.instance.isPause = false;
        SceneManager.LoadScene("StartScene");
    }    
}
