using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTextScript : MonoBehaviour
{

    public Text speedText;
    private int speedNum;

    // Start is called before the first frame update
    void Start()
    {
        speedText.text = MasterSpeed.SpeedControl.ToString();
        speedNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speedNum++;
        UpdateSpeedText();
    }

    void UpdateSpeedText()
    {
        speedText.text = speedNum.ToString();
    }
}
