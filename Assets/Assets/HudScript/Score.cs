using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{

    public GUIText textoScore;
    public int score;


    // Use this for initialization
    void Start()
    {

        score = 0; // Será iniciado com o valor zero.

    }

    // Update is called once per frame
    void Update()
    {
        textoScore.text = "Score: " + score;  //O nome que irá aparecer na GUItex, mais o valor.


    }
   /* void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "cubo")
        {

            other.gameObject.SetActive(false); // Quando o player entrar em contato com o objeto, somara um ponto e esse objeto fica desativado.

            score = score + 1;

        }
    }*/
}