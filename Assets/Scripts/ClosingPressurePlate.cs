using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClosingPressurePlate : MonoBehaviour
{
    public DoorOpener opener;
    private GameObject player;

    void start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.parent == player)
        {
            opener.setState(false);
        }
    }
}

