using UnityEngine;


public class Plyere_main : MonoBehaviour
{
    public float PleyrePosition = 5;//�ړI�n��ݒ�
    public int Kaisuu = 1;//�d�͔��]����
    public float distance = 0.0f;//�v���C���[�ƃ��C���v���C���[�̋���
    public int Jouge = 0;//�㉺�m�F
    public GameObject Player;//�v���C���[�I�u�W�F�N�g
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim =  Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        if (distance >= 0 && distance <= 0.5)
        {
            if (Kaisuu == 0)
            {
                Kaisuu++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Kaisuu == 1 && Jouge == 1)//��Ɉړ�
            {
                transform.Translate(new Vector3(0, PleyrePosition, 0));
                Player.GetComponent<Player>().StartCoroutine(Player.GetComponent<Player>().kaiten(Jouge));
                Jouge++;
                Kaisuu--;
                anim.SetTrigger("NONE");
                anim.SetTrigger("Swap");
            }
            else if (Kaisuu == 1 && Jouge == 2)//���Ɉړ�
            {
                transform.Translate(new Vector3(0, -PleyrePosition, 0));
                Player.GetComponent<Player>().StartCoroutine(Player.GetComponent<Player>().kaiten(Jouge));
                Jouge--;
                Kaisuu--;
                anim.SetTrigger("NONE");
                anim.SetTrigger("Swap");
            }
        }
    }
}
