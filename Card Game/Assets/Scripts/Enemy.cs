using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    
    public EnemyDetails enemyDetails;
    public float currentHP;
    public int maxHP;
    public float HPProportion;
    [SerializeField]
    private int newDamage;
    [SerializeField]
    public int block;
    [SerializeField]
    public int blockStat;
    [SerializeField]
    public int attack;
    [SerializeField]
    public int intent;
    [SerializeField]
    public int burn;
    [SerializeField]
    public int burn2;
    public string Name;

    public Animator hitEffect;
    public Animator PlayerHitEffect;
    public Player player;
    public TMP_Text intentText;
    public SpriteRenderer spriteRenderer;
    public EnemyHealthBar enemyHealthBar;

    void Start()
    {
        Name = enemyDetails.enemyName;
        attack = enemyDetails.enemyAttack;
        blockStat = enemyDetails.enemyBlock;
        spriteRenderer.sprite = enemyDetails.enemyArt;
        maxHP = enemyDetails.enemyHP;
        currentHP = maxHP;
        RandIntent();
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
           

public void GainBlock(int plusBlock)
    {
        block += plusBlock;
    }

    public void RandIntent()
    {
        attack = Random.Range((attack-2),(attack+2));
        blockStat = Random.Range((blockStat-1),(blockStat+1));
        intent = Random.Range(1,3);
        if (intent == 1)
        {
            intentText.text = "Incoming - Attack :" + attack;
        }if (intent == 2)
        {
            intentText.text = "Incoming - Block :" +  blockStat;
        }
    }

    public void Action()
    {
        Hurt(burn);
        if(burn > 0)
        {
            Hit("Fire");
        }
        else
        {

        }
        burn2 = burn / 2;
        burn = burn2;
        block = 0;
        if (intent == 1)
        {
            player.Hurt(attack);
            player.Hit(enemyDetails.attackType);
        }
        if (intent == 2)
        {
            GainBlock(blockStat);
        }
        attack = enemyDetails.enemyAttack;
        blockStat = enemyDetails.enemyBlock;
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


    