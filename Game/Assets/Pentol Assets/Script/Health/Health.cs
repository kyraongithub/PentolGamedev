using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    Movement mv;
    public Canvas deadCanvas;
    public AudioSource getHit;
    public AudioSource deadSFX;
    public AudioSource looseSFX;
    private void Start()
    {
        mv = gameObject.GetComponent<Movement>();
        deadCanvas.enabled = false;
    }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("playerHealth"))
        {
            PlayerPrefs.SetFloat("playerHealth", 3f);
        }
        currentHealth = PlayerPrefs.HasKey("playerHealth") ? PlayerPrefs.GetFloat("playerHealth") : startingHealth;
        anim = GetComponent<Animator>();
        
    }
    public void TakeDamage(float _damage)
    {
        if (!mv.isInvicible)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, PlayerPrefs.HasKey("playerHealth") ? PlayerPrefs.GetFloat("playerHealth") : startingHealth);
            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                getHit.Play();
                //iframes
            }
            else
            {
                if (!dead)
                {
                    anim.SetTrigger("die");
                    GetComponent<Movement>().enabled = false;
                    dead = true;
                    // dead canvas
                    deadCanvas.enabled = true;
                    deadSFX.Play();
                    looseSFX.Play();

                    //enemy
                    if(GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                    if(GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;
                    dead = true;

                }
            }
        }

    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, PlayerPrefs.HasKey("playerHealth") ? PlayerPrefs.GetFloat("playerHealth") : startingHealth);
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
}