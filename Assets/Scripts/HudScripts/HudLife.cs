using UnityEngine;
using System.Collections;

public class HudLife : MonoBehaviour {

    public int vida = 3; // A vida iniciara com um valor
    public GUIText textoVida;  // Poderia ser GUITexture

    void Start()
    {
        textoVida.text = "Vida: " + vida; //Texto que irá aparecer na GUIText
    }

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
