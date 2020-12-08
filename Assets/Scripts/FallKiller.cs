using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallKiller : MonoBehaviour
{
    public GameObject respawn;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            player.transform.SetPositionAndRotation(respawn.transform.position, respawn.transform.rotation);
        }
    }
}
