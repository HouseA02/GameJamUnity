using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyShield : MonoBehaviour

{
    [SerializeField]
    private TMP_Text BlockText;
    [SerializeField]
    private GameObject shield;
    public Enemy enemy;
    public Animator Shield;

    void Update()
    {
        BlockText.text = enemy.block.ToString();
        Shield.SetInteger("Block", enemy.block);
        if (enemy.block <= 0)
        {
            BlockText.enabled = false;
        }
        else
        {
            BlockText.enabled = true;
        }
    }

    void CheckBlock()
    {
        if (enemy.block > 0)
        {
            Shield.SetTrigger("GainBlock");
        }
        else
        {
            Shield.SetTrigger("LoseBlock");
        }
    }

}
