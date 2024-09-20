using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStert : MonoBehaviour
{
    GlitchFx GliScript;
    public float Gliver = 0;
    public bool GoCameraAnim = false; //かめらアニメーション
    // Start is called before the first frame update
    void Start()
    {
        Gliver = 1f;
        GliScript = GameObject.Find("Main Camera").GetComponent<GlitchFx>();
    }

    // Update is called once per frame
    void Update()
    {
        GliScript.intensity = Gliver;
        if (Gliver >= 0)
        {
            Gliver -= 0.01f;
        }
        else
        {
            GoCameraAnim = true;
        }

        
    }
}
