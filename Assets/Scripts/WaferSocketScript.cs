using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaferSocketScript : SnapPointScript
{

    // Start is called before the first frame update
    protected override void Start()
    {
        gameObject.tag = "WaferSocket";
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
}
