using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f; 
    public float distance = 3f; 

    private float startX;
    private bool movingRight = true;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {

        if (movingRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);


            if (transform.position.x >= startX + distance)
            {
                movingRight = false; 
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            if (transform.position.x <= startX - distance)
            {
                movingRight = true; 
            }
        }
    }
}
