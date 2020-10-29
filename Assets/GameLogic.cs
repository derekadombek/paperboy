using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    Text scoreText;

    const int max_papers = 10;
    int current_paper_amount = 10;

    public int Lives = 3;

    [SerializeField] int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
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
        scoreText.text = score.ToString();
    }

    public void LoseLife(Player player)
    {
        Lives--;
        if(Lives == 0)
        {
            Debug.Log("GameOver");
            player.enabled = false;
        }
    }

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
