using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    public RectTransform playerIcon; // Playerのアイコン (UI上のImage)
    public RectTransform enemyIcon;  // Enemyのアイコン (UI上のImage)

    public const float minDistance = 0f;    // 最小距離（敵とPlayerが最も近い場合）
    public const float maxDistance = 8000f;  // 最大距離（敵とPlayerが最も離れる場合）
    public float iconMovementRange = 0.5f; // アイコンが動く範囲 (UI上でのX軸方向の移動範囲)

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerとEnemyの現在の距離を計算
        float currentDistance = Vector3.Distance(GameObject.Find("Player").transform.position, GameObject.Find("Death").transform.position);

        // 距離をアイコン移動範囲に合わせて正規化 (0から1に変換)
        float normalizedDistance = Mathf.InverseLerp(minDistance, maxDistance, currentDistance);

        // プレイヤーのアイコンの位置は固定
        Vector2 playerPos = playerIcon.anchoredPosition;

        // 敵のアイコンの位置をプレイヤーアイコンに基づいて更新
        Vector2 enemyPos = enemyIcon.anchoredPosition;

        // 敵アイコンをプレイヤーアイコンの左方向に移動
        enemyPos.x = playerPos.x - Mathf.Lerp(0, iconMovementRange, normalizedDistance);
        enemyIcon.anchoredPosition = enemyPos;
    }
}
