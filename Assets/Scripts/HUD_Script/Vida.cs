using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vida: MonoBehaviour
{
    public float maxVida = 100f;
    public float vidaAtual = 0f;
    public GameObject barraVida;


    // Use this for initialization
    void Start()
    {
        vidaAtual = maxVida;
        InvokeRepeating("DiminuirVida", 1f, 2f);


    }

    // Update is called once per frame
    void Update()
    {


    }

    void DiminuirVida()
    {
        vidaAtual -= 2f;

        float calc_vida = vidaAtual / maxVida;

        BarraVida(calc_vida);


    }

    public void BarraVida(float minhaVida)
    {

        barraVida.transform.localScale = new Vector3(minhaVida, barraVida.transform.localScale.y, barraVida.transform.localScale.z);




    }
}
