using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRegulatorScript : ReplaceablesScript
{
    [SerializeField]
    protected float snapRange = 2.0f;
    [SerializeField]
    protected Vector3 snapOffset = new Vector3(0, 0, -1.0f);
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
        GameObject targetPowerRegulatorMounting = FindSnapPoint("PowerRegulatorMounting", snapRange);

        if (targetPowerRegulatorMounting != null)
        {
            SnapToSnapPoint(snapOffset);
        }
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        FindSnapPoint("PowerRegulatorMounting", snapRange);
    }
}
