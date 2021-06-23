using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public DragonMonster dragonMonster;
    public AudioManagerCombat audioManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            PlayerShield playerShield = hit.gameObject.GetComponent<PlayerShield>();
            audioManager.PlayExplodingSound();
            playerShield.ShowDustEffect();
            dragonMonster.StopFireBall();

        }
    }
}
