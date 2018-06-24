using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private MoveInWayPoints moveInWayPoints;
    //public UImanager uiManager;
    public string textToShow = "";
    public float textHeight = 4;
    public bool isStatic = false;
    private Transform playerTransform;
    private int range = 10;
    private bool interacts = false;

    private Level1Manager levelManager;

    void Awake()
    {
        if (!isStatic)
        {
            moveInWayPoints = GetComponent<MoveInWayPoints>();
        }
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        levelManager = GameObject.FindWithTag("LevelManager").GetComponent<Level1Manager>();
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
                Vector3 textPosition = new Vector3(transform.position.x, transform.position.y + textHeight, transform.position.z);
                levelManager.ShowText(textToShow, textPosition);
            }
            if (!isStatic)
            {
                RotateTowards(playerTransform);
            }

        }
        else
        {
            if (interacts)
            {
                Walk();
                levelManager.HideText();

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
        if (isStatic)
        {
            return;
        }

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
