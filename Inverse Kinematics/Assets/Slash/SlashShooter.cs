using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashShooter : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform firePoint;
    public float fireRate = 4;

    Vector3 destination;
    float timeTofire;
    private GroundSlash slash;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeTofire)
        {
            timeTofire = Time.time + (1 / fireRate);
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        destination = ray.GetPoint(1000);
        InstantiateProjectile();
    }

    void InstantiateProjectile()
    {
        var projectileObject = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        slash = projectileObject.GetComponent<GroundSlash>();
        RotateToDestination(projectileObject, destination, true);
        projectileObject.GetComponent<Rigidbody>().velocity = transform.forward * slash.speed;
    }

    void RotateToDestination(GameObject ob, Vector3 destination, bool onlyV)
    {
        var direction = destination - ob.transform.position;
        var rotation = Quaternion.LookRotation(direction);

        if(onlyV)
        {
            rotation.x = 0;
            rotation.z = 0;
        }

        ob.transform.localRotation = Quaternion.Lerp(ob.transform.rotation, rotation, 1);
    }
}
