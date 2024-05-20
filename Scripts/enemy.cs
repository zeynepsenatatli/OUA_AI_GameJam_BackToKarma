using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    public bool IsDead;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
        void Die()
        {

            anim.SetBool("IsDead", true);

            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 2f);


        }



    }






}