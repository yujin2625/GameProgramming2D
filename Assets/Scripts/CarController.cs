using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    CarUI carUI;
    float distance;
    public GameObject flag;
    public GameObject canvas;
    public PlayerInput playerInput;
    float start = 0;
    float end = 0;
    public Vector3 defaultPosition = new(-7, -3, 0);
    public float speed = 0;
    public float mousePosition = 0;
    public int tryNum = 0;
    InputAction inputAction;
    public void Start()
    {
        flag = GameObject.Find("flag");
        canvas = GameObject.Find("Canvas");
        carUI = canvas.GetComponent<CarUI>();

    }
    public void Update()
    {
        distance = (float)Mathf.FloorToInt(Vector2.Distance(transform.position, flag.transform.position) * 100) / 100;
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (!(speed < 0.01))
        {
            speed *= 0.99f;
        }
        else
        {
            speed = 0;
        }
        
        carUI.DisTextSet(distance);
        
    }
    public void MoveCar(float inputSpeed)
    {
        speed = inputSpeed*0.01f;
    }
    public void OnSwipe(InputValue value)
    {
        if (value.isPressed)
        {
            start = Mouse.current.position.ReadValue().x;
        }
        if (!value.isPressed)
        {
            end = Mouse.current.position.ReadValue().x;
            MoveCar(end - start);
        }
    }

    public void RestartGame()
    {
        tryNum++;
        carUI.PastTextSet(tryNum, distance);
        transform.position = defaultPosition;
        flag.transform.position = new Vector3((float)Mathf.FloorToInt(Random.Range(0f, 8f)*100)/100, -3, 0);
    }

}
