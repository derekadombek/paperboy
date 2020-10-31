using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    int score = 0;
    Text scoreText;
    

    const int max_papers = 10;
    int current_paper_amount = 10;

    int totalPoints = 20;
    // Start is called before the first frame update
    private void Start()
    {
        scoreText = GetComponent<Text>();
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

    public void AddScore(int _score)
    {
        score += _score;
        scoreText.text = "Balance: $" + score.ToString();
        instance = this;
    }

    public void EndLevel(Player player)
    {
        player.enabled = false;
        print("end");
        if(score < totalPoints)
        {
            Won();
            scoreText.text = "You suck, start over!";
            instance = this;
        }
        else
        {
            Lose();
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

    //public void LoseLife(Player player, int lifeAmount)
    //{
    //    current_life += lifeAmount;
    //    scoreText.text = "Life: " + current_life.ToString();
    //    instance = this;
    //    if (current_life == 0)
    //    {
    //        player.enabled = false;
    //        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //        SceneManager.LoadScene(currentSceneIndex);
    //        scoreText.text = "You Died!";
    //        instance = this;
    //    }
    //}

    public void SetNewsPaper(int amount)
    {
        current_paper_amount += amount;
        if(current_paper_amount >= max_papers)
        {
            current_paper_amount = max_papers;
        }
    }

    public int RequestPapers()
    {
        return current_paper_amount;
    }
}
