using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AllScore : MonoBehaviour
{
    static public float tokuten=0;
    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = (tokuten).ToString("F0");
    }
}
