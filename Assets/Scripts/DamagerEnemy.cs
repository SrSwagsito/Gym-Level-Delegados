using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float dValue;
    Collider2D thisCol;

    private void Start()
    {
        thisCol = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeController collisionedHealth;
        if (other.CompareTag("Player") && other.TryGetComponent(out collisionedHealth))
        {
            collisionedHealth.TakeDamage(dValue);

            Destroy(gameObject);

        }
    }
    public void ActivateCollider()
    {
        thisCol.enabled = true;

    }
    public void DeActivateCollider()
    {
        thisCol.enabled = false;

    }
}