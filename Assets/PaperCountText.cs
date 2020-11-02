using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperCountText : MonoBehaviour
{
    public static PaperCountText instance;

    const int max_papers = 10;
    int current_paper_amount = 10;

    Text paperText;
    // Start is called before the first frame update
    void Start()
    {
        paperText = GetComponent<Text>();
        paperText.text = "Papers: " + current_paper_amount.ToString();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        instance = this;
    }

    public void SetNewsPaper(int amount)
    {
        current_paper_amount += amount;
        paperText = GetComponent<Text>();
        paperText.text = "Papers: " + current_paper_amount.ToString();
        instance = this;
        if (current_paper_amount >= max_papers)
        {
            current_paper_amount = max_papers;
        }
    }

    public int RequestPapers()
    {
        return current_paper_amount;
    }
}
