using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    //public static DataController data;
    public int live, points, armor, attack;
    public int begin, end;
    //public int unique;
    Scene scene;
    public Vector3 pos;
    

    void Start()
    {
        live = 100;
        points = 0;
        armor = 3;
        attack = 7;
    }
    /*
    void Awake()
    {
        if(data == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else //if(data != this)
        {
            data = this;
            Destroy(gameObject);
        }

    }*/

    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        begin = scene.buildIndex;
        var data = FindObjectsOfType<DataController>();

        if (data.Length > 1)
        {
            Destroy(gameObject);
        }
        //unique = data.Length;
        DontDestroyOnLoad(gameObject);
    }

    
    void OnEnable()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //if(unique == 1)
        //{
            begin = scene.buildIndex;
            Debug.LogFormat($"begin : {begin}");
        //}
    }

    private void OnSceneUnloaded(Scene current)
    {
        //if(unique == 1)
        //{
            end = Mathf.Abs(scene.buildIndex);
            Debug.LogFormat($"end : {end}");
        //}
    }

    /*
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 200, 100), $"Score{points},");

        GUI.Box(new Rect(20, 120, 200, 100), $"Life{live}");

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), content, style);

    }*/

}
