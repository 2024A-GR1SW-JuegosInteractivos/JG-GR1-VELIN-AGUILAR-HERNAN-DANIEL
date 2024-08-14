using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnePetals : MonoBehaviour
{
    private float time, limitTime = 3;
    public Rigidbody2D petal;

    void Update()
    {
        time += Time.deltaTime;
        if(time >= limitTime)
        {
            float yPos = Random.Range(transform.position.y + 5, transform.position.y - 5);
            Vector3 target = new Vector3(transform.position.x, yPos, -0.06f);
            Rigidbody2D usedPetal = Instantiate(petal, target, transform.rotation);

            usedPetal.gravityScale = 0;
            usedPetal.velocity = new Vector2(-3f, 0);
            Destroy(usedPetal.gameObject, 20);
            time = 0;
        }
    }
}
