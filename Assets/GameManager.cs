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

    public Image tutorialImage;

    AudioSource mainAudioSource;
    [SerializeField]
    int speedTrigger = 20; 

    bool brakesLid = false;
    bool tutorialShown = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("AudioMusic");
        if (audioObjects.Length > 0)
        {
            mainAudioSource = audioObjects[0].GetComponent<AudioSource>();
         }
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialShown && Input.anyKey)
        {
            tutorialImage.enabled = false;
            tutorialShown = true;
        }
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
