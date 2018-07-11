using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraViewHelper : MonoBehaviour
{

    public float eageSize = 100f;
    public float rotateSpeed = 1f;

    private Quaternion originalRotation;

    private NavMeshAgent navMeshAgent;
    void Start()
    {
        originalRotation = transform.localRotation;
        var targetObj = GameObject.FindGameObjectWithTag("Player");
        if (targetObj)
        {
            navMeshAgent = targetObj.GetComponent<NavMeshAgent>();
        }

    }
    void Update()
    {

        // if player is moving go to center
        if (!navMeshAgent.isStopped)
        {
            LerpToOriginalRotation();
            return;
        }
        

        if (Input.mousePosition.x > 0 && Input.mousePosition.x < eageSize)
        {
            transform.transform.Rotate(Vector3.up, -rotateSpeed);
        }
        else if (Input.mousePosition.x > Screen.width - eageSize && Input.mousePosition.x < Screen.width)
        {
            transform.transform.Rotate(Vector3.up, rotateSpeed);
        }
        else if (Input.mousePosition.x > Screen.width / 2 - eageSize && Input.mousePosition.x < Screen.width / 2 + eageSize)
        {
            LerpToOriginalRotation();
        }
    }

    private void LerpToOriginalRotation()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, rotateSpeed * Time.deltaTime);
    }
}
