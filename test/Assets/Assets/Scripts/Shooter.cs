using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Rigidbody projectile;
    public Transform gun;

    int bulletSpeed = 20;

    void Update()
    {
        // Put this in your update function
        if (Input.GetMouseButtonDown(0))
        {

            // Instantiate the projectile at the position and rotation of this transform
            Rigidbody clone = Instantiate(projectile, gun.transform.position, gun.transform.rotation);

            clone.AddForce(gun.transform.forward*bulletSpeed);

            Destroy(clone.gameObject, 3);
        }
    }
}
