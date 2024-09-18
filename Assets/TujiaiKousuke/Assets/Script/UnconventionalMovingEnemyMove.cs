using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnconventionalMovingEnemyMove : MonoBehaviour
{
    

    //移動速度（MoveSpeedは背景の速度と同値）
    [SerializeField] float MoveSpeed = -5.0f; //仮で速度を決めておく
    [SerializeField] float OwnSpeedX = -5.0f; //このオブジェクトが持つ固有の速度
    [SerializeField] float OwnSpeedY = 3.0f; //このオブジェクトが持つ固有の速度

    float temp = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Vector2 position = transform.position;

        position.x = position.x + (MoveSpeed + OwnSpeedX) * Time.deltaTime;

        position.y = position.y + Mathf.Cos(temp) * OwnSpeedY * Time.deltaTime;

        temp += Time.deltaTime * 3;
        transform.position = position;

        //画面端を過ぎたら自分を破棄する
        const int correction = -3; //画面端の座標からから引く
        if(transform.position.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x + correction)
        {
            Destroy(this.gameObject);
        }
    }
}
