using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject panel;
    public GameObject startImage;
    public GameObject continueImage;

    void Start()
    {
        int startLevel = PlayerPrefs.GetInt("Level", 1);
        if (startLevel == 1)
        {
            startImage.SetActive(true);
            continueImage.SetActive(false);
        }
        else
        {
            startImage.SetActive(false);
            continueImage.SetActive(true);
        }
    }
    public void startGame()
    {
        FindObjectOfType<AudioManager>().Play("clickSound");
        StartCoroutine(LoadScene());
    }
     

    public void stopGame()
    {
        FindObjectOfType<AudioManager>().Play("clickSound");
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        panel.SetActive(true);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
        int startLevel = PlayerPrefs.GetInt("Level", 1);
        if (startLevel > 1 && startLevel < 18)
        {
            FindObjectOfType<AudioManager>().Play("bg1");
        }
    }

}
