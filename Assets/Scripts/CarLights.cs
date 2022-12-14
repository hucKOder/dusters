using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLights : MonoBehaviour
{
    [Header("UI")]
    public Light leftFogLight;
    public Light rightFogLight;
    public BatteryHandler battery;

    public int USAGE = 1;
    // In seconds
    public float speedOfConsuption = 1f;
    public int luminosity = 2;

    bool lightsOn = false;

    //public GameObject playerCursor;
    //BoxCollider2D cursorBoxCollider;
    public Button thisButton;
    public Sprite fogLightSprite;
    public Sprite fogLightSprite_disabled;

    private void Start()
    {
        //cursorBoxCollider = playerCursor.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Collider2D[] overlap = Physics2D.OverlapAreaAll(cursorBoxCollider.bounds.min, cursorBoxCollider.bounds.max);
        //if (overlap.Length > 1)
        //    SwapHandSprite(overlap[0].gameObject);
    }

    private void SwapHandSprite(GameObject button)
    {
        Debug.Log("Swapping hand to pointy hand.");
        //button.GetComponent<Image>().overrideSprite = fogLightSprite;
    }

    public bool CheckBattery()
    {
        if ((battery.batteryCapacity - USAGE) < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void SpendEnergy()
    {
        if (CheckBattery())
        {
            battery.batteryCapacity -= USAGE;
        }
        else
        {
            if (lightsOn)
            {
                TurnOffLights();
            }
        }
    }

    public void SwitchLights()
    {
        if (lightsOn)
        {
            TurnOffLights();
        }
        else
        {
            if (CheckBattery())
            {
                TurnOnLights();
            }
            else
            {
                CannotUseAction();
            }
        }
    }

    void CannotUseAction()
    {
        Debug.Log("Not enough energy for this button!");
    }

    public void TurnOnLights()
    {
        thisButton.image.overrideSprite = fogLightSprite;
        leftFogLight.intensity = luminosity;
        rightFogLight.intensity = luminosity;
        lightsOn = true;
        InvokeRepeating("SpendEnergy", 0f, speedOfConsuption);
    }
    public void TurnOffLights()
    {
        thisButton.image.overrideSprite = fogLightSprite_disabled;
        leftFogLight.intensity = 0;
        rightFogLight.intensity = 0;
        lightsOn = false;
        CancelInvoke("SpendEnergy");
    }
}
