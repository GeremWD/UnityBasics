using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPressurePlate : MonoBehaviour
{
    private GameObject player;
    private BossManager bossManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject boss = GameObject.Find("Boss");
        bossManager = boss.transform.GetComponentInChildren<BossManager>();
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            bossManager.realStart();
        }
    }
}
