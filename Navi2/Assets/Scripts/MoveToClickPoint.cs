
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MoveToClickPoint : MonoBehaviour
{
    public GameObject Marker;

    private NavMeshAgent navMeshAgent;
    private Animator anim;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the mouse was clicked over a UI element
        // if (EventSystem.current.IsPointerOverGameObject())
        // {
        //     return;
        // }

        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationToMouseClick();
        }
        //set animation state acoording to movment state
        anim.SetBool("Walk", !navMeshAgent.isStopped);

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!navMeshAgent.hasPath || Mathf.Abs(navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                navMeshAgent.isStopped = true;
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
    }

    /// <summary>
    /// Sets the destination to the correct place according to the mouse point
    /// </summary>
    private void SetDestinationToMouseClick()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
        {
            if (hit.collider.gameObject.name == "Terrain")
            {
                SetDestination(hit.point);
            }
            else if (hit.collider.tag == "Interactable")
            {
                Vector3 point = hit.collider.transform.position;
                point.y = Terrain.activeTerrain.SampleHeight(point);
                SetDestination(point);
            }
        }
    }

    /// <summary>
    /// Sets marker and new destination
    /// </summary>
    /// <param name="point"></param>
    public void SetDestination(Vector3 point)
    {
        navMeshAgent.destination = point;
        Marker.transform.position = point;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            navMeshAgent.isStopped = true;
        }
    }
}