using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private int multiplier = 1;
    private float time;
    public Text scoreText;
    public Text multiplierText;
    public float multiplierDelay = 8;

    void Update() {
        time += Time.deltaTime;
        scoreText.text = "" + score;
        multiplierText.text = "x" + multiplier;

        //Reset multiplier
        if (time > multiplierDelay)
        {
            multiplier = 1;
            time = 0;
        }

        Debug.Log(time);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            score += 100 * multiplier;
            multiplier += 1;
            time = 0;
        }
    }
}
