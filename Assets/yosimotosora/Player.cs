using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float PleyreSpeed=5;//�d�͔��]���x
    public GameObject gool;//�ړI�n
    public float distance=0.0f;
    public float dist=0.0f;
    public float start;//�����̈ʒu
    private bool moveFlg;//�ړ����Ă��邩�m�F
    private float t;//�C�[�W���N�Ɏg���ϐ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveUpdate()
    {
    
        if (!moveFlg)
            return;

        dist = gool.transform.position.y - start;//player_main�̂��̍��W�[�ŏ��̈ʒu�ŋ���������
        t += Time.deltaTime*PleyreSpeed;//���b�X�V�@�v���C���[�̑���
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
      
        distance = gool.transform.position.y - transform.position.y;//gool�̂��̍��W�Ǝ����̃I�u�W�F�N�g�̂�
        if (distance*distance>=1&&moveFlg==false) 
        {
            t = 0;
            moveFlg = true;
            start = transform.position.y;
            //transform.Translate(new Vector3(0, PleyreSpeed, 0) * Time.deltaTime);
            //Vector3 kaudou = gool.transform.position - transform.position;//�p�x�擾
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, kaudou);//�p�x�ύX
        }
        MoveUpdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//�G�ɓ���������
        {
      
        }
    }
}
