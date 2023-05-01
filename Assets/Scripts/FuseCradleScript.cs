using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseCradleScript : SnapPointScript
{
    // Start is called before the first frame update
    protected override void Start()
    {
        gameObject.tag = "FuseCradle";
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }
    public override void Highlight()
    {
        Debug.Log("FuseCradleScript Highlight() method called");

        foreach (var renderer in renderers)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
    }
}
