using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS3 : MonoBehaviour
{
    int count = 120;
    public Animator anim;
    public Animator transitionAnim;
    public GameObject bg;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        //FindObjectOfType<AudioManager>().Play("warning");
    }

    void FixedUpdate()
    {
        count -= 1;
        if (count == 110)
        {
            FindObjectOfType<AudioManager>().Play("warning");
        }
        if (count <= 110)
        {
            bg.transform.localScale = new Vector3(bg.transform.localScale.x + .015f, bg.transform.localScale.y + .015f, bg.transform.localScale.z);
        }
        if (count == -60)
        {
            StartCoroutine(LoadScene());
        }
        if (count == -65)
        {
            FindObjectOfType<AudioManager>().Stop("warning");
        }
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

