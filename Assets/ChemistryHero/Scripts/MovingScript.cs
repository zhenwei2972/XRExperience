using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public bool selected = false;
    public bool clicked = false;
    public bool holdingTesttube = false;
    [SerializeField] private Vector3 pointA = new Vector3(0, -2, 0);
    [SerializeField] private Vector3 pointB = new Vector3(0, 2, 0);
    private float speed = 0.5f;
    private float t;
    public GameObject cameraPosition;
    Transform tempTrans;
    public float turningRate = 110f;
    public bool exit = false;
    public GameObject chemicalReactionhandler;
    public float rotateAmount = -165;
    // Rotation we should blend towards.
    private Quaternion _targetRotation = Quaternion.identity;
    public GameObject startPos;
    public bool resetLerp = false;
    public PourLiquid pourLiquid;

    // Call this when you want to turn the object smoothly.
    public void SetBlendedEulerAngles(Vector3 angles)
    {
        _targetRotation = Quaternion.Euler(angles);
    }
    // Start is called before the first frame update
    void exitpointer()
    {
        selected = false;
        exit = true;
        Debug.Log("exit");
    }
    private void Start()
    {
        pointA = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(selected==true)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPosition.transform.position, 2 * Time.deltaTime);
            // LerpMovement(pointA, pointB);
            //StartCoroutine(MoveBack(pointB,pointA));
            exit = true;

        }
        if (exit && clicked)
        { 
            Vector3 finalRotation = new Vector3(transform.position.x, transform.position.y, transform.position.z - rotateAmount);
            SetBlendedEulerAngles(finalRotation);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
            //Start the coroutine we define below named ExampleCoroutine.
            // StartCoroutine(DestroyTube());

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
        if(resetLerp)
        {
            Debug.Log("Reset the lerp");
            transform.position = Vector3.Lerp(transform.position, startPos.transform.position, 2 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, startPos.transform.rotation, 5 * Time.deltaTime);
           // SetBlendedEulerAngles(finalRotation);
        }
 
        // if want to dispose, look at rubbish bin. 
       
    }
   
    IEnumerator DestroyTube()
    {
        // call zul's code to give the name..
        chemicalReactionhandler.GetComponent<ChemicalReaction>().AddChemical(GetTag());
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(9);
        // destroy gameobject.
        Destroy(gameObject);
        

    }
    string GetTag()
    {
        return gameObject.tag;
    }
    void OnPointerEnter()
    {
        Debug.Log("selected");
        pointB = cameraPosition.transform.position;
        selected = true;
        
    }
    public void ResetLerp()
    {
        Debug.Log("send message reset success");
        resetLerp = true;
        selected = false;
        exit = false;
        clicked = false;
    }    
    void LerpMovement(Vector3 start, Vector3 end)
    {
        // move to camera
        t += Time.deltaTime * speed;
        // Moves the object up abit to indicate that it is selected.
        
          transform.position = Vector3.Lerp(start, end, Easing.Quadratic.In(t));
        
    }

    
    void OnPointerClick()
    {
        clicked = true;
        
    }
}
