using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VehicleBehaviour;

public class DigitalSpeedometer : MonoBehaviour
{
    [SerializeField] private GameObject car;

    private TextMeshProUGUI _text;

    private int _speed = 0;

    private WheelVehicle _carScript;

    private float _nextUpdate = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        _carScript = car.GetComponent<WheelVehicle>();
        InvokeRepeating("CustomUpdate", 0, _nextUpdate);
    }

    void CustomUpdate()
    {
        _speed = Mathf.FloorToInt(_carScript.Speed);
        if (_speed < 0)
        {
            _speed = 0;
        }
        _text.text = _speed.ToString();
    }
}
