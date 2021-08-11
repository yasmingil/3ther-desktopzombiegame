using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public Transform player; // user controlled player
    [SerializeField] public float runSpeed; // if player seen
    [SerializeField] public float patrolSpeed;
    [SerializeField] public Transform[] moveSpots;
    [SerializeField] public float startWaitTime;
    [SerializeField] float etherTimeToSwitch;
    [SerializeField] float etherDuration;
    [SerializeField] float killDistance;

    private float waitTime;
    private int randomSpot;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 direction;
    private bool ether;
    private int temp = 0;
    [SerializeField] private FieldOfView fieldOfView;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EtherSwitch", etherTimeToSwitch, etherDuration); // ether
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        randomSpot = UnityEngine.Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        if (!ether)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            if (fieldOfView.detectPlayer)
            {
                Debug.Log("Run Animation"); // TO DO
                direction = player.position - transform.position;
                direction.Normalize();
                movement = direction;
                moveCharacter(movement);
            }
            else
            {
                Transform temp = moveSpots[randomSpot];
                direction = temp.position - transform.position;
                direction.Normalize();
                rb.MovePosition(transform.position + (direction * patrolSpeed * Time.deltaTime));
                if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = UnityEngine.Random.Range(0, moveSpots.Length);
                        Debug.Log("Run Animation"); // TO DO
                        anim.SetBool("IsRunning", true);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        Debug.Log("Idle Animation"); // 
                        anim.SetBool("IsRunning", false);
                        waitTime -= Time.deltaTime;
                    }
                }
            }
            fieldOfView.setDirection(direction);
            fieldOfView.setOrigin(transform.position);
        } else
        {
            Debug.Log("Sleep Animation");
            anim.SetBool("IsSleeping", true);

        }
        Vector3 scale = transform.localScale;
        if (direction.x >= 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        Vector3 distance = transform.position - player.transform.position;
        if (distance.magnitude < killDistance)
        {
            player.gameObject.GetComponent<PlayerMovement>().Kill();
            gameObject.SetActive(false);
        }
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * runSpeed * Time.deltaTime));
    }
    void EtherSwitch()
    {
        if (temp == 0) ether = false;
        temp++;
        if (ether)
        {
            ether = false;
            anim.SetBool("IsSleeping", false);

        }
        else ether = true;
    }

    private void OnTriggerEnter2D(Collider2D player) 
    {
        if (player.tag == "Player")
        {
            // cut to scene where we play animation?
            // call death scene
            // text game over
            GetComponent<PlayerMovement>().isAlive = false;
        }
    }
}
