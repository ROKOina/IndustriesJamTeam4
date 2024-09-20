using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalCameraPos;

    private void Start()
    {
        // �J�����̈ʒu���擾
        originalCameraPos = new Vector3(0, 0, -10);   //�Œ�Ȃ̂�
        //originalCameraPos = Camera.main.transform.position;
    }

    public void Shake()
    {
        StartCoroutine("CameraShakeIE");
    }

    IEnumerator CameraShakeIE()
    {
        // �J������h�炷
        for (int i = 0; i < 10; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;
            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCameraPos.z);
            yield return new WaitForSeconds(0.1f);
        }

        // �J���������̈ʒu�ɖ߂�
        Camera.main.transform.position = originalCameraPos;
    }
}
