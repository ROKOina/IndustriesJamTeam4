using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Vector2 prePosition; //一個前のフレームでの自機の位置

    // Start is called before the first frame update
    void Start()
    {
        prePosition = transform.position;
    }

    private void Update()
    {


        prePosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ////相手のレイヤーを確認する
        string LayerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (LayerName == "EnemyWeakPoint")
        {
            //衝突した時の処理
            Destroy(collision.transform.root.gameObject);
        }
    }
}


