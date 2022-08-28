using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemController : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI finalText;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        int score = PlayerPrefs.GetInt("GemScore", 0);
        if (score == 5)
        {
            questionText.text = "";
        }
        string scoreText = score.ToString();
        finalText.text = "YOU COLLECTED " + scoreText + "/5";
        
    }

}
