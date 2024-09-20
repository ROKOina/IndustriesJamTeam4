using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalCameraPos;

    private void Start()
    {
        // カメラの位置を取得
        originalCameraPos = new Vector3(0, 0, -10);   //固定なので
        //originalCameraPos = Camera.main.transform.position;
    }

    public void Shake()
    {
        StartCoroutine("CameraShakeIE");
    }

    IEnumerator CameraShakeIE()
    {
        // カメラを揺らす
        for (int i = 0; i < 10; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;
            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCameraPos.z);
            yield return new WaitForSeconds(0.1f);
        }

        // カメラを元の位置に戻す
        Camera.main.transform.position = originalCameraPos;
    }
}
