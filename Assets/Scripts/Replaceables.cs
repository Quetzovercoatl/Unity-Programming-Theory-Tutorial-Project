using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replaceables : MonoBehaviour
{
    private Vector3 targetPosition;
    private Renderer objRenderer;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        targetPosition = transform.position;
        objRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    

    }

    void Move()
    {
        transform.position = targetPosition;
    }

    void SetTargetPosition()
    {

    }

    void Highlight()
    {
        //objRenderer.material.color = Color.yellow; //temporary code for test purposes - replace with code which intensifies existing object colour or which adds a glow effect of some sort
        objRenderer.material.EnableKeyword("_EMISSION");
    }

    void UnHighlight()
    {
        objRenderer.material.DisableKeyword("_EMISSION");
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
        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            targetPosition = new Vector3(hitData.point.x, hitData.point.y, targetPosition.z);
        }
        */

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        targetPosition = new Vector3(mouseWorldPos.x, mouseWorldPos.y, targetPosition.z);

        Move();
    }
}
