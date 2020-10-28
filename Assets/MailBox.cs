using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    public GameObject newsPaper;

    private void OnCollisionEnter(Collision collision)
    {
        newsPaper.SetActive(true);
    }
}
