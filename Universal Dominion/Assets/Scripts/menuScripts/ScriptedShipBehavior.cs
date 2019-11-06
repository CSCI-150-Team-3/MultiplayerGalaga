using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedShipBehavior : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
    }
}
