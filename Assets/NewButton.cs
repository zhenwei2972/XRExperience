using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewButton : MonoBehaviour
{
    private const float _maxDistance = 90;
    private GameObject _gazedAtObject = null;
    private bool start = false;
    private bool exit = false;

    // Use this for initialization
    void Start()
    {

    }

    void update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;
                if (hit.transform.gameObject.CompareTag("StartGame"))
                {
                    Debug.Log("Start");
                    //start = true;
                    //exit = false;

                }
                else if (hit.transform.gameObject.CompareTag("Exit"))
                {
                    Debug.Log("Exit");
                   // start = false;
                   // exit = true;
                }
            }

        }
        else
        {
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            //_gazedAtObject?.SendMessage("OnPointerClick");
            if (start)
            {
                SceneManager.LoadScene("Lab 1");
            }
            else if (exit)
            {
                Application.Quit();
            }
        }

    }
}