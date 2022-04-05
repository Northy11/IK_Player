using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    int phase = 1;
    [SerializeField]
    public bool isDead = false;

    public Monster monster;

    void Start()
    {
        currentHealth =  maxHealth ;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= (maxHealth / 2))
        {
            if (phase == 1)
            {
                phase++;
            }
        }
        if (currentHealth <= (maxHealth * 0.25))
        {
            if (phase == 2)
            {
                phase++;

                //Write a method to check if any other attack is ongoing


                //    monster.StartCoroutine("Summon");
            }
        }
    }
    public void TakeDamage(int _amount)               //  string _sourceId for different damage from different sources.
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= _amount;
        //  healthbar.AddRemovePercent(_amount);
        if (currentHealth <= 0)
        {
            isDead = true;

        }
    }
}