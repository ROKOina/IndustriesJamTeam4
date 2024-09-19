using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Life=3;//体力
    public float PleyreSpeed=5;//重力反転速度
    public float Nameraka=0.5f;//最初のPleyreSpeedの割合
    public GameObject gool;//目的地
    public float distance=0.0f;
    public float dist=0.0f;
    public float start;//自分の位置
    private bool moveFlg;//移動しているか確認
    private float t;//イージンクに使う変数
    public Slider HPSlider;//体力バー

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveUpdate()
    {
        HPSlider.value = Life;
        if (!moveFlg)
            return;

        dist = gool.transform.position.y - start;//player_mainのｙの座標ー最初の位置で距離をだす
        t += Time.deltaTime*PleyreSpeed* Nameraka;//毎秒更新　プレイヤーの速さ
        if (t >= 0.5f)
        {
            t += Time.deltaTime *math.pow(PleyreSpeed,3);
        }
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
        if (Life == 0)
        {
            //SceneManager.LoadScene("ゲームオーバーシーンの名前");//ゲームオーバーシーン読み込む
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//敵に当たった時
        {
            Life--;//体力が減る
        }
    }
}
