using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x+3.6f, player.position.y+3f, -10);
    }
}
