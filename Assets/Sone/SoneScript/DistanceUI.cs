using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    public RectTransform playerIcon; // Player�̃A�C�R�� (UI���Image)
    public RectTransform enemyIcon;  // Enemy�̃A�C�R�� (UI���Image)

    public const float minDistance = 0f;    // �ŏ������i�G��Player���ł��߂��ꍇ�j
    public const float maxDistance = 8000f;  // �ő勗���i�G��Player���ł������ꍇ�j
    public float iconMovementRange = 0.5f; // �A�C�R���������͈� (UI��ł�X�������̈ړ��͈�)

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Player��Enemy�̌��݂̋������v�Z
        float currentDistance = Vector3.Distance(GameObject.Find("Player").transform.position, GameObject.Find("Death").transform.position);

        // �������A�C�R���ړ��͈͂ɍ��킹�Đ��K�� (0����1�ɕϊ�)
        float normalizedDistance = Mathf.InverseLerp(minDistance, maxDistance, currentDistance);

        // �v���C���[�̃A�C�R���̈ʒu�͌Œ�
        Vector2 playerPos = playerIcon.anchoredPosition;

        // �G�̃A�C�R���̈ʒu���v���C���[�A�C�R���Ɋ�Â��čX�V
        Vector2 enemyPos = enemyIcon.anchoredPosition;

        // �G�A�C�R�����v���C���[�A�C�R���̍������Ɉړ�
        enemyPos.x = playerPos.x - Mathf.Lerp(0, iconMovementRange, normalizedDistance);
        enemyIcon.anchoredPosition = enemyPos;
    }
}
