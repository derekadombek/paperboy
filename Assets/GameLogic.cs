using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    int level2TotalPoints = 15;
    int score = 0;
    //Text scoreText;

    int totalPoints = 20;
    // Start is called before the first frame update
    private void Start()
    {
        Text scoreText = (Text)FindObjectOfType(typeof(Text));
        scoreText.text = "Balance: $" + score.ToString();
        instance = this;
    }

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int LevelAmount()
    {
        int level2 = SceneManager.GetSceneByName("Level2").buildIndex;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == level2)
        {
            return level2TotalPoints;
        }
        else
        {
            return totalPoints;
        }
    }

    public void AddScore(int _score)
    {
        Text scoreText = (Text)FindObjectOfType(typeof(Text));
        score += _score;
        scoreText.text = "Balance: $" + score.ToString();
        instance = this;
    }

    public void EndLevel(Player player)
    {
        player.enabled = false;
        print("end");
        if(score < GameLogic.instance.LevelAmount())
        {
            Won();
            Text scoreText = (Text)FindObjectOfType(typeof(Text));
            scoreText.text = "You suck, start over!";
            instance = this;
        }
        else
        {
            Lose();
            Text scoreText = (Text)FindObjectOfType(typeof(Text));
            scoreText.text = "Next Round!";
            instance = this;
        }
    }

    public void Lose()
    {
        LoadNextLevel();
    }

    public void Won()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        print("SceneCount " + SceneManager.sceneCountInBuildSettings);
        print("Current Scene Index " + currentSceneIndex);
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        print("Next Scene Index " + nextSceneIndex);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
