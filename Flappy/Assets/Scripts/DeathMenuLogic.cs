using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuLogic : MonoBehaviour
{
    private GameObject deathScreen;
    [SerializeField] private GameObject scoreCounter;
    [SerializeField] private GameObject finalInfo;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        deathScreen = GameObject.Find("Death_screen");
        deathScreen.gameObject.SetActive(false);
    }

    public void GameOverScreen(int score)
    {
        deathScreen.gameObject.SetActive(true);

        scoreCounter.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        // -> sprawdz czy jest w top 5, jak tak podaj info na ten temat
        if (Records.checkTop(score))
        {
            finalInfo.GetComponent<UnityEngine.UI.Text>().text = "ADDED TO RANKING!"; // GDY JESTESMY W TOP 5
        }
        else
        {
            finalInfo.GetComponent<UnityEngine.UI.Text>().text = "TRY AGAIN!"; // GDY NIE JESTESMY W TOP 5
        }

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
