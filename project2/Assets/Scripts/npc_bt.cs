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
    [Tooltip("The NPC which is the slender enemy")]
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
    public void PickRandomDestination()//slender picks a random destination in the make
    {
        Vector3 dest = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)); //range of x and z position is from -100 and 100
        agent.SetDestination(dest);//send agent slender to destination position
        Task.current.Succeed();//return succeed of task
    }

    [Task]
    public void TargetPlayer()//target the position of the player
    {
        target = player.transform.position;//set target to be position of player
        Task.current.Succeed();//return succeed of task 
    }
    [Task]
    public void LookAtTarget()//make slender look towards the player
    {
        Vector3 direction = target - this.transform.position;//vector of turn of NPC to look at player
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 1f);//change rotation of the NPC to become towards player position
        Task.current.Succeed();//return succeed of task
    }
    [Task]
    public void GoToTarget()//slender moves towards player
    {
        agent.SetDestination(target);//set destination towards target which is the player
        Task.current.Succeed();//return succeed

    }


}
