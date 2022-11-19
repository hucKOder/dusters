using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryHandler : MonoBehaviour
{
    public float batteryCapacity = 100f;
    public Sprite[] batterySprites;
    public Image imageHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (batteryCapacity > 60)
        {
            return;
        }
        if (batteryCapacity <= 60 && batteryCapacity > 20)
        {
            imageHolder.sprite = batterySprites[0];
        }
        else if (batteryCapacity <= 20)
        {
            imageHolder.sprite = batterySprites[1];
        }
    }
}
