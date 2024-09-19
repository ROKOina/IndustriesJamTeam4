using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCllider : MonoBehaviour
{

    //static Vector2 prePosition;
    float EnemyPositionX;
    float PlayerPositionX;
    bool HitJudge;
    GameObject Enemy;
    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;
    public AudioClip sound04;
    AudioSource audioa;

    private float damageEffectValue = 0;
    public float dmgEffSpeed = 1;
    public float dmgEffPower = 1;
    private bool isDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        audioa = GetComponent<AudioSource>();
        // prePosition = transform.position;
        damageEffectValue = 0;
         HitJudge = false;
        PlayerPositionX = transform.position.x + gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f + -0.1f;
    }

    private void Update()
    {
        //if(HitJudge)
        //{
        //    if(PlayerPositionX > EnemyPositionX)
        //    { //�G�𓥂񂾎�
        //        Destroy(Enemy.transform.root.gameObject);
        //    }
        //    else
        //    { //�G�ɓ���������
        //        //Destroy(Enemy.transform.root.gameObject);
        //        Debug.Log("sinda");
        //    }
        //    HitJudge = false;
        //}

        //prePosition = transform.position;

        //�_���[�W���o
        if (isDamage)
        {
            damageEffectValue += Time.deltaTime * dmgEffSpeed;
            if (damageEffectValue > Mathf.PI)
            {
                isDamage = false;
                damageEffectValue = 0;
            }
            GameObject.Find("Main Camera").GetComponent<DamageEffect>().intensity = Mathf.Sin(damageEffectValue) * dmgEffPower;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        { //�����������肪�G��������
            HitJudge = true;

            float moveX = (-3 - MasterSpeed.SpeedControl) * Time.deltaTime;   //-3�͓G�̑��x�Œ�Ői�߂�
            EnemyPositionX = collision.transform.position.x
                - collision.gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f - moveX * 3;
            //PlayerPositionX = transform.position.x + gameObject.GetComponent<BoxCollider2D>().size.x * 0.5f;

            if (PlayerPositionX > EnemyPositionX)
            {
                MasterSpeed.SpeedControl+= 0.5f;
                Destroy(collision.transform.root.gameObject);
                AllScore.tokuten += 100;
                audioa.PlayOneShot(sound03);
                audioa.PlayOneShot(sound04);
                Debug.Log(MasterSpeed.SpeedControl);
            }
            else
            {
                Debug.Log("�Փ�");
                MasterSpeed.SpeedControl = 0f;
                //�_���[�W���o
                audioa.PlayOneShot(sound01);
                audioa.PlayOneShot(sound02);
                isDamage = true;
                damageEffectValue = 0;
            }
              
            Enemy = collision.gameObject;
        }
    }
}
