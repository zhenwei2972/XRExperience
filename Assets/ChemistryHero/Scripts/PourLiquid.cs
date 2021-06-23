using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourLiquid : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject liquid;
    Vector3 currentScale;
    public float scaleSpeed = 1;
    void Start()
    {
        currentScale = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartPouring();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            EmptyLiquid();
        }
    }

    public void StartPouring()
    {
        liquid.SetActive(true);
        if (liquid.transform.localScale.y <= 1)
            liquid.transform.localScale += currentScale * scaleSpeed * Time.deltaTime;
    }

    public void EmptyLiquid()
    {
        Vector3 newScale = new Vector3(1,0,1);
        liquid.SetActive(false);
        liquid.transform.localScale = newScale;

    }
}
