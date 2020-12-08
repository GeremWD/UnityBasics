using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public DoorOpener opener;
    private GameObject player;

    void start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.parent == player)
        {
            CancelInvoke();
            opener.setState(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.parent == player) 
        {
            Invoke("close", 1.5f);
        }
    }

    void close()
    {
        opener.setState(false);
    }
}
