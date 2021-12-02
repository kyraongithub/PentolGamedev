﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;


public class Movement : MonoBehaviour
{
    public Transform player;
    public FixedJoystick fixedJoystick;
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    public Animator animator;
    public int jumpCount = 0;
    public AudioSource coinSource;
    public AudioSource powerUp;
    public Text buffCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("jump", true);
        buffCount.enabled = false;
    }

    void Update()
    {   // player move
        Vector3 characterScale = transform.localScale;
        // using wasd/key
        player.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        // jump using space
        if (Input.GetKeyDown("space"))
        {
            JumpButton();
        }
        // using joystick
        if (fixedJoystick.Horizontal > 0 || Input.GetAxis("Horizontal") > 0)
        {
            player.transform.Translate(Vector2.right * speed * Time.deltaTime);
            characterScale.x = 2;
            animator.SetBool("walk", true);
            animator.SetBool("jump", false);
        }
        else if (fixedJoystick.Horizontal < 0 || Input.GetAxis("Horizontal") < 0)
        {
            player.transform.Translate(Vector2.left * speed * Time.deltaTime);
            characterScale.x = -2;
            animator.SetBool("walk", true);
            animator.SetBool("jump", false);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        // flip character
        transform.localScale = characterScale;
        if (rb.velocity.y == 0)
        {
            animator.SetBool("jump", false);
            jumpCount = 0;

        }
    }
        //coin,boots,energy,health collect
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            coinSource.Play(); //play audio
        }
        if (other.gameObject.CompareTag("Boots"))
        {
            Destroy(other.gameObject);
             speed = 14f;
             GetComponent<SpriteRenderer>().color = Color.green;
             StartCoroutine(ResetSpeed());
             powerUp.Play(); //play audio
            //countdown buff
            buffCount.enabled = true;
        }
        if (other.gameObject.CompareTag("Energy"))
        {
            Destroy(other.gameObject);
             GetComponent<SpriteRenderer>().color = Color.blue;
             StartCoroutine(ResetSpeed());
            powerUp.Play(); //play audio
            //countdown buff
            buffCount.enabled = true;

        }
        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            powerUp.Play(); //play audio
        }
         if (other.gameObject.CompareTag("Object"))
        {
            Destroy(other.gameObject);
            powerUp.Play(); //play audio
        }
        
    }

    public void JumpButton()
    {
        if (jumpCount < 2)
        {

            rb.velocity = Vector2.up * jumpSpeed;
            animator.SetBool("jump", true);
            jumpCount++;
        }
    }
    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(10);
        speed = 10f;
        GetComponent<SpriteRenderer>().color = Color.white;
        
    }
 }
