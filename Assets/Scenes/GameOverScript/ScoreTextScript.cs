using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public Text scoreText;
    private int score = 10000;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score�F" + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score�F" + score.ToString();
    }
}
