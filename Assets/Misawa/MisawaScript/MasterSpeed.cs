using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSpeed : MonoBehaviour
{
    public static float SpeedControl;
    // Start is called before the first frame update
    void Start()
    {
        SpeedControl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            SpeedControl +=0.0001f;
        }
        if (Input.GetKey(KeyCode.B))
        {
            SpeedControl =0f;
        }
    }
}

