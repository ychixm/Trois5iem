using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLights : MonoBehaviour
{
    public GameObject RedLight;
    public GameObject BlueLight;

    void Start()
    {
        StartCoroutine(redLightBlink());
    }
    IEnumerator redLightBlink()
    {
        RedLight.GetComponent<Light>().intensity = 25f;
        yield return new WaitForSeconds(0.5f);
        RedLight.GetComponent<Light>().intensity = 0f;
        StartCoroutine(blueLightBlink());
    }

    IEnumerator blueLightBlink()
    {
        BlueLight.GetComponent<Light>().intensity = 25f;
        yield return new WaitForSeconds(0.5f);
        BlueLight.GetComponent<Light>().intensity = 0f;
        StartCoroutine(redLightBlink());
    }
}
