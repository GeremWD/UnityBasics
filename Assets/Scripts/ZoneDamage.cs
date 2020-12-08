using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDamage : MonoBehaviour
{
    public float damagePerSecond;

    private GameObject player;
    private PlayerManager playerManager;
    private bool isHurting = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHurting)
        {
            playerManager.hurt(damagePerSecond*Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            isHurting = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == player)
        {
            isHurting = false;
        }
    }
}
