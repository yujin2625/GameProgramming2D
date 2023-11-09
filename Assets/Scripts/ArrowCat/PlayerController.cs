using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    float speed = 5f;
    Vector2 left, right;
    bool leftOn, rightOn;
    private void Awake()
    {
        left = Vector2.left * Time.deltaTime * speed;
        right = Vector2.right * Time.deltaTime * speed;
        leftOn = rightOn = false;
    }
    private void Update()
    {
        if (leftOn)
        {
            gameObject.transform.position += (Vector3)left;
        }
        if (rightOn)
        {
            gameObject.transform.position += (Vector3)right;
        }
        
    }

    public void GoLeft()
    {
        leftOn = true;
    }
    public void GoRight()
    {
        rightOn = true;
    }

    public void NGoLeft()
    {
        leftOn = false;
    }
    public void NGoRight()
    {
        rightOn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            --PlayerState.hp;
        }
    }

}
