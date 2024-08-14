using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComeBackTo : MonoBehaviour
{
    Vector3 distance;
    public Vector3 position;
    public string objective;
    private GameObject mainCamera;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Scene scene = SceneManager.GetActiveScene();
        if(objective == scene.name)
        {
            mainCamera = GameObject.Find("Main Camera");
            distance = transform.position - mainCamera.transform.position;
        }
        Debug.Log("Active Scene is '" + scene.name + "'.");

    }

    /*
    private void Start()
    {
        transform.position = position;
        mainCamera.transform.position = transform.position - distance;
    }*/

    void Start()
    {
        //Debug.Log("pan");
        //Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene is '" + scene.name + "'.");
    }

    void Update()
    {
        
    }

}
