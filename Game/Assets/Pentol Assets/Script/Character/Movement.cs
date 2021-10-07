using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {   // player move
        player.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0f,0f);

        // flip character
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -2;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 2;
        }
        transform.localScale = characterScale;

        // move animation
        // walk
        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("walk", false);
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("walk", true);
        }
        //jump
        //if (rb.velocity.y > 0)
        //{
            //animator.SetBool("walk", false);
            //animator.SetBool("jump", true);
        //}
        //if (rb.velocity.y == 0)
        //{
            //animator.SetBool("jump", false);
        //}
    }
    public void jumpButton()
    {
        rb.velocity = Vector2.up * jumpSpeed;  
    }
    
}
