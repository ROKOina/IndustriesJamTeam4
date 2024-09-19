using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurScript : MonoBehaviour
{
    public float v;
    Plyere_main pl;
    public float power = 13;
    private bool blurS = false;
    private float timer;
    public float speed = 5;
    private Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.Find("Plyere_main").GetComponent<Plyere_main>();
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pl.Kaisuu == 1)
            {
                blurS = true;
                timer = 0;
            }
        }

        if (blurS)
        {
            timer += Time.deltaTime * speed;
            if (timer > Mathf.PI)
            {
                blurS = false;
                timer = 0;
            }
            if (timer < Mathf.PI / 2)
            {
                v = Easing.QuartIn(timer / (Mathf.PI/2), 1, 0, 1) * power;
                ren.material.SetFloat("_Blur", Easing.CubicIn(timer / (Mathf.PI / 2), 1, 0, 1) * power);
            }
            else
            {
                v = Easing.CubicIn(Mathf.PI - timer, 1, 0, 1) * power;
                ren.material.SetFloat("_Blur", Easing.QuintOut(Mathf.PI - timer, 1, 0, 1) * power);
            }
        }
    }
}