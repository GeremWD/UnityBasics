using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public Follow followScript;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            followScript.startFollow();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == player)
        {
            followScript.stopFollow();
        }
    }
}
