using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour
{
    private float timer=3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //à⁄ìÆèàóù
        Vector2 position = transform.position;

        position.x = position.x + (-3 - MasterSpeed.SpeedControl) * Time.deltaTime;

        transform.position = position;

        timer -= Time.deltaTime;
        if (timer < 0) Destroy(this.gameObject);
    }
}
