using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private MoveInWayPoints moveInWayPoints;
    //public UImanager uiManager;
    public string textToShow = "";
    private Transform playerTransform;
    private int range = 10;
    private bool interacts = false;

    void Awake()
    {
        moveInWayPoints = GetComponent<MoveInWayPoints>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        bool inRange = Vector3.Distance(transform.position, playerTransform.position) < range;
        if (inRange)
        {
            if (!interacts)
            {
                interacts = true;
                StopWalking();
                //uiManager.ShowPanel(textToShow);
                GameManager.Instance.ShowText(textToShow);
            }
            RotateTowards(playerTransform);
        }
        else
        {
            if (interacts)
            {
                Walk();
                //uiManager.HidePanel();
                GameManager.Instance.HideText();

                interacts = false;
            }
        }
    }

    private void Walk()
    {
        WalkOrStop(true);
    }

    private void StopWalking()
    {
        WalkOrStop(false);
    }

    private void WalkOrStop(bool walk)
    {
        if (moveInWayPoints == null)
        {
            return;
        }

        if (walk)
        {
            moveInWayPoints.Walk();
        }
        else
        {
            moveInWayPoints.StopWalking();
        }
    }

    private void RotateTowards(Transform target)
    {
        transform.LookAt(target);
        //Vector3 direction = (target.position - transform.position).normalized*-1;
        //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        //transform.rotation =  Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }


}
