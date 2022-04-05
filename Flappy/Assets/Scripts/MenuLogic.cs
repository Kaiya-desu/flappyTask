using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    private GameObject mainMenu;
    private GameObject ranking;
    private GameObject deathScreen;

    // mozna rozdzielic na sceny, ale nie chce by pomiedzy przejsciami bylo ladowanie nowej sceny -> gra jest mała wiec nie wymaga loadingów,
    // od przycisku start powinna od razu "plynnie" przejsc do rozgrywki

    public void Start()
    {
        Time.timeScale = 0f; // na start gra jest w trybie pauzy

        mainMenu = GameObject.Find("Main_menu");
        ranking = GameObject.Find("Ranking_menu");
        deathScreen = GameObject.Find("Death_screen");

        ranking.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
    public void goToRanking()
    {
        mainMenu.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(false);
        ranking.gameObject.SetActive(true);
    }

    public void goBackToMenu()
    {
        ranking.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        ranking.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);

        Time.timeScale = 1f; // rozpoczynamy gre
    }

    public void RestartGame()
    {
        ranking.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);

       // Time.timeScale = 1f; // rozpoczynamy gre
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
