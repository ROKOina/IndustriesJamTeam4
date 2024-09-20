using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificSpawner : MonoBehaviour
{
    public GameObject[] bulletPrefabs;   // 弾のPrefab（3種類の弾）
    public Transform[] spawners;         // スポナーの位置（3か所）
    public float spawnInterval = 1f;     // 弾を発射する間隔（秒）

    private void Start()
    {
        // 弾を定期的に発射するコルーチンを開始
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        while (true)
        {
            // ランダムに1つのスポナーを選択
            int randomIndex = Random.Range(0, spawners.Length);

            // 選択されたスポナーから特定の弾を発射

            //スタートしている時
            if (StartCameraAnimation.isStart)
                Instantiate(bulletPrefabs[randomIndex], spawners[randomIndex].position, spawners[randomIndex].rotation);

            // 次の発射まで待機
            yield return new WaitForSeconds(spawnInterval+(MasterSpeed.SpeedControl/10));
        }
    }
}