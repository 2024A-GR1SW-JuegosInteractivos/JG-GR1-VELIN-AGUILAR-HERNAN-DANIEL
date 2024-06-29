using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 8f;
    private Rigidbody2D rb;
    public bool canTransform, isHide;
    private CapsuleCollider2D bodyCollider;
    public bool hasKey = false;
    [SerializeField]
    private Sprite initial;
    [SerializeField]
    private Sprite estatua;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        initial = GetComponent<SpriteRenderer>().sprite;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isHide) Walk();
        if(canTransform) Hide();
    }


    private void Walk() 
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput > 0) transform.localScale = Vector3.one;
        else if (horizontalInput < 0) transform.localScale = new Vector3(-1, 1, 1);

        rb.velocity = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed;
    }

    private void Hide() 
    { 
        if(Input.GetKeyDown(KeyCode.E))
        {
            isHide = !isHide;

            if (isHide)
            {
                //SE OCULTA
                GetComponent<SpriteRenderer>().sprite = estatua;
                bodyCollider.enabled = false;
                gameObject.tag = "Untagged";
                bodyCollider.enabled = true;
                rb.velocity = Vector2.zero;
            }
            else 
            {
                //SE DESCUBRE
                GetComponent<SpriteRenderer>().sprite = initial ;
                gameObject.tag = "Player";
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.tag == "Enemy")
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Puerta" && hasKey)
        {
            //CARGAR EL NIVEL DE FELICITACIONES
            Debug.Log("AJALAFASTRUK");
            SceneManager.LoadScene("Felicitaciones");
        }
    }
}
