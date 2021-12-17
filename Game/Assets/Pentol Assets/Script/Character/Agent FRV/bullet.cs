using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    float bulletDamage;
    int lifetime = 1;
    float timer;
    public Rigidbody2D rbBullet;

    private void Start()
    {
        if (PlayerPrefs.HasKey("playerDamage"))
        {
            bulletDamage = PlayerPrefs.GetFloat("playerDamage");
        }
        else
        {
            bulletDamage = 1f;
            PlayerPrefs.SetFloat("playerDamage", 1f);
        }
    }

    private void FixedUpdate()
    { 
     rbBullet.velocity = transform.right * bulletSpeed;
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
            if (target.gameObject.name == "boss X")
            {
                target.gameObject.GetComponent<bosshealth>().TakeDamage(bulletDamage);
            } else
            {
                target.gameObject.GetComponent<enemyhealth>().TakeDamage(bulletDamage);
            }
        }
    }
}
