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
using UnityEngine.UI;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 200;
    private GameObject _gazedAtObject = null;
    public float Health = 100f;
    public PourLiquid pourLiquid;

    //radial stuff
    public Image LoadingBar;
    float currentValue=0;
    public float speed;
    public bool startRadial = false;
    bool isCounting = false;
    MovingScript lastTestTube = null;
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    /// 


    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
     
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);

            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;
               if(_gazedAtObject.CompareTag("testtube"))
                {
      
                    lastTestTube = _gazedAtObject.GetComponent<MovingScript>();
                    print("zul is:"  + lastTestTube);
                }
                _gazedAtObject?.SendMessage("OnPointerEnter");

            }
            if(_gazedAtObject.tag == "rubbish")
            {
               // Destroy(lastTestTube);
            }
            //control radial 

            if (startRadial)
            {
                if (currentValue < 100)
                {
                    currentValue += speed * Time.deltaTime;

                }
                if ( LoadingBar.fillAmount==1)
                {
                    //  lastTestTube?.SendMessage("ResetLerp");
                    print(lastTestTube);
                    lastTestTube.ResetLerp();

                    Debug.Log("successfully send Lerp");
                }
                LoadingBar.fillAmount = currentValue / 100;
            }

            if(_gazedAtObject.CompareTag("originalPos"))
            {
              
                if (!isCounting)
                {
                    currentValue = 0;
                    isCounting = true;
                    startRadial = true;
                }

                print("looking");
            }
            else
            {
                isCounting = false;
                LoadingBar.fillAmount = 0;
                startRadial = false;
                print("not looking");
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

      /*  if (Input.GetMouseButton(0))
        {
            Debug.Log("pressing");
            pourLiquid.StartPouring();
        }
      */
        if (Input.touchCount > 0)
        {
            Touch first = Input.GetTouch(0);
            if (first.phase == TouchPhase.Stationary)
            {
                Debug.Log("pressing");
                pourLiquid.StartPouring();
            }
        }

    }
}
