using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostprocessingScript : MonoBehaviour
{
    public float intensity = 0;

    PostProcessVolume _volume;

    Vignette _vignette;

    public attacks PlayerHealth;

    void Start()
    {

        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if (!_vignette)
        {
            print("error, vignette empty");
        }
        else
        {
            _vignette.enabled.Override(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.health == 49)
        {
            StartCoroutine(TakeDamageEffect());
            PlayerHealth.health = 48;
        }
        if(PlayerHealth.health == 99)
        {
            StartCoroutine(HealEffect());
            PlayerHealth.health = 100;
        }

        
    }

    private IEnumerator HealEffect()
    {
        intensity = 0.4f;
        _vignette.color.Override(Color.green);
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.4f);

        yield return new WaitForSeconds(0.2f);

        while (intensity > 0f)
        {

            intensity -= 0.01f;
            if (intensity < 0f)
            {
                intensity = 0f;
            }
            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.04f);

        }

        _vignette.enabled.Override(false);

        yield break;


    }

    private IEnumerator TakeDamageEffect()
    {
        intensity = 0.8f;
        _vignette.color.Override(Color.red);
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.8f);

        yield return new WaitForSeconds(0.2f);

        while (intensity > 0.4f)
        {

            intensity -= 0.01f;
            if(intensity < 0.4f)
            {
                intensity = 0.4f;
            }
            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.04f);

        }


        yield break;

        
    }
}
