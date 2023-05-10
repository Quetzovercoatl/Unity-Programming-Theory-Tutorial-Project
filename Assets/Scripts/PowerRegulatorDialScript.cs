using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRegulatorDialScript : MonoBehaviour
{
    private Renderer[] renderers;
    private Vector3 mouseWorldPos;
    private Vector3 initialLocalEulerAngles;
    private Vector3 initialRelMousePos;
    [SerializeField]
    private float minAngle;
    [SerializeField]
    private float maxAngle;
    [SerializeField]
    private float minDialSetting;
    [SerializeField]
    private float maxDialSetting;
    public float DialSetting { get; private set; }
    private PowerRegulatorScript powerRegulatorScript;


    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, minAngle);
        powerRegulatorScript = GetComponentInParent<PowerRegulatorScript>();

    }

    // Update is called once per frame
    void Update()
    {

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

    private float MouseAngleChange()
    {
        Vector3 currentRelMousPos = RelativeMousePosition();
     
        float mouseAngle = Vector3.SignedAngle(initialRelMousePos, currentRelMousPos, Vector3.back);             
        //Debug.Log($"SignedAngle = {mouseAngle}");
        return mouseAngle;
    }
    private Vector3 MousePosition()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z); //the value of the z float here should be changed so it is set by the distance from the camera to the object being targeted
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return mouseWorldPos;
    }

    private Vector3 RelativeMousePosition()
    {
        Vector3 relativeMousePos = MousePosition() - transform.position;
        return relativeMousePos;
    }

    private void RotateDial()
    {
        Vector3 minRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, minAngle);
        Vector3 maxRotation = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, maxAngle);

        if (initialLocalEulerAngles.z + MouseAngleChange() < minAngle)
        {
            transform.localEulerAngles = minRotation;
            return;
        }
        if (initialLocalEulerAngles.z + MouseAngleChange() > maxAngle)
        {
            transform.localEulerAngles = maxRotation;
            return;
        }

        transform.localEulerAngles = initialLocalEulerAngles + new Vector3(0, 0, MouseAngleChange());
    }

    private void OnMouseDown()
    {
        initialRelMousePos = RelativeMousePosition();
        initialLocalEulerAngles = transform.localEulerAngles;
    }

    private void OnMouseDrag()
    {
        RotateDial();
        Highlight();
        SetDialSetting();
        SetPowerSetting();
    }

    private void OnMouseEnter()
    {
        Highlight();
    }
    private void OnMouseExit()
    {
        UnHighlight();
    }
    private void OnMouseUp()
    {
        UnHighlight();
    }
    private void SetDialSetting()
    {
        float powerRange = maxDialSetting - minDialSetting;
        float dialRange = maxAngle - minAngle;
        float dialScalar = powerRange / dialRange;
        DialSetting = (transform.localEulerAngles.z - minAngle) * dialScalar;
        //Debug.Log($"Current Rotation: {transform.localEulerAngles.z} Power Setting: {DialSetting}");
    }

    private void SetPowerSetting()
    {
        powerRegulatorScript.PowerSetting = DialSetting;
    }
}
