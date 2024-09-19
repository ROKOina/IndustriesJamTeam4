using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Plyere_main : MonoBehaviour
{
    public float PleyrePosition = 5;//重力反転速度
    public int Kaisuu = 1;//重力反転制限
    public float distance = 0.0f;//プレイヤーとメインプレイヤーの距離
    public int Jouge = 0;//上下確認
    public GameObject Player;//プレイヤーオブジェクト
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        if (distance >= 0 && distance <= 0.5)
        {
            if (Kaisuu == 0)
            {
                Kaisuu++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Kaisuu == 1 && Jouge == 1)//上に移動
            {
                transform.Translate(new Vector3(0, PleyrePosition, 0));
                Jouge++;
                Kaisuu--;
            }
            else if (Kaisuu == 1 && Jouge == 2)//下に移動
            {
                transform.Translate(new Vector3(0, -PleyrePosition, 0));
                Jouge--;
                Kaisuu--;
            }
        }
    }
}
