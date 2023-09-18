using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] public GameObject RulesObject;
    [SerializeField] public GameObject MainMenuObeject;

    public void Play() 
    {
        SceneManager.LoadScene(gameScene);
    }

    public void EnterRules()
    {
        MainMenuObeject.SetActive(false);
        RulesObject.SetActive(true);
    }

    public void CloseRules()
    {
        MainMenuObeject.SetActive(true);
        RulesObject.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
