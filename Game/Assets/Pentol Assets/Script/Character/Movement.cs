using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Transform player;
    public FixedJoystick fixedJoystick;
    private Rigidbody2D rb;
    public float speed = 5.0f;
    public float jumpSpeed = 10.0f;
    public Button btnJump;
    public Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("jump", true);
    }
    void Update()
    {   // player move
        // using arrow / wasd
        player.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        Vector3 characterScale = transform.localScale;
        // using joystick
        if (fixedJoystick.Horizontal > 0)
        {
            player.transform.Translate(Vector2.right * speed * Time.deltaTime);
            characterScale.x = 2;
            animator.SetBool("walk", true);
            animator.SetBool("jump", false);
        }
        else if(fixedJoystick.Horizontal < 0)
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

        //jump
        Button btn = btnJump.GetComponent<Button>();
        btn.onClick.AddListener(jumpButton);
        if (rb.velocity.y == 0)
        {
            animator.SetBool("jump", false);
        }
    }
    public void jumpButton()
    {
        rb.velocity = Vector2.up * jumpSpeed;
        animator.SetBool("jump", true);
    }
    
}
