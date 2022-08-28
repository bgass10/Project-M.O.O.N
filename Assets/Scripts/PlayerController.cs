using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private Animator anim;

    public GameObject dustParticles;
    private ParticleSystem ps;

    void Start()
    {
        anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        ps = dustParticles.GetComponent<ParticleSystem>();
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (isGrounded && moveInput != 0)
        {
            GetComponent<AudioSource>().UnPause();
        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }
    }

    void Update()
    {
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
            ps.enableEmission = false;
        }
        else
        {
            anim.SetBool("isRunning", true);
            if (isGrounded == true)
            {
                ps.enableEmission = true;
            }
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
            ps.enableEmission = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("coinCollect");
        }
        if (other.gameObject.CompareTag("Spikes"))
        {
            ScoreManager.levelComplete = false;
            FindObjectOfType<AudioManager>().Play("hitSpike");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
