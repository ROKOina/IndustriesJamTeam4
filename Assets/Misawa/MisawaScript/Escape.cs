using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public float minAlpha = 0.2f;    // �ŏ��̓����x
    public float maxAlpha = 1.0f;    // �ő�̓����x
    public float blinkSpeed = 1.0f;  // �_�ł̑���
    private Renderer objectRenderer;
    private bool increasingAlpha = true;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 100;
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̓����x���擾
        Color currentColor = objectRenderer.material.color;


        // �����x�����X�ɕω�������
        float alphaChange = blinkSpeed * Time.deltaTime;
        if (increasingAlpha)
        {
            currentColor.a += alphaChange;
            if (currentColor.a >= maxAlpha)
            {
                currentColor.a = maxAlpha;
                increasingAlpha = false;
            }
        }
        else
        {
            currentColor.a -= alphaChange;
            if (currentColor.a <= minAlpha)
            {
                currentColor.a = minAlpha;
                increasingAlpha = true;
            }
        }

        // �V���������x���}�e���A���ɓK�p
        objectRenderer.material.color = currentColor;
    }
}
