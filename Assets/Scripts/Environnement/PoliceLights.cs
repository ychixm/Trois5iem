using System.Collections;
using UnityEngine;

namespace Environnement
{
    public class PoliceLights : MonoBehaviour
    {
        public GameObject redLight;
        public GameObject blueLight;

        void Start()
        {
            StartCoroutine(RedLightBlink());
        }
        IEnumerator RedLightBlink()
        {
            redLight.GetComponent<Light>().intensity = 25f;
            yield return new WaitForSeconds(0.5f);
            redLight.GetComponent<Light>().intensity = 0f;
            StartCoroutine(BlueLightBlink());
        }

        IEnumerator BlueLightBlink()
        {
            blueLight.GetComponent<Light>().intensity = 25f;
            yield return new WaitForSeconds(0.5f);
            blueLight.GetComponent<Light>().intensity = 0f;
            StartCoroutine(RedLightBlink());
        }
    }
}
