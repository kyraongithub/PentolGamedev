using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    Movement mv;
    private void Start()
    {
        mv = gameObject.GetComponent<Movement>();
    }
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        if (!mv.isInvicible)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                //iframes
            }
            else
            {
                if (!dead)
                {
                    anim.SetTrigger("die");
                    GetComponent<Movement>().enabled = false;
                    dead = true;
                }
            }
        }

    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}