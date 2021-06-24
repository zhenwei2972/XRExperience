using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwtestube : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform endPos;
    bool throwTube = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (throwTube)
        {
            if (transform.position != endPos.position)
            {
                transform.position = Vector3.Lerp(transform.position, endPos.position, 1 * Time.deltaTime);
                print("lalala");
            }
        }


    


    }

    public void CanThrow()
    {
        throwTube = true;
    }
}
