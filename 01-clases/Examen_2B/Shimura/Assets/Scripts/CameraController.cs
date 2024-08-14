using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private DataController data;
    private GameObject shimura;
    private Vector3 distance, begin, end;
    public float limitOne, limitTwo;

    void Awake()
    {
        data = GameObject.Find("DataController").GetComponent<DataController>();
        shimura = GameObject.Find("Shimura");
        distance = transform.position - shimura.transform.position;
    }

    void Start()
    {
        if (data.begin <= data.end)
        {
            transform.position = distance + data.pos;
        }
        begin = GameObject.Find("LimitBegin").transform.position;
        end = GameObject.Find("LimitEnd").transform.position;
    }

    void Update()
    {
        if(shimura.transform.position.x >= begin.x + limitOne && shimura.transform.position.x <= end.x - limitTwo)
        {
            transform.position = distance + shimura.transform.position;
        }
        else
        {
            //simplificar esta condicion
            transform.position = new Vector3(transform.position.x, shimura.transform.position.y + distance.y, shimura.transform.position.z + distance.z);
        }

    }
}
