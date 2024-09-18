using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plyere : MonoBehaviour
{
    public float PleyreSpeed=5;//重力反転速度
    public GameObject gool;//目的地
    public float distance=0.0f;
    public Vector3 Offset = Vector3.zero;
    public float dist=0.0f;
    public float start;//自分の位置
    private bool moveFlg;//移動しているか確認
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveUpdate()
    {
        if (!moveFlg)
            return;

        dist = gool.transform.position.y - start;//player_mainのｙの座標ー最初の位置で距離をだす
        t += Time.deltaTime*0.5f;//毎秒更新
        if (t >= 1)
        {
            t = 1;
            moveFlg = false;
        }
        float a = Easing.BackIn(t, 1, 0, 1, 1);

        float iti = a * dist;
        transform.position = (new Vector2(transform.position.x, start + iti));
    }

    // Update is called once per frame
    void Update()
    {
        distance = gool.transform.position.y - transform.position.y;//goolのｙの座標と自分のオブジェクトのｙ
        if (distance*distance>=1&&moveFlg==false) 
        {
            t = 0;
            moveFlg = true;
            start = transform.position.y;
            //transform.Translate(new Vector3(0, PleyreSpeed, 0) * Time.deltaTime);
            //Vector3 kaudou = gool.transform.position - transform.position;//角度取得
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, kaudou);//角度変更
        }


        MoveUpdate();
        

    }
}
