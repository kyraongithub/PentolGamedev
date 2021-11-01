using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform player;
    public FixedJoystick fixedJoystick;
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public float jumpSpeed = 10.0f;
    public Animator animator;
    public int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("jump", true);
    }
    void Update()
    {   // player move
        Vector3 characterScale = transform.localScale;
        // using wasd/key
        player.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
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
        }
        if (other.gameObject.CompareTag("Boots"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Energy"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
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

}
