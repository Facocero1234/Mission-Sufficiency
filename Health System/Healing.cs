using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    bool interactable, healed;
    public GameObject healText;
    public GameObject maxText, alreadyText, healedText;

    public attacks PlayerHealth;

    void Start()
    {
        interactable = false;
        healed = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            healText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            healText.SetActive(false);
            interactable = false;
        }
    }

    IEnumerator ShowAndHideTextMax(float delay)
    {
        maxText.SetActive(true);
        yield return new WaitForSeconds(delay);
        maxText.SetActive(false);
    }

    IEnumerator ShowAndHideTextAlready(float delay)
    {
        alreadyText.SetActive(true);
        yield return new WaitForSeconds(delay);
        alreadyText.SetActive(false);
    }

    IEnumerator ShowAndHideTextHealed(float delay)
    {
        healedText.SetActive(true);
        yield return new WaitForSeconds(delay);
        healedText.SetActive(false);
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerHealth.health == 100 && !healed)
                {
                    StartCoroutine(ShowAndHideTextMax(2f));
                }
                else if (PlayerHealth.health == 48 && !healed)
                {
                    PlayerHealth.health = 99;
                    healed = true;
                    StartCoroutine(ShowAndHideTextHealed(2f));
                }
                else if (healed)
                {
                    StartCoroutine(ShowAndHideTextAlready(2f));
                }
            }
        }
    }
}
