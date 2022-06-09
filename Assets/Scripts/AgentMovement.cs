using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AgentStates
{
    //looking for collectables
    Collect,
    //Move to goal
    Goal,
    //reach goal
    Finish
}

public class AgentMovement : MonoBehaviour
{
    #region Variables
    //list of collectables
    public List<GameObject> collectables;
    public int waypoint = 0;
    public int speed=10;
    //location of goal
    public GameObject goal;

    public NavMeshAgent agent;

    public AgentStates agentState;

    #endregion
    #region Methods
    private void MoveAgentToTarget(Transform target)
    {
        //move to target
      
            Vector2 directionToGoal = (target.position - transform.position);
            directionToGoal.Normalize();
            transform.position += (Vector3)directionToGoal * speed * Time.deltaTime;
        
    }
    void RemoveCollectable()
    {
        GameObject current = collectables[waypoint];
        collectables.Remove(current);
        Destroy(current);
    }
    void CollectItem()
    {
        if (Vector2.Distance(transform.position, collectables[waypoint].transform.position) < 0.1f)
        {
            RemoveCollectable();
            if (collectables.Count<=0)
            {

            }
            else
            {
                waypoint++;
                if (waypoint >= collectables.Count)
                {
                    waypoint = 0;
                }
            }
        
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (agentState)
        {
            case AgentStates.Collect:
                break;
            case AgentStates.Goal:
                break;
            case AgentStates.Finish:
                break;
            default:
                break;
        }
    }
}
