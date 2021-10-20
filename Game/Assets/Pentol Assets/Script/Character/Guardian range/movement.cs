using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        agroRange = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distance to player: " + distToPlayer);
        if(distToPlayer < agroRange )
        {
            if (distToPlayer > 8)
            {
                // Chase
                chasePlayer();
                animator.SetBool("walk", true);
            } else
            {
                // disini nanti attack
                animator.SetBool("walk", false);
            }
        } else
        {
            // Stop chasing
            stopChasePlayer();
            animator.SetBool("walk", false);
        }
    }

    void chasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-0.3f, 0.3f);
        }
    }

    void stopChasePlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}
