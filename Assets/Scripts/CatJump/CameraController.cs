using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (player.transform.position.y > 0 && player.transform.position.y < 18.5f)
            transform.position = new Vector2(transform.position.x, player.transform.position.y);
    }
}
