using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Vector2 prePosition; //��O�̃t���[���ł̎��@�̈ʒu

    // Start is called before the first frame update
    void Start()
    {
        prePosition = transform.position;
    }

    private void Update()
    {


        prePosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ////����̃��C���[���m�F����
        string LayerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (LayerName == "EnemyWeakPoint")
        {
            //�Փ˂������̏���
            Destroy(collision.transform.root.gameObject);
        }
    }
}


