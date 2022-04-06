using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyLogic : MonoBehaviour
{

    private Rigidbody2D _rb;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float velocity;

    private int score;
    [SerializeField] private GameObject scoreCounter;

    private int bombs;
    [SerializeField] private GameObject bombCounter;

    private float lastClickTime;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1f; // unpauze gra gdy robimy restart
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        // w celu testowania gry w unity -> na koncu zmiana sterowania na dotyk telefonu Input.GetTouch
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.up * velocity;

            // gdy dwa razy szybko tap -> Bomb()
            if (Time.time - lastClickTime <= 0.2f)
            {
                Debug.Log("DOUBLE CLICK!");
                if (bombs > 0)
                {
                    Bomb();
                    bombs--;
                    bombCounter.GetComponent<UnityEngine.UI.Text>().text = bombs.ToString();
                }
            }
            lastClickTime = Time.time;
        }

    }

    void Bomb()
    {
        Debug.Log("BOOOM!");
        // bomb logic
        // destory all pipes spawned 
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe")) 
        {
            Destroy(pipe);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreCounter.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        if (score % 10 == 0) // CO 10 RUR GRACZ OTRZYMUJE BOMBE -> 10 RUR = 10 PKT 
        {
            if (bombs < 3) // bo mozemy miec max 3 bomby
            {
                Debug.Log("NOWA BOMBA!");
                bombs++;
                bombCounter.GetComponent<UnityEngine.UI.Text>().text = bombs.ToString();
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver(score);
    }

}
