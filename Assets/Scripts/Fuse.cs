using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : Replaceables
{
    private bool cradleInRange;
    private GameObject targetCradle;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        CheckForCradle();
    }

    //check if in range of a fuse cradle
    void CheckForCradle()
    {
        float checkRadius = 1.0f;
        int cradlesInRange = 0;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.name == "FuseCradle")
            {
                Debug.Log("FuseCradle in range");
                cradlesInRange++;
                targetCradle = hitCollider.gameObject;
            }
          
        }
        if (cradlesInRange != 0)
        {
            cradleInRange = true;
        }
        else
        {
            cradleInRange = false;
        }
    }

    private void OnMouseUp()
    {

        if (cradleInRange)
        {
            SnapToCradle();
        }
    }


    //snap to fuse cradle snap point
    void SnapToCradle()
    {
        transform.position = targetCradle.transform.Find("SnapPoint").transform.position;
    }

}
