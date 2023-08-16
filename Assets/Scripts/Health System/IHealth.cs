using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    
    public void SetMaxHealth(int maxHealth, int healAmount);

    public void TakeDamage(int damageAmount);

    public void Heal(int healAmount);

}
