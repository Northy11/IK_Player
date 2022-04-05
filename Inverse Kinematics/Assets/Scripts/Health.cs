using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RengeGames.HealthBars;
public class Health : MonoBehaviour
{
    public UltimateCircularHealthBar healthbar;
    private Transform spawnPoint;
    //[SerializeField]
   // RectTransform healthBarFill1;
    [SerializeField]
    private float maxHealth = 0.8f;
  
    [SerializeField]
    public bool isDead = false;
   //[SerializeField]
    //private Behaviour[] disableOnDeath;
    public float currentHealth;
    
    //[SerializeField]
    //private GameObject deathEffect;
    //[SerializeField]
    //private GameObject spawnEffect;
   
    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
       

        healthbar.SetSegmentCount(5);
        healthbar.SetRemovedSegments(1);
       
    }

    //HealthBar UI

    public void TakeDamage(float _amount)               //  string _sourceId for different damage from different sources.
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= _amount;
        healthbar.AddRemovePercent(_amount);
        if (currentHealth <= 0)
        {
            isDead = true;

        }
    }


  
   

    
   
}
