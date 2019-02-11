﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Vector2 direction;

    public Vector3 originPosition;

    void Awake()
    {
        originPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * gameManager.instance.astroidVelocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Player")
        {
            gameManager.instance.activeEnemies.Remove(this.gameObject);
            Destroy(this.gameObject);

            // Also destroy bullet
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Board")
        {
            Debug.Log("Asteroid in Playing Field");
        }
        Debug.Log(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!gameManager.instance.removingEnemies)
        {
            if (other.gameObject.tag == "Board")
            {
                gameManager.instance.activeEnemies.Remove(this.gameObject);
                Debug.Log("Astroid got destoryed!!!");
                Destroy(this.gameObject);
            }
        }
    }
}