using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject shimura;

    void Start()
    {
        shimura = GameObject.Find("Shimura");
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        transform.localScale = new Vector3(shimura.transform.localScale.x * transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }

    private void Update()
    {
        Destroy(this.gameObject, 2.5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
