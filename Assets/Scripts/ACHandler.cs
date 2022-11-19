using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACHandler : MonoBehaviour
{
    public BatteryHandler battery;

    public int USAGE = 10;
    // In seconds
    public float speedOfConsuption = 1f;

    bool acOn = false;

    public Button thisButton;
    public Sprite acSprite;
    public Sprite acSprite_disabled;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            Debug.Log("Draining battery with Fog lights!");
            Debug.LogFormat("Batter capacity: {0}", battery.batteryCapacity);
        }
        else
        {
            if (acOn)
            {
                TurnOffAC();
            }
        }
    }

    public void SwitchAC()
    {
        if (acOn)
        {
            TurnOffAC();
        }
        else
        {
            if (CheckBattery())
            {
                TurnOnAC();
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

    public void TurnOnAC()
    {
        thisButton.image.overrideSprite = acSprite;
        // Trigger AC
        acOn = true;
        InvokeRepeating("SpendEnergy", 0f, speedOfConsuption);
    }
    public void TurnOffAC()
    {
        thisButton.image.overrideSprite = acSprite_disabled;
        // Disable AC
        acOn = false;
        CancelInvoke("SpendEnergy");
    }
}
