using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    // 経過時間の計測用
    private float elapsedTime = 0f;
    // 加算する間隔（10秒）
    private float interval = 10f;

    float speed =1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // 経過時間が設定した間隔を超えたら
        if (elapsedTime >= interval)
        {
            // カウントを増加
            speed -= 0.5f;
            Debug.Log(speed);

            // 経過時間をリセット
            elapsedTime = 0f;
        }
        transform.position += new Vector3((-speed-MasterSpeed.SpeedControl )* Time.deltaTime, 0, 0);
    }
}
