using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsUI : MonoBehaviour
{

    float countDownTimer = 10f;
    bool startCountDown = true;
    public Text timer;
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (startCountDown)
        {
            countDownTimer -= Time.deltaTime;
        }

        timer.text = ((int)countDownTimer).ToString();

        if (countDownTimer <= 0)
        {
            monster.SetActive(true);
            countDownTimer = 10f;
            gameObject.SetActive(false);
        }
    }
}
