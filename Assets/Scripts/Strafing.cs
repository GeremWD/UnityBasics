using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strafing : MonoBehaviour
{
    public float speed;
    public float strafingDistance;  
    private bool right = true;
    private Vector3 rightPoint, leftPoint, target, direction;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rightPoint = transform.position + (strafingDistance / 2) * transform.right;
        leftPoint = transform.position - (strafingDistance / 2) * transform.right;
        direction = transform.right;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(target - transform.position, direction) < 0) 
            switchDirection();
        rb.velocity = speed * direction;
    }

    void switchDirection()
    {
        if(right)
        {
            right = false;
            direction = -transform.right;
            target = leftPoint;
        } else
        {
            right = true;
            direction = transform.right;
            target = rightPoint;
        }
    }
}
