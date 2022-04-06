using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyLogic : MonoBehaviour
{

    private Rigidbody2D _rb;
    public GameManager gameManager;

    [SerializeField] private float velocity;

    private int score;
    public GameObject scoreCounter;

    private int bombs;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1f; // na start gra jest w trybie pauzy
    }

    void Update()
    {
        Jump();
        scoreCounter.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

    void Jump()
    {
        // w celu testowania gry w unity -> na koncu zmiana sterowania na dotyk telefonu Input.GetTouch
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.up * velocity;
            
            // gry rozpocznynamy gre musimy kliknac na ekran aby rozpoczac rozgrywke
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            }
        }

        // gdy dwa razy szybko tap -> Bomb()
    }

    void Bomb()
    {
        Debug.Log("BOOOM!");
        // space for bomb logic

        // destory all pipes spawned 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;

        if (score % 10 == 0) // CO 10 RUR GRACZ OTRZYMUJE BOMBE -> 10 RUR = 10 PKT 
        {
            if (bombs < 3) // bo mozemy miec max 3 bomby
            {
                Debug.Log("NOWA BOMBA!");
                bombs++;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // add score to list -> save file 

        gameManager.GameOver();
    }



}
