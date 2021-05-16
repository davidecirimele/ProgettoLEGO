using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggler : MonoBehaviour
{
    public float minIntensity; // the minimum intensity of the light
    public float maxIntensity; // the maximum intensity of the light
    public float maxRandomDelay;
    public bool startAtMin;

    [SerializeField] private Light myLight;
    [SerializeField] private float delay;
    [SerializeField] private float timeElapsed;

    private void Awake() {
        myLight = GetComponent<Light>();
        delay = 1f;
        if (myLight != null) {
            myLight.intensity = startAtMin ? minIntensity : maxIntensity;
        }
    }

    private void Update() {
        if (myLight != null) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= delay) {
                timeElapsed = 0;
                delay = Random.Range(0f, maxRandomDelay);
                ToggleLight();
            }
        }
    }

    public void ToggleLight()
    {
        if (myLight != null)
        {
            if (myLight.intensity == minIntensity) { myLight.intensity = maxIntensity; }
            else if (myLight.intensity == maxIntensity) { myLight.intensity = minIntensity; }
        }
    }
}
