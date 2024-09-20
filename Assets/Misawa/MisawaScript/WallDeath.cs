using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallDeath : MonoBehaviour
{
    public AudioClip sound01;
    AudioSource audioa;
    // 目的地の配列
    public Vector3[] targetPositions = new Vector3[3];

    // 各目的地に対応する移動速度の配列
    public float[] speeds = new float[3];

    // 現在の目的地インデックス
    private int currentTargetIndex = 0;

    // 遷移先のシーン名
    public string nextSceneName;

    private bool shakeFlag=false;

	private void Start()
    {
        audioa = GetComponent<AudioSource>();
        shakeFlag = false;
	}

	// Update is called once per frame
	void Update()
    {
        //スタートしていない時
        if (!StartCameraAnimation.isStart) return;

        // 現在の目的地と対応する速度を取得
        Vector3 currentTarget = targetPositions[currentTargetIndex];
        float currentSpeed = speeds[currentTargetIndex];

        // オブジェクトを目的地に向けて移動
        float step = currentSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);

        //indexが０の時の位置を越えたらBOSS停止
        if (currentTargetIndex == 0 && currentTarget.x < transform.position.x)
        {
            MasterSpeed.SpeedControl = 0;
            BOSS.speed = 0;
        }

        // 目的地に到達したかを確認
        if (Vector3.Distance(transform.position, currentTarget) < 0.001f)
        {
            // 最後の目的地に到達した場合、シーン遷移を行う
            if (currentTargetIndex == targetPositions.Length - 1)
            {
				SceneManager.LoadScene(nextSceneName);
			}
            else
            {
                // 次の目的地に切り替え
                currentTargetIndex = (currentTargetIndex + 1) % targetPositions.Length;

                //カメラシェイク
                if (currentTargetIndex == 1)
                {
     
                    if (!shakeFlag)
                    {
                        MasterSpeed.SpeedControl = 0;
                        BOSS.speed = 0;
                        if (GameObject.Find("Main Camera"))
                            if (GameObject.Find("Main Camera").GetComponent<CameraShake>())
                                GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake();
                        audioa.PlayOneShot(sound01);
                    }
                    shakeFlag = true;
                }
            }
        }
    }
}