using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatus : MonoBehaviour
{
    Text levelStatusText;
    bool won;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            LevelStatusLost();
        }
        else
        {
            LevelStatusWon();
        }
    }

    public void LevelStatusWon()
    {
        GameLogic.instance.Won();
        won = true;
        levelStatusText = GetComponent<Text>();
        levelStatusText.text = "You suck, start over";
    }

    public void LevelStatusLost()
    {
        GameLogic.instance.Lose();
        won = false;
        levelStatusText = GetComponent<Text>();
        levelStatusText.text = "Round 2!";
    }
}
