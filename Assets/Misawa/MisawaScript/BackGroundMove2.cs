using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove2 : MonoBehaviour
{
    private float speed = 1;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed+ MasterSpeed.SpeedControl, 0f);

        if (transform.position.x <= -19.2)
        {
            transform.position += new Vector3(38.4f, 0f);
        }
    }
}