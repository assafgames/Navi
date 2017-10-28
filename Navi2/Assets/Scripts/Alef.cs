using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alef : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject Boom;
    private bool spin = true;

    void Update()
    {
        if (spin)
        {
            // Rotate the object around its local X axis at 1 degree per second
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Boom != null)
        {
            spin = false;
            transform.rotation = other.transform.rotation;

            Boom.SetActive(true);
        }
    }
}
