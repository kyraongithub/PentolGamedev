using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    Health hlt;
    Movement mv;
    // Start is called before the first frame update
    void Start()
    {
        hlt = FindObjectOfType<Health>();
        mv = FindObjectOfType<Movement>();
    }
    
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            hlt.TakeDamage(1f);
            if(gameObject.tag == "bottom")
            {
                mv.isInvicible = false;
                hlt.TakeDamage(PlayerPrefs.GetFloat("playerHealth"));
            }
        }
    }
}
