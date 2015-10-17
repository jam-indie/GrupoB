using UnityEngine;
using System.Collections;

public class HudVida : MonoBehaviour {

    public int vida = 3; // A vida iniciara com um valor
    public GUIText textoVida;  // Poderia ser GUITexture




    // Use this for initialization
    void Start()
    {


        textoVida.text = "Vida: " + vida; //Texto que irá aparecer na GUIText


    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0) 
        {
            //Se a vida for menor ou igual a zero, vai reiniciar o jogo "Coloquei assim, porque ainda não tem Game Over"
            // E tem que criar um OnCollider2D pra quando o objeto colidir com inimigo por exemplo ir perdendo a vida e morrer.

            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
