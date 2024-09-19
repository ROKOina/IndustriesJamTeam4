using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] Plyere_main Player_Main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //相手のレイヤーを確認する
        string LayerName = LayerMask.LayerToName(collision.gameObject.layer);
        if(LayerName == "EnemyAttack")
        {
            //衝突した時の処理
            //Destroy(Player_Main.gameObject);
            //Destroy(gameObject.transform.root.gameObject);
            Destroy(collision.gameObject.transform.root.gameObject);
        }
    }
}
