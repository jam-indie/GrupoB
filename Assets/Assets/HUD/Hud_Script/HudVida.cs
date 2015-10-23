using UnityEngine;
using System.Collections;

public class HudVida : MonoBehaviour {

    public float maxVida = 100f;
    public float vidaAtual = 0f;
    public GameObject barraVida;


    // Use this for initialization
    void Start()
    {
        vidaAtual = maxVida;
        InvokeRepeating("DiminuirVida", 1f, 1f);


    }

    // Update is called once per frame
    void Update()
    {
        if (vidaAtual <= 0)
        {

            Application.LoadLevel("Hud_Cena");

        }


    }

    void DiminuirVida()
    {
        vidaAtual -= 1f;

        float calc_vida = vidaAtual / maxVida;

        BarraVida(calc_vida);


    }

    public void BarraVida(float minhaVida)
    {

        barraVida.transform.localScale = new Vector3(minhaVida, barraVida.transform.localScale.y, barraVida.transform.localScale.z);




    }
}
