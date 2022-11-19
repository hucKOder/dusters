using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLights : MonoBehaviour
{
    [Header("UI")]
    public Light leftFogLight;
    public Light rightFogLight;
    public float battery;

    public int USAGE = 10;
    // In seconds
    public int speedOfConsuption = 5;
    public int luminosity = 2;

    bool lightsOn = false;

    Button thisButton;
    public Sprite fogLightSprite;
    public Sprite fogLightSprite_disabled;

    private void Start()
    {
        thisButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsOn)
        {
            StartCoroutine("SpendEnergy");
        }
    }

    IEnumerator SpendEnergy()
    {
        if (battery >= (battery - USAGE))
        {
            battery -= USAGE;
            yield return new WaitForSeconds(USAGE);
        }
        else
        {
            turnOffLights();
        }
    }

    public void turnOnLights()
    {
        thisButton.image.overrideSprite = fogLightSprite;
        leftFogLight.intensity = luminosity;
        rightFogLight.intensity = luminosity;
        lightsOn = true;
    }

    public void turnOffLights()
    {
        thisButton.image.overrideSprite = fogLightSprite_disabled;
        leftFogLight.intensity = 0;
        rightFogLight.intensity = 0;
        lightsOn = false;
    }
}
