using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    public GameObject newsPaper;

    bool wasHit;
    int scorePerHit = 5;
    int hitCount;

    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NewsPaper")
        {
            hitCount++;
            if (!wasHit)
            {
                if (newsPaper != null)
                {
                    newsPaper.SetActive(true);
                }
            }
            wasHit = true;
            if (hitCount <= 1)
            {
                GameLogic.instance.AddScore(scorePerHit);
            }
        }
    }
}
