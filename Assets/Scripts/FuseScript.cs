using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FuseScript : ReplaceablesScript //INHERITANCE
{
    [SerializeField]
    protected float snapRange;
    [SerializeField]
    protected Vector3 snapOffset = new Vector3(0, 0, 0.2f);
    [SerializeField]
    private float _fuseRating;
    public float FuseRating //ENCAPSULATION
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
    private GameObject targetFuseCradle;
    [SerializeField]
    private TextMeshPro ratingText;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ratingText.text = new string($"{FuseRating}");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }

   
    private void OnMouseUp()
    {               
       targetFuseCradle = FindSnapPoint("FuseCradle", snapRange); //ABSTRACTION

        if (targetFuseCradle != null)
        {
            SnapToSnapPoint(snapOffset); //ABSTRACTION
            targetFuseCradle.GetComponent<FuseCradleScript>().currentFuse = gameObject;
        }
    }

    protected override void OnMouseDrag() //POLYMORPHISM
    {
        base.OnMouseDrag();
        FindSnapPoint("FuseCradle", snapRange); //ABSTRACTION
        if (targetFuseCradle != null && (targetFuseCradle.GetComponent<FuseCradleScript>().currentFuse = gameObject)) // if the current fuse in the targeted cradle is THIS fuse
        {
            targetFuseCradle.GetComponent<FuseCradleScript>().currentFuse = null; // reset current fuse in that cradle to null when we pick this fuse up
        }
    }

}
