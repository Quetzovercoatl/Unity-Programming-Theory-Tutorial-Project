using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScript : ReplaceablesScript
{
    [SerializeField]
    protected float snapRange = 0.5f;
    [SerializeField]
    protected Vector3 snapOffset = new Vector3(0, 0, 0.2f);

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        FindSnapPoint("FuseCradle", snapRange);
    }

   
    private void OnMouseUp()
    {               
        GameObject targetFuseCradle = FindSnapPoint("FuseCradle", snapRange);

        if (targetFuseCradle != null)
        {
            SnapToSnapPoint(snapOffset);
        }
    }   

}
