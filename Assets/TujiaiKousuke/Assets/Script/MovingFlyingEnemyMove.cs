using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlyingEnemyMove : MonoBehaviour
{
    //�ړ����x�iMoveSpeed�͔w�i�̑��x�Ɠ��l�j
    [SerializeField] float MoveSpeed = -5.0f; //���ő��x�����߂Ă���
    [SerializeField] float OwnSpeed = -5.0f; //���̃I�u�W�F�N�g�����ŗL�̑��x

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�����
        Vector2 position = transform.position;

        position.x = position.x + (MasterSpeed.SpeedControl + OwnSpeed) * Time.deltaTime;

        transform.position = position;

        //��ʒ[���߂����玩����j������
        const int correction = -3; //��ʒ[�̍��W���炩�����
        if (transform.position.x < Camera.main.ViewportToWorldPoint(Vector2.zero).x + correction)
        {
            Destroy(this.gameObject);
        }
    }
}
