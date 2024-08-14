using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformConstant : MonoBehaviour
{
    public GameObject begin, end, platform;
    Vector3 target;
    public float speed;

    void Start()
    {
        target = end.transform.position;
    }

    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, target, speed * Time.deltaTime);

        if (platform.transform.position == end.transform.position){
            target = begin.transform.position;
        }
        else if (platform.transform.position == begin.transform.position)
        {
            target = end.transform.position;
        }

    }
}
