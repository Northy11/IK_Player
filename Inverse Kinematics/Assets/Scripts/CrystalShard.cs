using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalShard : MonoBehaviour
{
    Rigidbody rigidbody;

    public GameObject impactCrystal;
    public bool useGravity = true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rigidbody.useGravity = false;
        if (useGravity) rigidbody.AddForce(Physics.gravity * (rigidbody.mass * rigidbody.mass));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
          //Damge
        }
        
        if(other.CompareTag("Floor"))
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject crys = Instantiate(impactCrystal, pos, Quaternion.Euler(0, Random.Range(-180f, 180f), 0));
            Destroy(crys, 10f);
            Destroy(gameObject, 10f);
        }
        
    }
    
}
