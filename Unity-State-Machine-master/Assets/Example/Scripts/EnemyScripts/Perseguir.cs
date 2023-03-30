using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : MonoBehaviour
{
    NavMeshAgent cmpAgent;
    GameObject goPlayer;

    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cmpAgent.SetDestination(goPlayer.transform.position);

        if (cmpAgent.pathPending == false)
        {
            if (cmpAgent.remainingDistance < 0.5f)
            {
                GetComponent<StateMachine>().ChangeState("Atacar");
            }
        }

    }
}
