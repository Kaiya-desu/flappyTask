using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    public float speed; // moze zrobic by poruszaly sie coraz szybciej?

    void Start()
    {
        speed = GameManager.speed;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
