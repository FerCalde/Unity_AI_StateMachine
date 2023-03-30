using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Retornar : MonoBehaviour
{

    NavMeshAgent cmpAgent;

    [SerializeField]Transform posInicial;

    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        cmpAgent.SetDestination(posInicial.position);

        if (cmpAgent.pathPending == false)
        {
            if (cmpAgent.remainingDistance < 0.5f)
            {
                GetComponent<StateMachine>().ChangeState("Idle");
            }
        }
    }
}
