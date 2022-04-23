using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shield : MonoBehaviour

{
    [SerializeField]
    private TMP_Text BlockText;
    [SerializeField]
    private GameObject shield;
    public Player player;
    public Animator animator;

    void Update()
    {
        BlockText.text = player.block.ToString();
        animator.SetInteger("Block", player.block);
        if (player.block <= 0)
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
        if (player.block > 0)
        {
            animator.SetTrigger("GainBlock");
        }
        else
        {
            animator.SetTrigger("LoseBlock");
        }
    }

}

