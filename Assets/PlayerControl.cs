﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public float speed = 10.0f;
    public float yBoundary = 9.0f;
    private Rigidbody2D rigidBody2D;
    private ContactPoint2D lastContactPoint;
    
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;
        if (Input.GetKey(upButton)) {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton)) {
            velocity.y = -speed;
        }
        else {
            velocity.y = 0.0f;
        }

        rigidBody2D.velocity = velocity;

        Vector3 position = transform.position;

        if (position.y > yBoundary) {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary) {
            position.y = -yBoundary;
        }
        transform.position = position;
    }

    public void IncrementScore() {
        score++;
    }

    public void ResetScore() {
        score = 0;
    }

    public int Score {
        get { return score; }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Equals("Ball")) {
            lastContactPoint = collision.GetContact(0);
        }
    }

    public ContactPoint2D LastContactPoint {
        get { return lastContactPoint; }
    }
}
