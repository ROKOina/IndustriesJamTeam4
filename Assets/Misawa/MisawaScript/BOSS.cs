using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    // �o�ߎ��Ԃ̌v���p
    private float elapsedTime = 0f;
    // ���Z����Ԋu�i10�b�j
    private float interval = 10f;
    public bool flag;

    static public float speed =1.0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;  
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // �o�ߎ��Ԃ��ݒ肵���Ԋu�𒴂�����
        if (elapsedTime >= interval)
        {
            // �J�E���g�𑝉�
            speed -= 1f;
            Debug.Log(speed);

            // �o�ߎ��Ԃ����Z�b�g
            elapsedTime = 0f;
        }
        transform.position += new Vector3((-speed-MasterSpeed.SpeedControl )* Time.deltaTime, 0, 0);
    }
}
