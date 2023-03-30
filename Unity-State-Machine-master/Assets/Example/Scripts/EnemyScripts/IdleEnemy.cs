using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleEnemy : MonoBehaviour
{
    NavMeshAgent cmpAgent;
    [SerializeField] Transform[] puntosRuta;
    int puntoActualRuta = 0;

    Transform goPlayer;
    float distance2Player;
    [SerializeField] float distanceAlert = 5f;


    void Awake()
    {
        cmpAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        puntoActualRuta = 0;

        if (puntosRuta != null)
        {
            if (cmpAgent.enabled)
            {
                SetearDireccionPatrulla();
            }
        }
        goPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (cmpAgent.enabled)
        {
            ComprobarLlegadaDestino();
        }

        //Check Distance2Player and ChangeState ->  Perseguir
        distance2Player = Vector3.Distance(this.transform.position, goPlayer.position);
        if (distance2Player <= distanceAlert)
        {
            GetComponent<StateMachine>().ChangeState("Perseguir");
        }
    }

    void SetearDireccionPatrulla()
    {
        Transform destinoActual = puntosRuta[puntoActualRuta];
        cmpAgent.SetDestination(destinoActual.position);

    }
    void ComprobarLlegadaDestino()
    {
        if (cmpAgent.pathPending == false)
        {
            if (cmpAgent.remainingDistance < 0.5f)
            {
                if (puntoActualRuta == puntosRuta.Length - 1)
                {
                    puntoActualRuta = 0;
                }
                else
                {
                    ++puntoActualRuta;
                }

                SetearDireccionPatrulla();

            }
        }
    }
}
