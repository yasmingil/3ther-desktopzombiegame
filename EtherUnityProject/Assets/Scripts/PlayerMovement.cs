using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] GameOver gameOver;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator anim;
    public bool isAlive = true;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame, good for input
    void Update()
    {
        if (isAlive)
        {
            ProcessInputs();
        }
    }
    // process the movement
    void FixedUpdate()
    {
        if (isAlive)
        {
            if (moveDirection.x != 0 || moveDirection.y != 0)
            {
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);

            }
            Move();
        }
        //if (isAlive == false)
        //{
        //    // death animation
        //    anim.SetBool("Dies", true);
        //}
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 scale = transform.localScale;
        if (moveX > 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        else if (moveX < 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        moveDirection.x = moveX;
        moveDirection.y = moveY;
        moveDirection.Normalize();
        // 1 if moving
        // 0 if not moving
    }
    bool Move()
    {
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
        return true;        
    }

    public void Kill()
    {
        anim.SetBool("Dies", true);
        isAlive = false;
        rb.velocity = Vector3.zero;
        StartCoroutine(WaitForDeath());
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(3.0f);
        gameOver.gameOverUI.SetActive(true);
        gameOver.GameIsOver = true;
    }
}

