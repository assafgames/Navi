using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alef : MonoBehaviour
{
    public char Letter;
    public float rotationSpeed = 80f;

    private Level1Manager levelManager;

    void Awake()
    {
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<Level1Manager>();
    }

    void Update()
    {
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        //only if player
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        levelManager.HighlightLetter(Letter);

    }

}
