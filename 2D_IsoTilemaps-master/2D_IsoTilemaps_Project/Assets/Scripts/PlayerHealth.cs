using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public bool isDead;
    [SerializeField] float maxHP = 100;
    float currentHP;
    public GameObject player;

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
        healthBar.value = currentValue / maxValue;
    }

    // used when player is taking damage
    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            isDead = true;
            Destroy(player);
        }
    }
}
