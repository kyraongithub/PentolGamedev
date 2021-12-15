using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    Health hlt;
    // Start is called before the first frame update
    void Start()
    {
        hlt = FindObjectOfType<Health>();
    }
    
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            hlt.TakeDamage(1f);
            if(gameObject.tag == "bottom")
            {
                hlt.TakeDamage(3f);
            }
        }
    }
}
