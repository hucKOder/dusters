using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public GameObject audioSource;
    public void StartGame()
    {
        var audio = audioSource.GetComponent<AudioSource>();
        audio.volume = 1;
        var lowPassFilter = audioSource.GetComponent<AudioLowPassFilter>();
        lowPassFilter.enabled = false;
        SceneManager.LoadScene("MainScene");
    }
    void Update()
    {
    }
}
