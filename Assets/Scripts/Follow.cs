using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;
    public float stopDist;
    private Transform target;
    private Rigidbody rb;
    private bool shouldFollow = false;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldFollow)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 target_pos = target.position;
        target_pos.y = transform.position.y;
        transform.LookAt(target.position); //With this line the obj rotate
        if(Vector3.Distance(transform.position, target.position) >= stopDist)
        {
            rb.velocity = (target_pos - transform.position).normalized * speed;
        } else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void startFollow()
    {
        shouldFollow = true;
    }

    public void stopFollow()
    {
        shouldFollow = false;
    }
}
