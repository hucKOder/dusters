using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneHandler : MonoBehaviour
{
    public void StartGame()
    {
        GameObject[] audioObjects = GameObject.FindGameObjectsWithTag("AudioMusic");
        if (audioObjects.Length > 0)
        {
            audioObjects[0].GetComponent<AudioSource>().volume = 1;
            audioObjects[0].GetComponent<AudioLowPassFilter>().enabled = false;
        }
        SceneManager.LoadScene("MainScene");
    }
    void Update()
    {
    }
}
