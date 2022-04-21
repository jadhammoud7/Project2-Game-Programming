using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using UnityEngine.AI;
using UnityEngine.UI;

public class npc_bt : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 target;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    [Task]
    public void PickRandomDestination()
    {
        Vector3 dest = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
        agent.SetDestination(dest);
        Task.current.Succeed();
    }
    // [Task]
    // public void MoveToDestination()
    // {
    //     if (Task.isInspected)
    //     {
    //         if (agent.remainingDistance<=agent.stoppingDistance && !agent.pathPending){
    //             Task.current.Succeed();
    //         }
    //     }
    // }
    [Task]
    public void TargetPlayer()
    {
        target = player.transform.position;
        Task.current.Succeed();
    }
    [Task]
    public void LookAtTarget()
    {
        Vector3 direction = target - this.transform.position;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 1f);
        Task.current.Succeed();


    }
    [Task]
    public void GoToTarget()
    {
        agent.SetDestination(target);
        Task.current.Succeed();

    }


}
