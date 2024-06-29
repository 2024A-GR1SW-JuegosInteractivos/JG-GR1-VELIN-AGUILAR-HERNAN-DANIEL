using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BloberBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject puntoA;
    [SerializeField]
    private GameObject puntoB;
    private Vector3 origen, objetivoActual, objetivoA, objetivoB, previo;
    private Rigidbody2D rb;
    [SerializeField]
    private float movementVelocity;

    void Start()
    {
        origen = transform.position;
        objetivoA = puntoA.transform.position;
        objetivoB = puntoB.transform.position;
        previo = objetivoA;
        objetivoActual = objetivoA;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (objetivoActual != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, objetivoActual, movementVelocity * Time.deltaTime);
        }
        else
        {

            if (objetivoA == objetivoActual)
            {
                objetivoActual = origen;
                previo = objetivoA;
            }
            else if (objetivoB == objetivoActual)
            {
                objetivoActual = origen;
                previo = objetivoB;
            }
            else if (origen == objetivoActual) 
            {
                if (previo == objetivoA) objetivoActual = objetivoB;
                else objetivoActual = objetivoA;

            }
            else
            {
                objetivoActual = origen;
                previo = objetivoA;
            }

            Vector3 direction = objetivoActual - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            objetivoActual = collision.transform.position;
            movementVelocity = 8.5f;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            movementVelocity = 3f;
            
        }
    }
}
