using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replaceables : MonoBehaviour
{
    private Vector3 targetPosition;
    private Renderer[] renderers;


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

    void Move()
    {
        transform.position = targetPosition;
    }

    void SetTargetPosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        targetPosition = new Vector3(mouseWorldPos.x, mouseWorldPos.y, targetPosition.z);
    }

    void Highlight()
    {
        foreach (var renderer in renderers)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
    }

    void UnHighlight()
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
}
