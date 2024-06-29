using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private Vector3 distance;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        distance = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = distance + player.transform.position;
    }
}
