using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackGround : MonoBehaviour
{
    private float speed = 1;

    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed + MasterSpeed.SpeedControl, 0f);

        if (transform.position.x <= -25)
        {
            transform.position = new Vector3(39f, 0f);
        }
    }
}
