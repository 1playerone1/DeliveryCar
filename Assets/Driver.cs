using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float SteerSpeed = 120f;
    [SerializeField] float MoveSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        float SteerAmount = Input.GetAxis("Horizontal")* SteerSpeed* Time.deltaTime;
        float SpeedAmount = Input.GetAxis("Vertical")* MoveSpeed* Time.deltaTime;
        transform.Rotate(0, 0, -SteerAmount);
        transform.Translate(0, SpeedAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        MoveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            Debug.Log("Go Go Fast!!");
            MoveSpeed = boostSpeed;
        }
    }
}
