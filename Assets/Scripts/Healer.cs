using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] float hValue;


    private void OnTriggerEnter2D(Collider2D other)
    {
        LifeController collisionedHealth;
        if (other.CompareTag("Player") && other.TryGetComponent(out collisionedHealth))
        {
            collisionedHealth.TakeHeal(hValue);

            Destroy(gameObject);

        }
    }
}
