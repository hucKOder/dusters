using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    public float SlowMotionFactor = 0.5f;
    public float SlowMotionBlendTime = 5.0f;

    private bool slowMotioActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slowMotioActive || Input.GetKey(KeyCode.R))
        {
            Time.timeScale = Mathf.Lerp(1, SlowMotionFactor, SlowMotionBlendTime);
        }
        else
        {
            Time.timeScale = Mathf.Lerp(SlowMotionFactor, 1, SlowMotionBlendTime);
        }

        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        // obstacle layer ?
        if (other.gameObject.layer == 7)
        {
            Debug.Log("Near Miss Happening");
            slowMotioActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            slowMotioActive = false;
            Debug.Log("Near Miss Left");
        }
    }
}
