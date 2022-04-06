using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public DeathMenuLogic deathLogic;

    public void GameOver()
    {
        Time.timeScale = 0f; // pauzujemy gre
        deathLogic.GameOverScreen();
    }

    public void Restart(bool restart)
    {
        if (restart)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);

        }
    }

}
