using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public MenuLogic menuLogic;

    public void GameOver()
    {
        Time.timeScale = 0f; // pauzujemy gre
        menuLogic.GameOverScreen();
    }

    public void Restart(bool s)
    {
        if (!s)
        {
            SceneManager.LoadScene(0);
        }

        if (s)
        {
            Debug.Log("xdd s");
           // menuLogic.StartGame(); // gdy true od razu rozpozczynamy nowa gre
           // reset flappiego -> gdy scene load to nie dziala fast reset -> wraca nas do menu glownego // do poprawy 
        }
    }

}
