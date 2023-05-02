using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseCradleScript : SnapPointScript
{
    public GameObject currentFuse;
    private CircuitManager circuitManager;
    private ParticleSystem sparks;

    // Start is called before the first frame update
    protected override void Start()
    {
        gameObject.tag = "FuseCradle";
        circuitManager = FindObjectOfType<CircuitManager>();
        sparks = GetComponent<ParticleSystem>();
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (FuseShouldFail())
        {
            Destroy(currentFuse);
            sparks.Play();

        }
    }
    public override void Highlight()
    {
        Debug.Log("FuseCradleScript Highlight() method called");

        foreach (var renderer in renderers)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
    }

    protected bool FuseShouldFail()
    {
        if (currentFuse == null)
        {
            return false;
        }
        if (circuitManager.devicePowerLevel > currentFuse.GetComponent<FuseScript>().FuseRating)
        {
            Debug.Log("fuse should fail");
            return true;
        }
        else
        {
            return false;
        }
    }
}
