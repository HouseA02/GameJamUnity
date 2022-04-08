using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fill;
    [SerializeField]
    private TMP_Text valueText;
    private int maxHP;
    public Enemy enemy;

    void Update()
    {
        fill.fillAmount = enemy.HPProportion;
        valueText.text = enemy.currentHP + "/" + enemy.maxHP;
    }
}
