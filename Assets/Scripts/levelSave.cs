using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSave : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transitionAnim;
    public GameObject panel;
    void Start()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        FindObjectOfType<AudioManager>().Pause("bg1");
        Cursor.visible = true;
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("clickSound");
        PlayerPrefs.SetInt("Level", 1);
        StartCoroutine(LoadScene());
    }

    public void StopGame()
    {
        FindObjectOfType<AudioManager>().Play("clickSound");
        Application.Quit();
    }

    IEnumerator LoadScene()
    {
        panel.SetActive(true);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene("MainMenu");
    }
}
