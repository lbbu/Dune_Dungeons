using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class EnemyHealth : MonoBehaviour,IEnemy, IHealth
{
    

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;

    private bool isDead = false;

    public bool IsDead() => isDead;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth(maxHealth, maxHealth);
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

        if (currentHealth <= 0)
        {
            //Enemy Dye
            Debug.Log("Enemy Dye");
            healthBar.SetHealth(currentHealth);
            isDead = true;
           //Destroy(gameObject);
           // ScoreManager.Instance.IncrementScore();
        }
        else
        {
            healthBar.SetHealth(currentHealth);
        }

    }


}
