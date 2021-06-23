using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject prefabButton;
    public RectTransform ParentPanel;

   // Use this for initialization
    void Start () {


    }
 
    void update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F))
        {
            if (hit.transform.tag == "StartGame")
            {   // ur in 100 meters of the object
                Debug.Log("Start");
            }
            else if (hit.transform.tag == "Exit")
            {
                Debug.Log("Exit");
            }
        }
    } 
}
