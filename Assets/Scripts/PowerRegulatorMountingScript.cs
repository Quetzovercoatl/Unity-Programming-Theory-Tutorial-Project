using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRegulatorMountingScript : SnapPointScript //INHERITANCE
{
    public GameObject currentPowerRegulator;
    private CircuitManager circuitManager;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        circuitManager = FindObjectOfType<CircuitManager>();

    }

    // Update is called once per frame
    protected override void Update() //POLYMORPHISM
    {
        base.Update();
        SetDevicePower();

    }

    private void SetDevicePower()
    {
        if (currentPowerRegulator != null)
        {
            circuitManager.DevicePowerLevel = currentPowerRegulator.GetComponentInChildren<PowerRegulatorScript>().PowerSetting;
        }
        else
        {
            circuitManager.DevicePowerLevel = 0.0f;
        }
    }
}
