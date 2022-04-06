using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject ranking;

    public GameManager gameManager;

    public void Start()
    {
        mainMenu = GameObject.Find("Main_menu");
        ranking = GameObject.Find("Ranking_menu");
       
        ranking.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void goToRanking()
    {
        mainMenu.gameObject.SetActive(false);
        ranking.gameObject.SetActive(true);

        // wczytaj liste 5 naj rekordow, wyswietl je
    }

    public void goBackToMenu()
    {
        ranking.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
