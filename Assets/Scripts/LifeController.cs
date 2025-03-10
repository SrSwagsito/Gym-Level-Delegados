using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] float actualHealth;
    [SerializeField] public float maxHealth;
    //Delegado
    public delegate void HealthUpdatesDelegate(float currentHealth);
    //Evntos
    public HealthUpdatesDelegate damagedEvent;
    public HealthUpdatesDelegate healedEvent;
    public HealthUpdatesDelegate dieEvent;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
             actualHealth = maxHealth;
    }

    public void TakeHeal(float healer)
    {

        actualHealth += healer;
        healedEvent?.Invoke(actualHealth);
        if (actualHealth > maxHealth)
        {
            actualHealth = maxHealth;
        }

    }
    public void TakeDamage(float damage)
    {
        actualHealth -= damage;
        animator.SetTrigger("Damage");

        damagedEvent?.Invoke(actualHealth);
        if (actualHealth <= 0)
        {
            dieEvent?.Invoke(actualHealth);
            //animator.SetBool("Death");
            gameObject.SetActive(false);
            
        }

    }
}