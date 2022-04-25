using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    private TMP_Text burnText;
    [SerializeField]
    private TMP_Text shockText;
    [SerializeField]
    private GameObject burn;
    [SerializeField]
    private GameObject shock;
    public Enemy enemy;
    void Start()
    {
        
    }

    void Update()
    {
        burnText.text = enemy.burn.ToString();
        shockText.text = enemy.shock.ToString();
        if (enemy.burn > 0)
        {
            burn.SetActive(true);
        }
        else
        {
            burn.SetActive(false);
        }
        if (enemy.shock > 0)
        {
            shock.SetActive(true);
        }
        else
        {
            shock.SetActive(false);
        }
    }
}
