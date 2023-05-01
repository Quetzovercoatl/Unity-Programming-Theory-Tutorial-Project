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
        FindSnapPoint("WaferSocket", snapRange); //need to add code to stop this check when the object is already snapped in place. maybe just move this check to the OnMouseDrag() method
    }

    private void OnMouseUp()
    {
        GameObject targetWaferSocket = FindSnapPoint("WaferSocket", snapRange);

        if (targetWaferSocket != null)
        {
            SnapToSnapPoint(snapOffset);
        }
 
    }
}
