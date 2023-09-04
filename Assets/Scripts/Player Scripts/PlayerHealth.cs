using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public static event Action OnPlayerDeath; 

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;

    public GameManegerScript GameManager;
    private bool isDead = false;
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
        if (isDead) { return; }

        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);

        if (currentHealth <= 0 && !isDead)
        {
            //player Dye
            isDead = true;
            Debug.Log("Player Dead!");
            OnPlayerDeath?.Invoke();
            gameObject.SetActive(false); //the player disappears when he dies.
            
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            healthBar.SetHealth(currentHealth); 
        }

    }
    public bool IsDead()
    {
        return isDead;
    }
    

}
