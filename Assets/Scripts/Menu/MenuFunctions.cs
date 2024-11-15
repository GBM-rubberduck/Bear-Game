using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour
{
    //Variable Setup   
    public Button StartButton, QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartButtonClicked); //if StartButton is clicked run the StartButtonClicked Function
        QuitButton.onClick.AddListener(QuitButtonClicked); //if QuitButton is clicked run the QuitButtonClicked Function
    }

    void StartButtonClicked()
    {
        SceneManager.LoadScene("GameplayScreen");
        print("Start pressed"); //Display to console
    }
    void QuitButtonClicked()
    {
        Application.Quit();
        print("Quit pressed"); //Display to console
    }
}
