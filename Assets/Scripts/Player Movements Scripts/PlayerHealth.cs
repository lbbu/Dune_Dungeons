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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }


    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Clamp(healAmount + currentHealth, 0, maxHealth);

        healthBar.SetHealth(currentHealth);

    }

    public void SetMaxHealth(int maxHealth, int healAmount)
    {
        this.maxHealth = maxHealth;

        healthBar.SetMaxHealth(this.maxHealth);

        Heal(healAmount);

    }

    public void IncreaseMaxHealth(int maxHealthAmount, int healAmount)
    {

        SetMaxHealth(maxHealth + maxHealthAmount, healAmount);

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);

        if(currentHealth <= 0)
        {
            //player Dye
            Debug.Log("Dye");
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }

    }


}
