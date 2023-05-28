using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBird : MonoBehaviour
{
    public float gravity;
    public float jumpForce;
    public bool isInGame;

    float speed;

    private void Start()
    {
        isInGame = false;
    }

    void Update()
    {
        if (isInGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speed = jumpForce;
            }
            else
            {
                speed -= Time.deltaTime * gravity;
            }

            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }

    public void setisInGame()
    {
        isInGame = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInGame = false;
        //enabled = false;
    }
}
