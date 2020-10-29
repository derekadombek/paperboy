using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    public GameObject newsPaper;

    bool wasHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (!wasHit)
        {
            if(newsPaper != null)
            {
                newsPaper.SetActive(true);
            }
            GameLogic.instance.AddScore(1000);
        }
        wasHit = true;
    }
}
