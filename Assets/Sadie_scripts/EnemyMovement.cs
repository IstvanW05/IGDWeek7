using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private GameObject[] patrolPts;
    GameObject currentPt;
    int currentIndex = 0;
    bool isPatroling;

    [SerializeField] private GameObject player;

    private void Start()
    {
        //Get nav mesh agent, set patrol to true, get first point to move to
        agent = GetComponent<NavMeshAgent>();
        isPatroling = true;
        currentPt = patrolPts[currentIndex];
    }

    private void Update()
    {
        if(isPatroling)
        {
            EnemyPatrol();
        }
        else
        {
            ChasePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SwitchToChase(other);
    }

    private void OnTriggerExit(Collider other)
    {
        SwitchToPatrol(other);
    }

    void EnemyPatrol()
    {
        //Check if enemy is patroling
        if(isPatroling)
        {
            //Sets destination to patrol point
            agent.SetDestination(currentPt.transform.position);

            //If enemy has reached that point, then switches to the other patrol point
            if(System.Math.Round(transform.position.x, 2) == System.Math.Round(currentPt.transform.position.x, 2) && System.Math.Round(transform.position.z, 2) == System.Math.Round(currentPt.transform.position.z, 2))
            {
                ChangePoint();   
            }
        }
    }

    void ChangePoint()
    {
        //Checks current index, switches to other index
        if(currentIndex == 0)
        {
            currentIndex = 1;
        }
        else if(currentIndex == 1)
        {
            currentIndex = 0;
        }

        //uses new index to switch patrol point
        currentPt = patrolPts[currentIndex];
    }

    void ChasePlayer()
    {
        //Set enemy destination to player
        agent.SetDestination(player.transform.position);
    }

    void SwitchToChase(Collider _other)
    {
        //Check if colliding object is the player
        if(_other.gameObject.layer == 6)
        {
            //Set patrolling false, enter chase state
            isPatroling = false;
        }
    }

    void SwitchToPatrol(Collider _other)
    {
        //Check if colliding object is the player
        if (_other.gameObject.layer == 6)
        {
            //Set patrolling true, enter patrol state
            isPatroling = true;
        }
    }
}
