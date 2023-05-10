using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaferScript : ReplaceablesScript
{
    [SerializeField]
    protected float snapRange = 1.5f;
    [SerializeField]
    protected Vector3 snapOffset = new Vector3(0, 0, -0.5f);

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
        GameObject targetWaferSocket = FindSnapPoint("WaferSocket", snapRange);

        if (targetWaferSocket != null)
        {
            SnapToSnapPoint(snapOffset);
        } 
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        FindSnapPoint("WaferSocket", snapRange);
    }
}
