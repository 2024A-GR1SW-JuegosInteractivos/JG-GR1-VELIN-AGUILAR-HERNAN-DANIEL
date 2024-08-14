using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SasmogController : MonoBehaviour
{
    public float sasmogSpeed;
    public Rigidbody2D projectile;
    private Rigidbody2D seed;
    private Animator anim;
    public GameObject limitOne, limitTwo;
    private Vector3 posBegin, posEnd, target, objective;
    //private SpriteRenderer render;
    //public Sprite baseForm;
    private float timer;
    public float limitTime, projectileVelocity;
    private bool detecting, readyToAttack, moving;
    private float direction;

    void Start()
    {
        anim = GetComponent<Animator>();
        posBegin = limitOne.transform.position;
        posEnd = limitTwo.transform.position;
        target = posEnd;

    }

    void Update()
    {
        anim.SetBool("Attacking", readyToAttack);
        anim.SetBool("Detecting", detecting);
        anim.SetBool("Moving", moving);
        //objective = 
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), sasmogSpeed * Time.deltaTime);
        if (target.x >= transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (transform.position == posEnd)
        {
            target = posBegin;
        }
        else if (transform.position == posBegin)
        {
            target = posEnd;
        }
    }

    void FixedUpdate()
    {
        if (detecting)
        {
            timer += Time.deltaTime;
        }
        if(timer > limitTime)
        {
            readyToAttack = true;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            detecting = true;
            target = col.transform.position;
        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            detecting = true;
            target = col.transform.position;
        }
        if (readyToAttack)
        {
            if (Mathf.Abs(transform.position.x - col.transform.position.x) <= 1.8f)
            {
                Mele();
            }
            else
            {
                Poison();
            }
            StartCoroutine(AtackCourutine());
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            detecting = false;
            target = posEnd;
        }
    }


    void Mele()
    {
        Debug.Log("mele");
    }


    void Poison()
    {
        Debug.Log("poison");
    }

    IEnumerator AtackCourutine()
    {
        readyToAttack = false;
        timer = 0;
        yield return new WaitForSeconds(0.8f);
        readyToAttack = false;
        timer = 0;
    }

}
