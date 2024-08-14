using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public float barrierDefense = 20;
    private SpriteRenderer Srenderer;
    public Sprite total, half, final;
    private GameObject shimura;

    void Start()
    {
        shimura = GameObject.Find("Shimura");
        Srenderer = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(-shimura.transform.localScale.x * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Projectile")
        {
            barrierDefense -= 15;
            Destroy(col.gameObject);
        }
    }

    void Update()
    {
        Destroy(this.gameObject, 5);
        if (barrierDefense == 20) {
            Srenderer.sprite = total;
        }
        else if (barrierDefense < 20 && barrierDefense >= 10)
        {
            Srenderer.sprite = half;
        }
        else if (barrierDefense < 10 && barrierDefense > 0)
        {
            Srenderer.sprite = final;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
