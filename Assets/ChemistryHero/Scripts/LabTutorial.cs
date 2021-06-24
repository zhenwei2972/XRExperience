using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] tutText;
    public bool[] isAuto;
    public int currentIndex;
    public Text uiText;
    float countDownTimer = 5;
    bool startCounting = false;

    void Start()
    {
        currentIndex = 0;
        uiText.text = tutText[currentIndex];
        CheckIfAuto();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)){
            IncrementNext();
        }

        if (startCounting)
        {
            countDownTimer -= Time.deltaTime;
            if (countDownTimer <= 0)
            {
                startCounting = false;
                countDownTimer = 5;
                IncrementNext();
            }
        }
    }

    public void IncrementNext()
    {
        currentIndex++;
        if (currentIndex < tutText.Length)
        {
            SetTutText();
            CheckIfAuto();
        }
        else
        {
            print("End");
        }
       
    }

    
    public void SetTutText()
    {
        uiText.text = tutText[currentIndex];
    }

    public void CheckIfAuto()
    {
        if (isAuto[currentIndex]) //If current index is auto transition
        {
            startCounting = true;
        }
    }





}
