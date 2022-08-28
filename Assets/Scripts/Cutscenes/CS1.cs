using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS1 : MonoBehaviour
{
    int count = 120;
    public Animator anim;
    public Animator transitionAnim;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count -= 1;
        if (count == 35)
        {
            FindObjectOfType<AudioManager>().Play("launch");
        }
        if (count <= 30)
        {
            anim.SetTrigger("takingOff");
            if (count <= 20)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            }
        }
        if (count == -30)
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

