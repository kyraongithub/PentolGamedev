using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinrotation : MonoBehaviour
{
    public float speed;
    void start(){

    }
    void Update()
    {
        this.gameObject.transform.Rotate(Vector2.up * speed);
    }
}