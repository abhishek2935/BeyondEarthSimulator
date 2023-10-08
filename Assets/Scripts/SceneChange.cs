using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    Planets planet;
    public void changeScene()
    {
        SceneManager.LoadScene("ImaginExo");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GoToEncy()
    {
        SceneManager.LoadScene("EncycloPedia");
    }

}