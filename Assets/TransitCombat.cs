using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class TransitCombat : MonoBehaviour
{
    private const float _maxDistance = 90;
    private GameObject _gazedAtObject = null;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    /// 

    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        //GameObject currentTestTube = null;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;
                if (hit.transform.gameObject.CompareTag("PortalCombat"))
                {
                    //currentTestTube = _gazedAtObject;
                    _gazedAtObject?.SendMessage("OnPointerEnter");
                }
            }
            if (_gazedAtObject.tag == "rubbish")
            {
                //Destroy(currentTestTube);
            }
        }
        else
        {

            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }
}
