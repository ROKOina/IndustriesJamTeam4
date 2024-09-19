using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCllider : MonoBehaviour
{

    //static Vector2 prePosition;
    float EnemyPositionX;
    float PlayerPositionX;
    GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
       // prePosition = transform.position;
        PlayerPositionX = transform.position.x + gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f + -0.1f;
    }

    private void Update()
    {
        //if(HitJudge)
        //{
        //    if(PlayerPositionX > EnemyPositionX)
        //    { //敵を踏んだ時
        //        Destroy(Enemy.transform.root.gameObject);
        //    }
        //    else
        //    { //敵に当たった時
        //        //Destroy(Enemy.transform.root.gameObject);
        //        Debug.Log("sinda");
        //    }
        //    HitJudge = false;
        //}

        //prePosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        { //当たった相手が敵だった時

            EnemyPositionX = collision.transform.position.x
                - collision.gameObject.GetComponent<BoxCollider2D>().size.x*0.5f;

            //PlayerPositionX = transform.position.x + gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f;

            if (PlayerPositionX > EnemyPositionX+0.1f)
            {
                Destroy(collision.transform.root.gameObject);
            }
            else
            {
                Destroy(collision.transform.root.gameObject);
                
            }
              
            Enemy = collision.gameObject;
        }
    }
}
