using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyName : MonoBehaviour
{
    public Enemy enemy;
    public TMP_Text nameText;

    // Update is called once per frame
    void Update()
    {
        nameText.text = enemy.Name;
    }
}
