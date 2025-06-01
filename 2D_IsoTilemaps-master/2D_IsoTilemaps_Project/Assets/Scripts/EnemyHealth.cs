using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Ref")]
    public Slider Slider;
    public GameObject UI;
    public GameObject explodeVFX;

    [Header("Setting")]
    public bool isDead;
    [SerializeField] float maxHP = 100;
    float currentHP;

    void Start()
    {
        // set initial hp to max value
        currentHP = maxHP;
        ChangeHPBar(currentHP, maxHP);
    }

    private void Update()
    {
        // always update all the change to hp bar
        ChangeHPBar(currentHP, maxHP);
    }

    // update hp bar with the current value
    void ChangeHPBar(float currentValue, float maxValue)
    {
        Slider.value = currentValue / maxValue;
    }

    // used when the enemy is taking damage
    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            isDead = true;
            Destroy(gameObject);
            //Instantiate(explodeVFX, UI.transform.position, Quaternion.identity);
            
        }        
    }
}
