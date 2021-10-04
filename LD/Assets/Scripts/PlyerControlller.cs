using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlyerControlller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private AudioSource audioData;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnd;
    private int extraJump;
    public int extraJumpValue;
    private bool facingRight = true;
    private KeyCode right = KeyCode.LeftArrow;
    private KeyCode left = KeyCode.RightArrow;
    public Animator animator;
    bool danc = false;
    public dialogues d;
    public bool ez = false;
    public bool die;
    float jF;
    void Start()
    {
        jF = jumpForce;
        audioData = GetComponent<AudioSource>();
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }
    public bool r;
    bool playing = false;
    int m = 0;
    public bool isEnd = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            m++;
            if (m > 1)
            {
                Application.Quit();
            }
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            r = true;
        }
        if (die == true)
        {
            d.ded();
        }
        if (die==false){
            isEnd = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsEnd);
            Debug.Log(ez);
            if (isEnd==true)
            {
                d.da();
            }
            if (transform.position.x > 415)
            {
                d.la();
            }
            if (ez == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                transform.rotation = Quaternion.identity;
            }
            animator.SetBool("isWalking", true);
            int a = Random.Range(0, 1000);
            if (a == 1)
            {
                danc = true;
            }
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            if (danc == false)
                moveInput = Input.GetAxis("Horizontal");
            
            else if (danc == true)
            {
                if (Input.GetKeyDown(right)){
                    moveInput = 1;
                }
                else if (Input.GetKeyDown(left))
                    moveInput = -1;
                else 
                    moveInput = 0;
            }
            if (moveInput != 0)
                animator.SetBool("isWalking", false);
            else if (moveInput == 0)
                animator.SetBool("isWalking", true);

            transform.position = move(transform.position, Time.deltaTime);   
            if (facingRight == false && moveInput > 0)
                Flip();
            else if (facingRight == true && moveInput < 0)
                Flip();
            if (transform.position.y < -50)
            {
                d.ded();
            }
        }
    }

    void Update()
    {
        if (die == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine("heh");
                danc=false;
            }

            if (danc == true){
                Flip();
                if (playing == false){
                    audioData.Play(0);
                    playing = true;
                }
                rb.velocity = Vector2.up * jF;
                jF = 0.1f;
            }
            if (danc == false)
            {
                audioData.Stop();
                normalize();
                jF = jumpForce;
                playing = false;
            }
            if (isGrounded == true)
            {
                extraJump = extraJumpValue;
            }
            if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
            {
                rb.velocity = Vector2.up * jF;
                extraJump--;
            }else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jF;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void normalize()
    {
        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;
    }

    Vector3 move(Vector3 t, float delt)
    {
        t += new Vector3(moveInput, 0, 0) * delt * speed;
        animator.SetBool("isWalking", false);
        return t;
    }
    IEnumerator heh() 
    {
        animator.SetBool("a", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("a", false);
    }
}
