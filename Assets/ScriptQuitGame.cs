using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptQuitGame : MonoBehaviour
{
    public Button btnRestart;
    public Button btnQuit;
    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = btnRestart.GetComponent<Button>();
        btn1.onClick.AddListener(btnRestartClick);
        Button btn2 = btnQuit.GetComponent<Button>();
        btn2.onClick.AddListener(btnQuitClick);


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void btnQuitClick()
    {
        print("app quit");
        Application.Quit();
    }

    private void btnRestartClick()
    {
        print("switch scene");

        SceneManager.LoadScene("MainScene");  // Replace with your scene name

    }

   
    // Update is called once per frame
    void Update()
    {

    }
}
