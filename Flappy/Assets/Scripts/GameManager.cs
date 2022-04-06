using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public DeathMenuLogic deathLogic;

    private void Start()
    {
        Records.LoadFromFile(); // gdy zaczynamy gre to ladujemy plik z zapisami
    }

    public void GameOver(int score)
    {
        Time.timeScale = 0f; // pauzujemy gre
        deathLogic.GameOverScreen(score);
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
