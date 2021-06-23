using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dustParticle;
    bool showDustEffect = false ;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showDustEffect)
        {
            dustParticle.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                timer = 0;
                dustParticle.SetActive(false);
                showDustEffect = false;
            }
        }
    }

 

    public void ShowDustEffect()
    {
        showDustEffect = true;
    }
 
}
