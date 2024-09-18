using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnconventionalMovingEnemyMove : MonoBehaviour
{
    

    //�ړ����x�iMoveSpeed�͔w�i�̑��x�Ɠ��l�j
    [SerializeField] float MoveSpeed = -5.0f; //���ő��x�����߂Ă���
    [SerializeField] float OwnSpeedX = -5.0f; //���̃I�u�W�F�N�g�����ŗL�̑��x
    [SerializeField] float OwnSpeedY = 3.0f; //���̃I�u�W�F�N�g�����ŗL�̑��x

    float temp = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�����
        Vector2 position = transform.position;

        position.x = position.x + (MoveSpeed + OwnSpeedX) * Time.deltaTime;

        position.y = position.y + Mathf.Cos(temp) * OwnSpeedY * Time.deltaTime;

        temp += Time.deltaTime * 3;
        transform.position = position;

        //��ʒ[���߂����玩����j������
        const int correction = -3; //��ʒ[�̍��W���炩�����
        if(transform.position.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x + correction)
        {
            Destroy(this.gameObject);
        }
    }
}
