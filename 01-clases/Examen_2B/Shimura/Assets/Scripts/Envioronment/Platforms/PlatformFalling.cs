using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{

    public Rigidbody2D bambuLog;
    private Rigidbody2D fallingLog;
    public float timeLife, limitTime,speed;
    private float time;

    void Start()
    {
        fallingLog = Instantiate(bambuLog, transform.position, transform.rotation);
    }

    void FixedUpdate()
    {
        if (time >= limitTime)
        {
            time = 0;
            fallingLog = Instantiate(bambuLog, transform.position, transform.rotation);
            fallingLog.gravityScale = 0;
            fallingLog.velocity = new Vector2(0f, speed);
            Destroy(fallingLog.gameObject, timeLife);
        }
        if(fallingLog.velocity.y != speed)
        {
            fallingLog.velocity = new Vector2(0f, speed);
        }
        time += Time.deltaTime;
    }


}
