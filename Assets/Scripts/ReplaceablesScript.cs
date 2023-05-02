using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceablesScript : MonoBehaviour
{
    private Vector3 targetPosition;
    private Renderer[] renderers;
    private GameObject targetSnapPoint = null;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        targetPosition = transform.position;
        renderers = GetComponentsInChildren<Renderer>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
    

    }

    protected void Move()
    {
        transform.position = targetPosition;
    }

    protected void SetTargetPosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9); //the value of the z float here should be changed so it is set by the distance from the camera to the object being moved
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        targetPosition = new Vector3(mouseWorldPos.x, mouseWorldPos.y, targetPosition.z);
    }

    protected void Highlight()
    {
        foreach (var renderer in renderers)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
    }

    protected void UnHighlight()
    {
        foreach (var renderer in renderers)
        {
            renderer.material.DisableKeyword("_EMISSION");
        }
    }

    private void OnMouseEnter()
    {
        Highlight();
    }

    private void OnMouseExit()
    {
        UnHighlight();
    }

    private void OnMouseDrag()
    {
        SetTargetPosition();

        Move();
    }

    protected GameObject FindSnapPoint(string snapPointTag) //this version of this method just has a default checkRadius set inside the method
    {
        float checkRadius = 1.0f;
        int snapPointsInRange = 0;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(snapPointTag))
            {
                snapPointsInRange++;

                if (targetSnapPoint == null)  //if there is currently no SnapPoint targeted
                {
                    targetSnapPoint = hitCollider.gameObject;  //assign this hitCollider as the target
                }
                else //i.e. if there already is a target SnapPoint set
                {
                    if (Vector3.Distance(transform.position, hitCollider.transform.position) < Vector3.Distance(transform.position, targetSnapPoint.transform.position)) //if the current hitCollider is closer thant the currently set targetSnapPoint
                    {
                        targetSnapPoint = hitCollider.gameObject;  //assign this hitCollider as the target
                    }
                }
            }
        }
        if (snapPointsInRange > 0) //if there is at least one of the relevant SnapPoints in range
        {
            Debug.Log($"Snap Point {snapPointTag} is in range");

            return targetSnapPoint;
        }
        else
        {
            return null;
        }
    }

    protected GameObject FindSnapPoint(string snapPointTag, float checkRadius) //overloaded version of this method which allows the checkRadius to be set when the method is called
    {
        int snapPointsInRange = 0;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag(snapPointTag))
            {
                snapPointsInRange++;
                Debug.Log($"Snap Point {snapPointTag} is in range");


                if (targetSnapPoint == null)  //if there is currently no SnapPoint targeted
                {
                    targetSnapPoint = hitCollider.gameObject;  //assign this hitCollider as the target
                }
                else //i.e. if there already is a target SnapPoint set
                {
                    if (Vector3.Distance(transform.position, hitCollider.transform.position) < Vector3.Distance(transform.position, targetSnapPoint.transform.position)) //if the current hitCollider is closer thant the currently set targetSnapPoint
                    {
                        targetSnapPoint = hitCollider.gameObject;  //assign this hitCollider as the target
                    }
                }
            }
        }
        if (snapPointsInRange > 0) //if there is at least one of the relevant SnapPoints in range
        {
            Debug.Log($"Snap Point {snapPointTag} is in range");
            return targetSnapPoint;
        }
        else return null;
    }
    protected void SnapToSnapPoint()
    {
        transform.position = targetSnapPoint.transform.Find("SnapPoint").transform.position;

    }

    protected void SnapToSnapPoint(Vector3 snapOffset)
    {
        transform.position = targetSnapPoint.transform.Find("SnapPoint").transform.position + snapOffset;
    }
}
