using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS5 : MonoBehaviour
{
    public Sprite astronaut;
    public SpriteRenderer sr;

    int count = 120;
    public Animator transitionAnim;
    public Animator transitionAnim2;
    bool isGrounded = false;

    public Animator anim;

    void Start()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded == true)
        {
            if (count == 120)
            {
                FindObjectOfType<AudioManager>().Play("fall");
            }
            count--;
            if (count == 110)
            {
                anim.SetTrigger("isGrounded");
            }
            if (count == 0)
            {
                StartCoroutine(LoadScene());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("onGround"))
        {
            isGrounded = true;
        }
    }
    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        ScoreManager.levelComplete = true;
        transitionAnim2.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Play("bg1");
    }
}

