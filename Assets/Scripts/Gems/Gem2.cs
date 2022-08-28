using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Gem2Collected",0) == 1)
        {
            gameObject.SetActive(false); 
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("coinCollect");
            PlayerPrefs.SetInt("Gem2Collected", 1);
            int score = PlayerPrefs.GetInt("GemScore", 0);
            int newScore = score += 1;
            PlayerPrefs.SetInt("GemScore", newScore);
        }
    }

}
