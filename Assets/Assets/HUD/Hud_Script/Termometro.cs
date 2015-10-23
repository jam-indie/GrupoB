using UnityEngine;
using System.Collections;

public class Termometro : MonoBehaviour {

    public float maxTemp= 100f;
    public float tempAtual = 0f;
    public GameObject barraTemp;


    // Use this for initialization
    void Start()
    {
        tempAtual = maxTemp;
        InvokeRepeating("DiminuirTemperatura", 1f, 1f);


    }

    // Update is called once per frame
    void Update()
    {
        if (tempAtual <=0) {

            Application.LoadLevel("Hud_Cena");

        }

    }

    void DiminuirTemperatura()
    {
        tempAtual -= 1f;

        float calc_tempo = tempAtual / maxTemp;

        BarraTemp(calc_tempo);


    }

    public void BarraTemp(float minhaTemp)
    {

        barraTemp.transform.localScale = new Vector3(minhaTemp, barraTemp.transform.localScale.y, barraTemp.transform.localScale.z);




    }
}
