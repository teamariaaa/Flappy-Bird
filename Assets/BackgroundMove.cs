using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    MyBird myBird;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        myBird = FindObjectOfType<MyBird>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (myBird.isInGame)
            spriteRenderer.material.mainTextureOffset += new Vector2(Time.deltaTime / 2, 0);
    }
}
