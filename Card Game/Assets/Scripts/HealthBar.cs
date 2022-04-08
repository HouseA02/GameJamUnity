using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fill;
    [SerializeField]
    private TMP_Text valueText;
    private int maxHP;
    public Player player;
    
    void Update()
    {
        fill.fillAmount = player.HPProportion;
        valueText.text = player.currentHP + "/" + player.maxHP;
    }
}
