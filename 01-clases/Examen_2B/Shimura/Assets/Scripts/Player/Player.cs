using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private DataController data;
    public float speed, maxSpeed, jumpForce;
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool jump, sprinting, grounded, playable;
    public GameObject sword, barrier;
    private bool swordReady, animBarrier;
    //public Vector3 pos;

    private float h, swordTime, barrierTime = 4.5f;

    void Awake()
    {
        data = GameObject.Find("DataController").GetComponent<DataController>();

    }


    void Start()
    {
        //Control the begin position of the player
        if (data.begin <= data.end)
        {
            transform.position = data.pos;
        }

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        swordReady = true;
        playable = true;
    }


    void Update()
    {
        barrierTime += Time.deltaTime;
        swordTime += Time.deltaTime;
        h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Sprinting", sprinting);
        anim.SetBool("Barrier", animBarrier);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            jump = true;
        }
    }


    void FixedUpdate(){
        if (playable)
        {
            Jump();
            Walk();
            Sprint();
            Barrier();
            Sword();
        }
    }


    public void Walk() {

        //Arreglar el movimiento a tan solo awsd
        rb2d.AddForce(Vector2.right * speed * h);
        if (h < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (h > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        else if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }


    public void Sprint(){
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            sprinting = true;
            transform.Translate(Vector3.right * Time.deltaTime * 60 * transform.localScale.x);
            //rb2d.AddForce(Vector2.right * transform.localScale * 60, ForceMode2D.Impulse);
        }
        sprinting = false;
    }


    public void Barrier()
    {
        if (Input.GetKeyDown(KeyCode.J) && barrierTime >= 5)
        {
            playable = false;
            animBarrier = true;
            StartCoroutine("AnimBarrier");
            barrierTime = 0;
        }
    }

    public void Jump()
    {
        if (jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    
    public void Sword()
    {
        if (Input.GetKeyDown(KeyCode.K) && swordTime >= 0.9f)
        {
            GameObject swordUsed = Instantiate(sword, transform.position + Vector3.right * transform.localScale.x, Quaternion.identity);
            Rigidbody2D rb2DSword = swordUsed.GetComponent<Rigidbody2D>();
            rb2DSword.velocity = new Vector2(10f * transform.localScale.x, 0f);
            swordTime = 0;
            //barrier.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    IEnumerator SwordCooldown()
    {
        sword.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        sword.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        swordReady = true;
    }

    IEnumerator AnimBarrier()
    {
        yield return new WaitForSeconds(0.8f);
        GameObject barrierUsed;
        barrierUsed = Instantiate(barrier, transform.position + Vector3.right * transform.localScale.x + Vector3.forward * 0.05f, Quaternion.identity);
        playable = true;
        animBarrier = false;
    }

}
