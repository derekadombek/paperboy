using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    public GameObject newsPaper;

    bool wasHit;

    GameLogic scoreBoard;
    void Start()
    {
        scoreBoard = FindObjectOfType<GameLogic>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!wasHit)
        {
            if(newsPaper != null)
            {
                newsPaper.SetActive(true);
            }
            scoreBoard.AddScore(1000);
        }
        wasHit = true;
    }
}
