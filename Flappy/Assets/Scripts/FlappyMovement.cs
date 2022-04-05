using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMovement : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField] private float velocity;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        }

        // gdy dwa razy szybko tap -> Bomb()
    }

    void Bomb()
    {
        // space for bomb logic
    }

}
