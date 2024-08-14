using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterToPlaces : MonoBehaviour
{

    public int scene;
    private Player shimura;
    public Vector3 posToMove;
    private DataController data;

    void Start()
    {
        data = GameObject.Find("DataController").GetComponent<DataController>();
        shimura = GameObject.Find("Shimura").GetComponent<Player>(); 
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            data.pos = posToMove;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.E) && col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(scene);
        }
        
    }
}
