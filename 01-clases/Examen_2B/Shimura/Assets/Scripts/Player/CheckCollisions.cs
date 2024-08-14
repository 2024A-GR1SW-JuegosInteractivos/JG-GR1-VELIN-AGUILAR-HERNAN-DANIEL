using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    private Player shimura;
    private Rigidbody2D rb2d;
    List<string> groundTags = new List<string>(){
        "Ground",
        "Platform"
    };

    void Start()
    {
        shimura = GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name.Contains("Boing") && rb2d.velocity.y >= 8){
            rb2d.velocity = new Vector2(rb2d.velocity.x / 3, 8);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (groundTags.Contains(col.gameObject.tag))
        {
            shimura.grounded = true;

            if (col.gameObject.tag == "Platform")
            {
                transform.parent = col.transform;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (groundTags.Contains(col.gameObject.tag))
        {
            shimura.grounded = false;

            if (col.gameObject.tag == "Platform")
            {
                transform.parent = null;
            }
        }
    }

}
