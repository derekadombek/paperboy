using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLife : MonoBehaviour
{
    public static LevelLife instance;

    Text levelLife;
    double current_life = 6;
    // Start is called before the first frame update
    void Start()
    {
        levelLife = GetComponent<Text>();
        levelLife.text = "Life: " + current_life.ToString("F2");
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
    public void LoseLife(Player player, double lifeAmount)
    {
        current_life += lifeAmount;
        levelLife.text = "Life: " + current_life.ToString("F2");
        instance = this;
        if (current_life == 0)
        {
            player.enabled = false;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
            levelLife.text = "You Died!";
            instance = this;
        }
    }
}
