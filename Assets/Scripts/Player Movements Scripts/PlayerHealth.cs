using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour , IHealth
{

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth(maxHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Clamp(healAmount, 0, maxHealth);

        healthBar.SetHealth(currentHealth);

    }

    public void SetMaxHealth(int maxHealth, int healAmount)
    {
        healthBar.SetMaxHealth(maxHealth);

        Heal(healAmount);

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Clamp(damageAmount, 0, maxHealth);

        if(currentHealth <= 0)
        {
            //player Dye
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }

    }


}
