using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissappear : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(DissappearingPlatform());
        }
    }
    private IEnumerator DissappearingPlatform()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
