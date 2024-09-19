using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GradualBlink : MonoBehaviour
{
    GlitchFx GliScript;
    public float Gliver = 0;
    public float minAlpha = 0.2f;    // �ŏ��̓����x
    public float maxAlpha = 1.0f;    // �ő�̓����x
    public float blinkSpeed = 1.0f;  // �_�ł̑���
    bool StertScene = false;
    private Renderer objectRenderer;
    private bool increasingAlpha = true;

    public AudioClip sound01;
    AudioSource audioa;
    // Start is called before the first frame update
    void Start()
    {
        audioa = GetComponent<AudioSource>();

        AllScore.tokuten = 0;
        Gliver = 0.01f;
        GliScript = GameObject.Find("Main Camera").GetComponent<GlitchFx>();
        Application.targetFrameRate = 100;
        objectRenderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StertScene = true;

    
        }
        if (StertScene == true)
        {
            if (Gliver <= 0.01)
            {
                audioa.PlayOneShot(sound01);
            }
            Gliver += 0.01f;
            if(Gliver>=1)
            {
             
                SceneManager.LoadScene("MisawaScene");
            }
        }
    
    GliScript.intensity = Gliver;
        // Update is called once per frame
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
