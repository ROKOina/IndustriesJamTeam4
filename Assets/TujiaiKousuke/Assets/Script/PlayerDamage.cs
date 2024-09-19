using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] Plyere_main Player_Main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string LayerName = LayerMask.LayerToName(collision.gameObject.layer);
        if(LayerName == "EnemyAttack")
        {
            Destroy(Player_Main.gameObject);
            Destroy(gameObject.transform.root.gameObject);
        }
    }
}
