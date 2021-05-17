using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Touch touch;
    private float speed;
    private void Start()
    {
        speed = 0.1f;
    }
    private void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase==TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                                               transform.position.y,
                                                transform.position.z);
            }
        }
    }
}
