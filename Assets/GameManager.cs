using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VehicleBehaviour;

public class GameManager : MonoBehaviour
{
    public Image brakesImage;
    public WheelVehicle vehicle;
    public Sprite brakesSprite;
    public AudioSource notificationAudioSource;
    public TextMeshProUGUI warningText;

    [SerializeField]
    int speedTrigger = 20; 

    bool brakesLid = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!brakesLid && vehicle.Speed > speedTrigger)
        {
            brakesImage.sprite = brakesSprite;
            brakesLid = true;
            notificationAudioSource.Play();
            StartCoroutine(BreaksWarning());
        }
    }

    IEnumerator BreaksWarning()
    {
        warningText.enabled = true;
        yield return new WaitForSeconds(3f);
        warningText.enabled = false;
    }
}
