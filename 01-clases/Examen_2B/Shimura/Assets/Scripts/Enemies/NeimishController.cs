using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeimishController : MonoBehaviour
{
    public Rigidbody2D projectile;
    private Rigidbody2D seed;
    private Animator anim;
    private SpriteRenderer render;
    public Sprite baseForm;
    private float timer;
    public float limitTime, projectileVelocity;
    private bool detecting, readyToAttack, moving;
    private Vector3 target;
    private float direction = -1.5f;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    void Update()
    {
        anim.SetBool("Detecting", detecting);
        anim.SetBool("Attacking", readyToAttack);
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 1.1f * Time.deltaTime);
            if(transform.position == target)
            {
                moving = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (detecting == true)
        {
            timer += Time.deltaTime;
        }
        if (timer >= limitTime)
        {
            readyToAttack = true;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            transform.localScale = new Vector3(-direction, 1.5f, 1f);
            target = transform.position + Vector3.up * 0.8f;
            moving = true;
            anim.enabled = true;
            readyToAttack = false;
            StartCoroutine(Grow());   
        }  
    }


    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player"){

            projectile.gravityScale = 0;

            if (readyToAttack) {

                if (col.gameObject.transform.position.x < transform.position.x)
                {
                    direction = -1.5f;
                }
                else if (col.gameObject.transform.position.x > transform.position.x)
                {
                    direction = 1.5f;
                    
                }
                transform.localScale = new Vector3(-direction, 1.5f, 1f);
                StartCoroutine(Shoot());
                timer = 0;
                readyToAttack = false;

            }

        }

    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player"){
            transform.localScale = new Vector3(-direction, 1.5f, 1f);
            StartCoroutine(Hide("Hiding"));
            detecting = false;
            target = transform.position + Vector3.down * 0.8f;
            moving = true;
            timer = 0;
        }
    }

    IEnumerator Grow()
    {
        anim.Play("Base Layer.Growing", 0, 0);
        yield return  new WaitForSeconds(0.6f);
        detecting = true;
    }


    IEnumerator Hide(string animation)
    {
        anim.Play($"Base Layer.{animation}", 0, 0);
        yield return new WaitForSeconds(0.6f);
        anim.enabled = false;
        render.sprite = baseForm;
    }


    IEnumerator Shoot()
    {
        anim.CrossFade("Shooting", 0.3f);
        yield return new WaitForSeconds(0.3f);
        seed = Instantiate(projectile, transform.position + direction * Vector3.right * 0.6f + Vector3.down * 0.5f, Quaternion.identity);
        transform.localScale = new Vector3(-direction, 1.5f, 1f);
        seed.velocity = new Vector2(direction * projectileVelocity, 0);
    }

}
