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
    private GameObject burn;
    public Enemy enemy;
    void Start()
    {
        
    }

    void Update()
    {
        burnText.text = enemy.burn.ToString();
        if (enemy.burn > 0)
        {
            burn.SetActive(true);
        }
        else
        {
            burn.SetActive(false);
        }
    }
}
