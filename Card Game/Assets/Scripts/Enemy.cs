using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemy : MonoBehaviour
{
    public EnemyDetails[] enemies;
    public Sprite[] backdrops;
    [SerializeField]
    public int enemyNo;
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
    public int shock;
    public string Name;

    public GameObject background;
    public TurnController turnController;
    public Animator hitEffect;
    public Animator PlayerHitEffect;
    public Player player;
    public TMP_Text intentText;
    public SpriteRenderer spriteRenderer;
    public EnemyHealthBar enemyHealthBar;

    void Start()
    {
        enemyNo = 0;
    }

    public void SpawnEnemy()
    {
        background.GetComponent<SpriteRenderer>().sprite = backdrops[enemies[enemyNo].backDropID];
        Name = enemies[enemyNo].enemyName;
        attack = enemies[enemyNo].enemyAttack;
        blockStat = enemies[enemyNo].enemyBlock;
        spriteRenderer.sprite = enemies[enemyNo].enemyArt;
        maxHP = enemies[enemyNo].enemyHP;
        currentHP = maxHP;
        burn = 0;
        burn2 = 0;
        block = 0;
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
        if (currentHP <= 0)
        {
            if ((enemyNo+1) == enemies.Length)
            {
                SceneManager.LoadScene("Victory");
            }
            else
            {
                enemyNo++;
            }
            turnController.Reward();
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
            case "Lightning":
                hitEffect.SetTrigger("Lightning");
                break;
        }
    }

    public void Burn(int plusBurn, int burnFactor)
    {
        burn += plusBurn;
        if(burnFactor < 1)
        {
            burnFactor = 1;
        }
        burn = burn * burnFactor;
    }
          
    public void Shock(int plusShock)
    {
        shock += plusShock;
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
            player.Hit(enemies[enemyNo].attackType);
        }
        if (intent == 2)
        {
            GainBlock(blockStat);
        }
        attack = enemies[enemyNo].enemyAttack;
        blockStat = enemies[enemyNo].enemyBlock;
    }

    void Update()
    {
        HPProportion = currentHP / maxHP;
        if (block < 0)
        {
            block = 0;
        }
        if(shock >= 10){
            Hurt(10);
            Hit("Lightning");
            shock = 0;
        }
    }
}


    