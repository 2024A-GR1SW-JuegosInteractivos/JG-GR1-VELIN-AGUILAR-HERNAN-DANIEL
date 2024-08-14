using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeimishLife : MonoBehaviour
{
    public int life;
    private DataController data;
    public GameObject father;

    void Start()
    {
        data = GameObject.Find("DataController").GetComponent<DataController>();
    }

    void Update()
    {
        if(life <= 0)
        {
            data.points += Random.Range(5, 50);
            Destroy(father);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Sword")
        {
            life -= data.attack;
            Debug.Log(life);
        }
    }
}
