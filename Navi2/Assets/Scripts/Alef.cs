using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alef : MonoBehaviour
{
    public char Letter; 
    public float rotationSpeed = 80f;
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
        //only if player
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        if (Boom != null)
        {
            spin = false;
            Boom.transform.position = transform.position;
            Boom.SetActive(true);
            GameManager.Instance.SetLetter(Letter);
            StartCoroutine(SetActiveAfterSeconds(2));
        }
    }

    IEnumerator SetActiveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        Boom.SetActive(false);
    }
}
