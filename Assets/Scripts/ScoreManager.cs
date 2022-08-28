using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public UnityEngine.Experimental.Rendering.LWRP.Light2D playerLight;

    public Animator transitionAnim;
    public Animator transitionAnim2;
    public GameObject level;
    public TextMeshProUGUI levelText;

    int currentScore = 0;
    public int levelScore;
    public float levelTime;
    float timeLeft;
    float intensity = 1;

    public static bool levelComplete = true;

    private GameObject player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        timeLeft = levelTime;
        text.text = currentScore.ToString() + "/" + levelScore.ToString();
        if (SceneManager.GetActiveScene().buildIndex - 5 > 0 && SceneManager.GetActiveScene().buildIndex < 18)
        {
            levelText.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex - 5).ToString();
        }
        else if(SceneManager.GetActiveScene().buildIndex >= 18)
        {
            levelText.text = "";
        }
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        intensity = timeLeft/levelTime;
        if (levelComplete)
        {
            level.SetActive(true);
        }
        else
        {
            level.SetActive(false);
        }
        if (timeLeft <= 0 && currentScore < levelScore)
        {
            levelComplete = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (currentScore == levelScore)
        {
            StartCoroutine(LoadScene());
        }
        playerLight.intensity = intensity;
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        levelComplete = true;
        transitionAnim2.SetTrigger("end");
        yield return new WaitForSeconds(.2f);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeScore(int coinValue)
    {
        currentScore += coinValue;
        text.text = currentScore.ToString() + "/" + levelScore.ToString();
    }
}
