using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float dValue;


    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeController collisionedHealth;
        if (other.CompareTag("Player") && other.TryGetComponent(out collisionedHealth))
        {
            collisionedHealth.TakeDamage(dValue);

            //Destroy(gameObject);

        }
    }
}
