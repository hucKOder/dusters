using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectsWithTag("AudioMusic")[0].GetComponent<AudioSource>();
        audioSource.volume = 0.8f;
    }
}
