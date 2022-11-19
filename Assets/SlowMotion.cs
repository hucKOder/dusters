using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{

    public float SlowMotionFactor = 0.5f;
    public float SlowMotionBlendTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = Mathf.Lerp(1, SlowMotionFactor, SlowMotionBlendTime);
        }
        else
        {
            Time.timeScale = Mathf.Lerp(SlowMotionFactor, 1, SlowMotionBlendTime);
        }

        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
}
