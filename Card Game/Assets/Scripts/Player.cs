using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float currentHP;
    public int currentMana;
    public float HPProportion;
    public int maxHP;
    public int maxMana;
    public int block;
    private int newDamage;

    public Animator hitEffect;
    public HealthBar healthBar;
    public Mana mana;
    public Card card;

    void Start()
    {
        maxHP = 50;
        maxMana = 3;
        currentHP = maxHP;
        currentMana = maxMana;
    }

    public void reset()
    {
        currentMana = maxMana;
        block = 0;
    }

    public void Hit(string type)
    {
        switch (type)
        {
            case "Fire":
                hitEffect.SetTrigger("Fire");
                break;
            case "Magic":
                hitEffect.SetTrigger("Magic");
                break;
            case "Physical":
                hitEffect.SetTrigger("Physical");
                break;

        }
    }

    public void Hurt(int damage)
    {
        newDamage = damage - block;
        block -= damage;
        if (newDamage < 0)
        {
            newDamage = 0;
        }
        if (currentHP - newDamage < 0)
        {
            currentHP = 0;
        }
        else
        {
            currentHP -= newDamage;
        }
    }

    public void GainBlock(int plusBlock)
    {
        block += plusBlock;
    }

    public void SpendMana(int manaCost)
    {
        currentMana -= manaCost;
    }
    void Update()
    {
        HPProportion = currentHP / maxHP;
        if (block < 0)
        {
            block = 0;
        }

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
