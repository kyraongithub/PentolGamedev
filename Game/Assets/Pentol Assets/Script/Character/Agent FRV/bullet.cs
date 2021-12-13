using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public int bulletDamage = 1;
    int lifetime = 1;
    float timer;
    public Rigidbody2D rbBullet;
    enemyhealth eh;

    private void FixedUpdate()
    { 
     rbBullet.velocity = transform.right * bulletSpeed;
        eh = FindObjectOfType<enemyhealth>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
        {
            Destroy(gameObject); // destroy bullet after 1 sec
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag != "Player")
        {
            // destroy bullet
            Destroy(gameObject);
        }
        // destroy enemy      
        if (target.gameObject.tag == "enemy")
        {
            eh.TakeDamage(1f);
        }
    }
}
