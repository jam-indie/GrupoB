using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public float tempo = 10.0f;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame

   void OnGUI()
    {

        GUI.Box(new Rect(1100, 30, 100, 50), "" + tempo.ToString("0"));



    }
    void Update()
    {

        tempo -= Time.deltaTime;
      

        if (tempo <= 0)
        {

            tempo = 0;

            Application.LoadLevel("GameOver");


        }

    }
}