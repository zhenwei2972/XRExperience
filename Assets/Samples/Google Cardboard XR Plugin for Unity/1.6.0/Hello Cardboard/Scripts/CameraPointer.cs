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
using UnityEngine.SceneManagement;
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
    //public Transform loadingBarPos;
    public GameObject LoadingBarObject;
    public Image LoadingBar;
    float currentValue=0;
    public float speed;
    public bool startRadial = false;
    bool isCounting = false;
    MovingScript lastTestTube = null;

    //new ui stuff
    private bool start = false;
    private bool exit = false;
    public Animator transition;
    public float transitionTime = 1f;
    public bool mainMenu = false;
    public bool tutorialLab1Page = false;
    bool activateTut1 = false;
    public LabTutorial labTut;
    bool activateTut3 = false;

    private bool confirm = false;
    private bool yesBool = false;
    private bool noBool = false;
    public GameObject comfirmationUI;
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
            Debug.DrawRay(transform.position, transform.forward, Color.green, _maxDistance);

            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;
              
                _gazedAtObject?.SendMessage("OnPointerEnter");

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
               // Destroy(lastTestTube);
            }
            //control radial 
            if (!mainMenu)  //NOT MAIN MENU
            {
                if (hit.transform.gameObject.CompareTag("PortalCombat"))
                {
                    Debug.Log("combat");
                    confirm = true;
                }

                if (_gazedAtObject.CompareTag("testtube"))
                {
                    if (tutorialLab1Page)
                    {
                        {
                            if (!activateTut1)
                            {
                                activateTut1 = true;
                                labTut.IncrementNext();
                            }
                            else if (_gazedAtObject.name == "Sodium")
                            {
                                if (!activateTut3)
                                {
                                    activateTut3 = true;
                                    labTut.IncrementNext();
                                }
                            }
                        }
                    }
                   

                    lastTestTube = _gazedAtObject.GetComponent<MovingScript>();
                }


                if (startRadial)
                {

                    if (currentValue < 100)
                    {

                        currentValue += speed * Time.deltaTime;

                    }
                    if (LoadingBar.fillAmount == 1)
                    {
                        //  lastTestTube?.SendMessage("ResetLerp");
                        // print(lastTestTube);
                        lastTestTube.ResetLerp();

                        Debug.Log("successfully send Lerp");
                    }
                    LoadingBar.fillAmount = currentValue / 100;
                }

                if (_gazedAtObject.CompareTag("originalPos"))
                {

                    if (!isCounting)
                    {
                        LoadingBarObject.transform.position = _gazedAtObject.transform.position;
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

        }
        else
        {

            _gazedAtObject = null;
        }


        if (confirm)
        {
            Debug.Log("combat pass");
            comfirmationUI.SetActive(true);


            if (hit.transform.gameObject.CompareTag("yes"))
            {

                yesBool = true;
                noBool = false;
            }
            if (hit.transform.gameObject.CompareTag("no"))
            {

                noBool = true;
                yesBool = false;

            }
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            if (start)
            {
                //transition.SetTrigger("Start");
                //yield return new WaitForSeconds(transitionTime);
                print("load");
                SceneManager.LoadScene("Lab 1");
            }

            else if (exit)
            {
                Application.Quit();
            }
            _gazedAtObject?.SendMessage("OnPointerClick");


           //_gazedAtObject?.SendMessage("OnPointerClick");
              if (yesBool)
                {
                    SceneManager.LoadScene("Combat");
                }
                if (noBool)
                {
                    comfirmationUI.SetActive(false);
                    noBool = false;
                }

            }

            /*  if (Input.GetMouseButton(0))
              {
                  Debug.Log("pressing");
                  pourLiquid.StartPouring();
              }
            */




            //transition.SetTrigger("Start");
            //yield return new WaitForSeconds(transitionTime);




        }
}
