using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blades : MonoBehaviour
{
    public float rotateSpeed;
    Health hlt;
    // Start is called before the first frame update
    void Start()
    {
        hlt = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            hlt.TakeDamage(1f);
        }
    }
}
