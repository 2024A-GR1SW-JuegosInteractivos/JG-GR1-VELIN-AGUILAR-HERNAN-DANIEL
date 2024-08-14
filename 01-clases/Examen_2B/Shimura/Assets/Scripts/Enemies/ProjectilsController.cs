using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilsController : MonoBehaviour
{
    private DataController data;
    public int damage;


    void Start()
    {
        data = GameObject.Find("DataController").GetComponent<DataController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") {
            data.live = data.live + data.armor - damage;
        }
        Destroy(this.gameObject);
    }

}
