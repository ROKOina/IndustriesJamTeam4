using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemySpownScript : MonoBehaviour
{
    //���V�G�l�~�[��PosY�̒萔
    public const float FLYING_ENEMY_POSY = -0.0909f;

    //�m�[�}���G�l�~�[�i���j��PosY�̒萔
    public const float BOTTOM_ENEMY_POSY = -4.027788f;

    //�m�[�}���G�l�~�[�i��j��PosY�̒萔
    public const float TOP_ENEMY_POSY = 2.804868f;

    private bool isReverse = false;

    //1��Bottom1,
    //2��Top1
    //3��Bottom3,
    private float[] floats = new float[3];

    private float totalDistance = 0.0f;

    public GameObject[] enemies;

    //mapspeed
    private float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        floats[0] = transform.Find("SpownBottom1").transform.position.x;
        floats[1] = transform.Find("SpownTop1").transform.position.x;
        floats[2] = transform.Find("SpownBottom2").transform.position.x;
        isReverse = false;
        totalDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        totalDistance += Time.deltaTime * speed + MasterSpeed.SpeedControl;
        if (totalDistance > 19.2f)
        //if (totalDistance > Screen.width)
        {
            Instantiate(enemies[0], new Vector3(floats[0]+19.2f, BOTTOM_ENEMY_POSY,0), Quaternion.identity);
            totalDistance = 0;
        }
    }
    



}
