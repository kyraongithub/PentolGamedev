using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public GameObject buffSpeedCount;
    public GameObject buffPowerCount;
    public int speedSecondsLeft = 5;
    public int powerSecondsLeft = 5;
    public int speedBuffTaken = 0;
    public int powerBuffTaken = 0;

    public bool isInvicible = false;
    
    public GameObject bullet;
    public bool isFacingRight = true;
    public float fireRate = 0.2f;
    float timeUntillFire;
    float angle;
    public Transform firingPoint;

    ScreenManager sm;

    public GameObject gate;
    public Text warn;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("jump", true);
        buffSpeedCount.GetComponent<Text>().enabled = false;
        buffPowerCount.GetComponent<Text>().enabled = false;
        sm = FindObjectOfType<ScreenManager>();
        gate.SetActive(false);
        warn.enabled = false;

        //if player invicible start
        if (PlayerPrefs.HasKey("isInvicibleStart"))
        {
            powerBuffTaken += 1;
            if (powerBuffTaken < 2)
            {
                GetComponent<SpriteRenderer>().color = Color.gray;
                isInvicible = true;
                StartCoroutine(ResetPower());
                //countdown buff
                buffPowerCount.GetComponent<Text>().enabled = true;
            }
        }
    }

    void Update()
    {
        // player move
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
            isFacingRight = true;
        }
        else if (fixedJoystick.Horizontal < 0 || Input.GetAxis("Horizontal") < 0)
        {
            player.transform.Translate(Vector2.left * speed * Time.deltaTime);
            characterScale.x = -2;
            animator.SetBool("walk", true);
            animator.SetBool("jump", false);
            isFacingRight = false;
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
            other.gameObject.SetActive(false);
            StartCoroutine(ItemSpawn(other.gameObject));
            //Destroy(other.gameObject);
            coinSource.Play(); //play audio
            // add coins
            if (PlayerPrefs.HasKey("coins"))
            {
                int coins = PlayerPrefs.GetInt("coins");
                if (coins <= 9999)
                {
                    PlayerPrefs.SetInt("coins", coins + 1);
                }
            }
            else
            {
                PlayerPrefs.SetInt("coins", 1);
            }
        }
        if (other.gameObject.CompareTag("Boots"))
        {
            speedBuffTaken += 1;
            if(speedBuffTaken < 2)
            {
                other.gameObject.SetActive(false);
                StartCoroutine(ItemSpawn(other.gameObject));
                speed = 14f;
                GetComponent<SpriteRenderer>().color = Color.green;
                StartCoroutine(ResetSpeed());
                powerUp.Play(); //play audio
                //countdown buff
                buffSpeedCount.GetComponent<Text>().enabled = true;
            }
        }
        if (other.gameObject.CompareTag("Energy"))
        {
            powerBuffTaken += 1;
            if (powerBuffTaken < 2)
            {
                other.gameObject.SetActive(false);
                StartCoroutine(ItemSpawn(other.gameObject));
                GetComponent<SpriteRenderer>().color = Color.gray;
                isInvicible = true;
                StartCoroutine(ResetPower());
                powerUp.Play(); //play audio
                //countdown buff
                buffPowerCount.GetComponent<Text>().enabled = true;
            }

        }
        if (other.gameObject.CompareTag("Health"))
        {
            other.gameObject.SetActive(false);
            StartCoroutine(ItemSpawn(other.gameObject));
            powerUp.Play(); //play audio
        }
         if (other.gameObject.CompareTag("Object"))
        {
            Destroy(other.gameObject);
            warn.enabled = true;
            gate.SetActive(enabled); //enable gate
            powerUp.Play(); //play audio
        }
        if (other.gameObject.CompareTag("gate"))
        {
            if(sm.getActiveSceneName() == "level 1")
            {
                sm.LoadScene("level 2");
            } else if (sm.getActiveSceneName() == "level 2")
            {
                sm.LoadScene("level 3");
            }
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
        speedSecondsLeft = 5;
        buffSpeedCount.GetComponent<Text>().text = speedSecondsLeft.ToString();
        while (speedSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            speedSecondsLeft -= 1;
            buffSpeedCount.GetComponent<Text>().text = speedSecondsLeft.ToString();
        }
        if (speedSecondsLeft == 0)
        {
            speed = 10f;
            GetComponent<SpriteRenderer>().color = Color.white;
            buffSpeedCount.GetComponent<Text>().enabled = false;
           speedBuffTaken = 0;
        }
    }
    private IEnumerator ResetPower()
    {
        powerSecondsLeft = 5;
        buffPowerCount.GetComponent<Text>().text = powerSecondsLeft.ToString();
        while (powerSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            powerSecondsLeft -= 1;
            buffPowerCount.GetComponent<Text>().text = powerSecondsLeft.ToString();
        }
        if (powerSecondsLeft == 0)
        {
            isInvicible = false;
            GetComponent<SpriteRenderer>().color = Color.white;
            buffPowerCount.GetComponent<Text>().enabled = false;
            powerBuffTaken = 0;
        }
    }
    private IEnumerator ItemSpawn(GameObject gameObject)
    {
       yield return new WaitForSeconds(7);
        gameObject.SetActive(true);
    }
    public void Fire()
    {
        if (timeUntillFire < Time.time)
        {
            angle = isFacingRight ? 0f : 180f;
            Instantiate(bullet, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            timeUntillFire = Time.time + fireRate;
        }
    }
}


