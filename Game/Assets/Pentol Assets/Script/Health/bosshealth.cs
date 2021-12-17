using System.Collections;
using UnityEngine;

public class bosshealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public Canvas winCanvas;
    public AudioSource win;
    int currentCoins;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        winCanvas.enabled = false;
        currentCoins = PlayerPrefs.GetInt("coins");
    }
    public void TakeDamage(float _damage)
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
                dead = true;
                winCanvas.enabled = true;
                win.Play();
                PlayerPrefs.SetInt("coins", currentCoins + 100);
                StartCoroutine(EnemyDestroy(gameObject));
            }
        }
    }

    private IEnumerator EnemyDestroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
