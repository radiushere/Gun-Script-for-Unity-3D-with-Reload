using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    public GameObject enemyObject;
    public TextMeshProUGUI enemyHealth;

    // Update is called once per frame
    void Update()
    {
        enemyHealth.text = "Dominion's Hand: " + health;

        if (health <= 0)
        {
            Destroy(enemyObject);
        }
    }
}
