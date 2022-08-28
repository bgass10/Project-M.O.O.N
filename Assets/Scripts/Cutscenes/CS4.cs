using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS4 : MonoBehaviour
{
    int count = 120;
    public Animator transitionAnim;
    public GameObject explosion;
    public GameObject rocket;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count -= 1;
        if (count == 110)
        {
            FindObjectOfType<AudioManager>().Play("rocketFall");
        }
        if (count <= 90 && count >= 45)
        {
            rocket.transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y - 0.2f, rocket.transform.position.z);
        }
        if (count == 45)
        {
            FindObjectOfType<AudioManager>().Stop("rocketFall");
            FindObjectOfType<AudioManager>().Play("explosion");
            explosion.SetActive(true);
            rocket.SetActive(false);
        }
        if (count == -25)
        {
            explosion.SetActive(false);
        }
        if (count == -50)
        {
            StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

