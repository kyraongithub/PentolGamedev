using UnityEngine;

public class BossXMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distance to player: " + distToPlayer);
        if (distToPlayer > 5)
        {
            // Chase & attack jauh
            chasePlayer();
            animator.SetBool("walk", true);
        }
        else
        {
            // disini nanti attack dekat
            stopChasePlayer();
            animator.SetBool("walk", false);
        }
    }

    void chasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void stopChasePlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}
