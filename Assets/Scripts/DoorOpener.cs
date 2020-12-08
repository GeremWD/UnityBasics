using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public float openingSpeed;
    public bool open = false;
    private Transform left, right;
    private Vector3 left_open_pos, left_closed_pos, right_open_pos, right_closed_pos;

    // Start is called before the first frame update
    void Start()
    {
        left = transform.Find("Door_Left");
        right = transform.Find("Door_Right");
        left_closed_pos = left.position;
        right_closed_pos = right.position;
        left_open_pos = left.position + 2 * transform.forward;
        right_open_pos = right.position - 2 * transform.forward;
    }

    public void setState(bool open)
    {
        this.open = open;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 left_target, right_target;
        if(open)
        {
            left_target = left_open_pos;
            right_target = right_open_pos;
        } else
        {
            left_target = left_closed_pos;
            right_target = right_closed_pos;
        }
        Vector3 move_left = (left_target - left.position).normalized * openingSpeed * Time.deltaTime;
        if (Vector3.Distance(left.position, left_target) >= move_left.magnitude)
        {
            left.position += move_left;
        } else
        {
            left.position = left_target;
        }
        Vector3 move_right = (right_target - right.position).normalized * openingSpeed * Time.deltaTime;
        if (Vector3.Distance(right.position, right_target) >= move_right.magnitude)
        {
            right.position += move_right;
        } else
        {
            right.position = right_target;
        }
    }
}
