using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextSceneScr : MonoBehaviour
{
    public TMP_InputField inputField;

    private void Update()
    { if (Input.GetKeyUp(KeyCode.Return))
        { 
            CheckInput(); 
        } 
    }

    public void CheckInput()
    {
        string userInput = inputField.text;
        string expectedValue = "/create";

        if (userInput == expectedValue)
        {
            Debug.Log("Yes");
            SceneManager.LoadScene("PlanetGenScene");
        }
        else
        {
            Debug.Log("No");

        }
    }

}
