using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove1 : MonoBehaviour
{
    public float speed = 2;

    void Update()
    {
        //スタートしていない時
        if (!StartCameraAnimation.isStart) return;

        transform.position -= new Vector3(Time.deltaTime * (speed + MasterSpeed.SpeedControl), 0f);

        if (transform.position.x <= -19.2)
        {
            transform.position = new Vector3(38.4f, 0f);
        }
    }
}