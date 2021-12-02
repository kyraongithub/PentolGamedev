﻿using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }


    private void Awake()
    {
        currentHealth = startingHealth;
     
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {

            //player hurt
        }
        else
        {
            //player dead

        }
    }

    public void Update(){
        if(Input.GetKeyDown(KeyCode.E))
        TakeDamage(1);
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}