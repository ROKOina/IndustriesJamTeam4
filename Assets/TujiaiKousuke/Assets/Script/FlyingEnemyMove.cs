using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : MonoBehaviour
{
    //移動速度（MoveSpeedは背景の速度と同値）
    [SerializeField] float MoveSpeed = -5.0f; //仮で速度を決めておく

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Vector2 position = transform.position;

        position.x = position.x + MasterSpeed.SpeedControl * Time.deltaTime;

        transform.position = position;

        //画面端を過ぎたら自分を破棄する
        const int correction = -3; //画面端の座標からから引く
        if (transform.position.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x + correction)
        {
            Destroy(this.gameObject);
        }
    }

}
