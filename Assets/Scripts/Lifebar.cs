using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    LifeController item;
    [SerializeField] LifeController lifeBar;
    [SerializeField] Image bar;

    private void Start()
    {
        item = lifeBar;

        item.damagedEvent += BarUpdate;
        item.healedEvent += BarUpdate;
    }

    public void LifeBarUpdates(float currentLife)
    {
        Debug.Log(currentLife);
    }

    //private void OnEnable()
    //{
    //    if (item != null)
    //    {
    //        item.damagedEvent += LifeBarUpdates;
    //    }
    //}

    //private void OnDisable()
    //{
    //    if (item != null)
    //    {
    //        item.damagedEvent -= LifeBarUpdates;
    //    }
    //}

    public void BarUpdate(float updates)
    {
        if (bar != null && lifeBar != null)
        {
            bar.fillAmount = updates / lifeBar.maxHealth;
        }
    }
}