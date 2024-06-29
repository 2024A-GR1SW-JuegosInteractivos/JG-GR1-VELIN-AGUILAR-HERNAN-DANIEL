using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformadorBehavior : MonoBehaviour
{
    [SerializeField]
    private string objectName;

    void Start()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (objectName.Equals("transformador") && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehavior>().canTransform = true;
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectName.Equals("cafe") && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehavior>().moveSpeed = 8;
            Destroy(this.gameObject);
        }
        else if (objectName.Equals("key") && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehavior>().hasKey = true;
            Destroy(this.gameObject);
        }
    }
}
