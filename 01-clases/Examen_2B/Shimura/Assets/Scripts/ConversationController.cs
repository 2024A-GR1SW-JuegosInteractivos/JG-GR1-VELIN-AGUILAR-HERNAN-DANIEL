using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    private Player shimura;
    public GameObject conversation;
    public string[] dialogues;
    public int position = 0;
    public Text text;
    private bool conversationReady = false;

    void Start()
    {
        shimura = GameObject.Find("Shimura").GetComponent<Player>();
        conversation.SetActive(false);  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Shimura")
        {
            shimura.playable = false;
            conversationReady = true;
        }

    }

    void Update()
    {
        text.text = dialogues[position];

        if (conversationReady){
            conversation.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space) && position < dialogues.Length - 1)
            {
                position += 1;
            }
            else if (position >= dialogues.Length - 1)
            {
                StartCoroutine(wait());
                conversation.SetActive(false);
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.4f);
        shimura.playable = true;
        Destroy(this);
    }
}
