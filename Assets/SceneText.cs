using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneText : MonoBehaviour
{
    public static SceneText instance;
    Text sceneText;

    // Start is called before the first frame update
    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int level = currentSceneIndex + 1;
        sceneText = GetComponent<Text>();
        sceneText.text = "Level: " + level.ToString();
        instance = this;
    }

    void Awake()
    {
        instance = this;
    }
}
