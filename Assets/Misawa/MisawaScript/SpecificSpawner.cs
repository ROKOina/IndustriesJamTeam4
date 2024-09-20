using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificSpawner : MonoBehaviour
{
    public GameObject[] bulletPrefabs;   // �e��Prefab�i3��ނ̒e�j
    public Transform[] spawners;         // �X�|�i�[�̈ʒu�i3�����j
    public float spawnInterval = 1f;     // �e�𔭎˂���Ԋu�i�b�j

    private bool isSpawan = false;

    private void Update()
    {

        //�X�^�[�g���Ă��鎞
        if (!StartCameraAnimation.isStart) return;
        if (isSpawan) return;

        // �e�����I�ɔ��˂���R���[�`�����J�n
        StartCoroutine(SpawnBullets());
        isSpawan = true;
    }

    private IEnumerator SpawnBullets()
    {
        while (true)
        {
            // �����_����1�̃X�|�i�[��I��
            int randomIndex = Random.Range(0, spawners.Length);

            // �I�����ꂽ�X�|�i�[�������̒e�𔭎�

            Instantiate(bulletPrefabs[randomIndex], spawners[randomIndex].position, spawners[randomIndex].rotation);

            // ���̔��˂܂őҋ@
            yield return new WaitForSeconds(spawnInterval + (MasterSpeed.SpeedControl / 10));
        }
    }
}