using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRegulatorScript : ReplaceablesScript //INHERITANCE
{
    [SerializeField]
    protected float snapRange = 2.0f;
    [SerializeField]
    protected Vector3 snapOffset = new Vector3(0, 0, -1.0f);
    public float PowerSetting;
    private GameObject targetPowerRegulatorMounting;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    private void OnMouseUp()
    {
        targetPowerRegulatorMounting = FindSnapPoint("PowerRegulatorMounting", snapRange);

        if (targetPowerRegulatorMounting != null)
        {
            SnapToSnapPoint(snapOffset);
            targetPowerRegulatorMounting.GetComponent<PowerRegulatorMountingScript>().currentPowerRegulator = gameObject;
        }
    }

    protected override void OnMouseDrag() //POLYMORPHISM
    {
        base.OnMouseDrag();
        FindSnapPoint("PowerRegulatorMounting", snapRange);
        if (targetPowerRegulatorMounting != null && (targetPowerRegulatorMounting.GetComponent<PowerRegulatorMountingScript>().currentPowerRegulator = gameObject)) //if the currentPowerRegulator in the targeted  is THIS powerRegulator
        {
            targetPowerRegulatorMounting.GetComponent<PowerRegulatorMountingScript>().currentPowerRegulator = null; //reset currentPowerRegulator (i.e. the one currently in the mounting) to null when we pick this one up
        }
    }
}
