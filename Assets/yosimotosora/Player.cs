using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Life=3;//�̗�
    public float PleyreSpeed=5;//�d�͔��]���x
    public float Nameraka=0.5f;//�ŏ���PleyreSpeed�̊���
    public GameObject gool;//�ړI�n
    public float distance=0.0f;
    public float dist=0.0f;
    public float start;//�����̈ʒu
    private bool moveFlg;//�ړ����Ă��邩�m�F
    private float t;//�C�[�W���N�Ɏg���ϐ�
    public Slider HPSlider;//�̗̓o�[
    public int Kaisuu = 1;//�d�͔��]����
    public int Kanou = 1;//��]�\��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator kaiten(int ja)
    {
        Kanou--;

        yield return new WaitForSeconds(1);
            if (ja == 1)//��ɉ�]
            {
             
                transform.rotation = Quaternion.Euler(180, 0, 0);//�p�x�ύX
                Kaisuu++;
            }
            else if (ja == 2)//���ɉ�]
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);//�p�x�ύX
                Kaisuu--;
            }
        
        

        
    }
    void MoveUpdate()
    {
        HPSlider.value = Life;//�̗͂�UI�i�̗̓o�[�j
        if (!moveFlg)
            return;

        dist = gool.transform.position.y - start;//player_main�̂��̍��W�[�ŏ��̈ʒu�ŋ���������
        t += Time.deltaTime*PleyreSpeed* Nameraka;//���b�X�V�@�v���C���[�̑���
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
            //SceneManager.LoadScene("�Q�[���I�[�o�[�V�[���̖��O");//�Q�[���I�[�o�[�V�[���ǂݍ���
        }
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
        if (Input.GetKeyDown(KeyCode.Space)&&Kanou == 1)//��]���s��
        {
            //StartCoroutine(kaiten());
        }
        MoveUpdate();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//�G�ɓ���������
        {
            Life--;//�̗͂�����
        }
        if (collision.gameObject.tag == "Ground")//�G�ɓ���������
        {
            Kanou = 1;//��]�\��
        }
    }
}
