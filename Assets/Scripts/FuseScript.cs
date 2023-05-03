using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScript : ReplaceablesScript
{
    [SerializeField]
    protected float snapRange = 1.0f;
    [SerializeField]
    protected Vector3 snapOffset = new Vector3(0, 0, 0.2f);
    [SerializeField]
    private float _fuseRating;
    public float FuseRating
    {
        get { return _fuseRating; }
        set
        {
            if (value > 0.0f)
            {
                _fuseRating = value;
            }
            else
            {
                Debug.LogError("FuseRating cannot be a negative number");
            }
        }
    }

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
        GameObject targetFuseCradle = FindSnapPoint("FuseCradle", snapRange);

        if (targetFuseCradle != null)
        {
            SnapToSnapPoint(snapOffset);
            targetFuseCradle.GetComponent<FuseCradleScript>().currentFuse = gameObject;
        }
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        FindSnapPoint("FuseCradle", snapRange);
    }

}
