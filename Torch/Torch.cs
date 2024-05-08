using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool accesa = false;
    public GameObject torcia;
    public GameObject PickablePino;
    public GameObject manoDestra;
    public GameObject manoSinistra;
    public GameObject torchlight;

    public float durataBatteria = 180f;

    public float livelloBatteria = 100f;

    public bool torciaMano;

    public float tempoTrascorso = 0f;

    void Update()
    {
        if (torcia.transform.parent == PickablePino.transform && (PickablePino.transform.parent == manoDestra.transform || PickablePino.transform.parent == manoSinistra.transform))
        {
            torciaMano = true;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (accesa)
                {
                    accesa = false;
                    torchlight.SetActive(false);
                }
                else
                {
                    accesa = true;
                    torchlight.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Livello della batteria: " + livelloBatteria.ToString("0.00") + "%");
            }
        }
        else
        {
            torciaMano = false;
        }

        if (accesa)
        {
            tempoTrascorso += Time.deltaTime;
            livelloBatteria = 100f - (tempoTrascorso / durataBatteria) * 100f;

            if (livelloBatteria <= 0f)
            {
                accesa = false;
                torchlight.SetActive(false);
                Debug.Log("La batteria della torcia è esaurita.");  
            }
        }
    }
}
