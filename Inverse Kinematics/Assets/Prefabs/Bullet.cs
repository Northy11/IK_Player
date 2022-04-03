using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //If boss does damage
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Damage");
        }
        Destroy(this.gameObject, 0.5f);
    }
}
