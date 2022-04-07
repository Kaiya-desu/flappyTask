using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private DeathMenuLogic deathLogic; // tylko na scenie Game

    private void Start()
    {
        Records.LoadFromFile(); // gdy zaczynamy gre to ladujemy plik z zapisami
        StartCoroutine(SpeedUp()); 
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


    public static float speed = 2.5f;
    public static float maxTime = 1.8f;

    // aby gra byla coraz trudniejsza, co 15 sekund lekko przyspieszam rozgrywke
    IEnumerator SpeedUp()
    {
        // aby gra nie przyspieszala w nieskonczonosc
        while (maxTime >= 1.0f)
        {
            yield return new WaitForSeconds(15);
            speed += 0.5f;
            foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe"))
            {
                pipe.GetComponent<PipesMovement>().speed = speed;
            }
            maxTime -= 0.1f;
        }
        StopCoroutine(SpeedUp()); 
        
    }
}
