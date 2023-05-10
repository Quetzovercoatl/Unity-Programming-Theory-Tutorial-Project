using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPointScript : MonoBehaviour
{
    public bool IsSnapPoint { get; private set; } = true;
    protected Renderer[] renderers;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
  
    public IEnumerator HighlightSnapPoint()
    {
        foreach (var renderer in renderers)
        {
            renderer.material.EnableKeyword("_EMISSION");
        }
        yield return new WaitForEndOfFrame();

        foreach (var renderer in renderers)
        {
            renderer.material.DisableKeyword("_EMISSION");
        }
    }

}
