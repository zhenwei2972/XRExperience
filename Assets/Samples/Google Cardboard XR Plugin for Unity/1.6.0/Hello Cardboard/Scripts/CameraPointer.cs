//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 200;
    private GameObject _gazedAtObject = null;
    public float Health = 100f;
    private bool start = false;
    private bool exit = false;
    public Animator transition;
    public float transitionTime = 1f;
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    /// 

    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        GameObject currentTestTube = null;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green, _maxDistance);
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;
                //              _gazedAtObject?.SendMessage("OnPointerEnter");

                if (hit.transform.gameObject.CompareTag("StartGame"))
                {
                    Debug.Log("Start");
                    start = true;
                    exit = false;

                }
                else if (hit.transform.gameObject.CompareTag("Exit"))
                {
                    Debug.Log("Exit");
                    start = false;
                    exit = true;
                }

            }
            if(_gazedAtObject.tag == "rubbish")
            {
                Destroy(currentTestTube);
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
                //transition.SetTrigger("Start");
                //yield return new WaitForSeconds(transitionTime);
                SceneManager.LoadScene("Lab 1");
            }
            else if (exit)
            {
                Application.Quit();
            }
        }
    }
}
