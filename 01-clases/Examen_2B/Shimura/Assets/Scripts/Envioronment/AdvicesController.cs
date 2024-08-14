using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvicesController : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material.color = Color.clear;
        canvas.enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "Shimura")
        {
            canvas.enabled = true;
            float difference = Mathf.Abs((col.transform.position.x - transform.position.x) / 3.0f) - 1f;

            if (col.transform.position.x <= transform.position.x)
            {
                gameObject.GetComponent<SpriteRenderer>().material.color = -difference * Color.white;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().material.color = -difference * Color.white;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Shimura")
        {
            gameObject.GetComponent<SpriteRenderer>().material.color = Color.clear;
            canvas.enabled = false;
        }
    }
}