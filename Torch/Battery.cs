using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public Torch torchScript;
    public float incrementoBatteria = 50f;
    public GameObject batteryText;
    bool interactable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            batteryText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            batteryText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E) && torchScript.torciaMano)
            {
                InteragisciConBatteria();
            }
            else if (torchScript.torciaMano == false)
            {
                Debug.Log("Non hai la torcia in mano");
            }
        }
    }

    void InteragisciConBatteria()
    {
        if (torchScript.livelloBatteria < 50f)
        {
            torchScript.livelloBatteria += 50f;

            float tempoAggiuntivo = torchScript.durataBatteria / 2f;
            torchScript.tempoTrascorso -= tempoAggiuntivo;

            if (torchScript.livelloBatteria > 100f)
            {
                torchScript.livelloBatteria = 100f;
            }

            Debug.Log("La batteria della torcia è stata ricaricata del 50%.");

            Destroy(gameObject);
            batteryText.SetActive(false);
        }
        else
        {
            Debug.Log("La batteria della torcia è già sufficientemente carica.");
        }
    }
}
