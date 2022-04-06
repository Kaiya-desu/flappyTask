using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuLogic : MonoBehaviour
{
    private GameObject deathScreen;

    public GameManager gameManager;

    void Start()
    {
        deathScreen = GameObject.Find("Death_screen");
        deathScreen.gameObject.SetActive(false);
    }

    public void GameOverScreen()
    {
        deathScreen.gameObject.SetActive(true);

        // -> sprawdz czy jest w top 5, jak tak podaj info na ten temat
    }

    public void RestartGame()
    {

        // restart flappiego
        gameManager.Restart(true);
    }

    public void goBackToMenu()
    {
        gameManager.Restart(false); // wracamy na scene 0 -> main menu
    }

}
