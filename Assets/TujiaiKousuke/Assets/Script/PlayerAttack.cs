using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string LayerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (LayerName == "EnemyWeakPoint")
        {
            Destroy(collision.transform.root.gameObject);
            
        }
    }
}


