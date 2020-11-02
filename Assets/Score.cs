using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    int score = 0;
    Text scoreText;
    int totalPoints = 20;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();

    }
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCount(score);
    }
    public void ScoreCount(int _score)
    {
        score += _score;
    }

    public void EndLevel(Player player)
    {
        player.enabled = false;
        print("end");
        if (score < totalPoints)
        {
            GameLogic.instance.Won();
            scoreText.text = "You suck, start over!";
            instance = this;
        }
        else
        {
            GameLogic.instance.Lose();
            scoreText.text = "Next Round!";
            instance = this;
        }
    }
}
