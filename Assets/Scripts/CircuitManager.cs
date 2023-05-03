using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitManager : MonoBehaviour
{
    [SerializeField]
    private float _devicePowerLevel;
    public float DevicePowerLevel
    {
        get { return _devicePowerLevel; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("devicePowerLevel cannot be a negative number");
            }
            else
            {
                _devicePowerLevel = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
