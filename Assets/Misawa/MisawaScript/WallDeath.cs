using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallDeath : MonoBehaviour
{
    // �ړI�n�̔z��
    public Vector3[] targetPositions = new Vector3[3];

    // �e�ړI�n�ɑΉ�����ړ����x�̔z��
    public float[] speeds = new float[3];

    // ���݂̖ړI�n�C���f�b�N�X
    private int currentTargetIndex = 0;

    // �J�ڐ�̃V�[����
    public string nextSceneName;

    // Update is called once per frame
    void Update()
    {
        // ���݂̖ړI�n�ƑΉ����鑬�x���擾
        Vector3 currentTarget = targetPositions[currentTargetIndex];
        float currentSpeed = speeds[currentTargetIndex];

        // �I�u�W�F�N�g��ړI�n�Ɍ����Ĉړ�
        float step = currentSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);

        // �ړI�n�ɓ��B���������m�F
        if (Vector3.Distance(transform.position, currentTarget) < 0.001f)
        {
            // �Ō�̖ړI�n�ɓ��B�����ꍇ�A�V�[���J�ڂ��s��
            if (currentTargetIndex == targetPositions.Length - 1)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                // ���̖ړI�n�ɐ؂�ւ�
                currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;
            }
        }
    }
}