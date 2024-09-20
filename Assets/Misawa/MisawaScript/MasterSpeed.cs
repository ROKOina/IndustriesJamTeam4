using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSpeed : MonoBehaviour
{
    public AudioClip sound01;
    public AudioClip sound02;
    AudioSource audioa;
    public static float SpeedControl;
    // Start is called before the first frame update
    void Start()
    {
        SpeedControl = 0;
        audioa = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}

