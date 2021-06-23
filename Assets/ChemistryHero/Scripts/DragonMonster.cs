using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMonster : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    int timeToAttack = 7;
    float currentTimer = 0;
    bool attack = false;
    bool startCombat = false;
    public Transform groundLevel;
    public Transform airLevel;
    bool lift = false;
    bool drop = false;
    public GameObject fireBall;
    bool shootFireBall = false;
    public Transform playerTarget;
    public Transform fireBallStartPosition;
    float delayInShooting = 0f;
    bool activateShootingTrigger = false;

    void Start()
    {
        StartCoroutine("PrepareToLift");   
    }

    // Update is called once per frame
    void Update()
    {
        if (lift)
        {
            LiftOff();
        }

        if (drop)
        {
            TakeDown();
        }

        currentTimer += Time.deltaTime;
        if (currentTimer >= timeToAttack)
        {
            attack = true;
            currentTimer = 0;
        }

        if (attack)
        {
            if (!activateShootingTrigger)
            {
                animator.SetTrigger("Attack");
                activateShootingTrigger = true;
            }
            
            activateShootingTrigger = true;
            delayInShooting += Time.deltaTime;
            if (delayInShooting >= 1f)
            {
                delayInShooting = 0f;
                shootFireBall = true;
                attack = false;
                activateShootingTrigger = false;
            }
          
        }

        if (shootFireBall)
        {

            fireBall.SetActive(true);
            if (fireBall.transform.position != playerTarget.position)
            {
                fireBall.transform.position = Vector3.Lerp(fireBall.transform.position, playerTarget.position, 2 * Time.deltaTime);
            }
           /* else
            {
                shootFireBall = false;
                fireBall.transform.position = fireBallStartPosition.position;
                fireBall.SetActive(false);
            } */
        }
    }


    void LiftOff()
    {
        if (transform.position != airLevel.position)
        {
            transform.position = Vector3.Lerp(transform.position, airLevel.position, 2 * Time.deltaTime);
        }
        else
        {
            lift = false;
        }
    }

    void TakeDown()
    {
        if (transform.position != groundLevel.position)
        {
            transform.position = Vector3.Lerp(transform.position, groundLevel.position, 2 * Time.deltaTime);
        }
        else
        {
            drop = false;
        }
    }


    IEnumerator PrepareToLift()
    {

        yield return new WaitForSeconds(1.5f);
        lift = true;
 
        yield return new WaitForSeconds(2f);
        startCombat = true;

    }

  

    public void StopFireBall()
    {
        shootFireBall = false;
        fireBall.transform.position = fireBallStartPosition.position;
        fireBall.SetActive(false);
    }

}
