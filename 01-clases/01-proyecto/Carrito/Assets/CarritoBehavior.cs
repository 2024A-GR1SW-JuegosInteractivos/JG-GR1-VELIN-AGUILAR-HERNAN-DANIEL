using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoBehavior : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField]
    public float xVelocity;
    
    public float yVelocity;

    void Start()
    {
        try
        {
            rb = GetComponent<Rigidbody2D>();
            transform.Rotate(0, 0, 45);
        }
        catch { 
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetAxis("Horizontal") != 0) 
        //{
        transform.Rotate(0, 0, (transform.rotation.z + 10) % 360);

        //transform.Translate(0, 1, 1 * Mathf.Abs(Input.GetAxis("Horizontal")) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * xVelocity, 
                transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * yVelocity, transform.position.z);
        
        //}
    }
}
