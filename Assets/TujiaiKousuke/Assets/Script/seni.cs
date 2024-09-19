using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class seni : MonoBehaviour
{
    public float minAlpha = 0.2f;    // �ŏ��̓����x
    public float maxAlpha = 1.0f;    // �ő�̓����x
    public float blinkSpeed = 1.0f;  // �_�ł̑���
    private Renderer objectRenderer;
    private bool increasingAlpha = true;
    public AudioClip sound01;
    AudioSource audioa;
    // Start is called before the first frame update
    void Start()
    {
        audioa = GetComponent<AudioSource>();
        Application.targetFrameRate = 100;
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MasterSpeed.SpeedControl = 0;
            audioa.PlayOneShot(sound01);
            SceneManager.LoadScene("Title");
        }
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
