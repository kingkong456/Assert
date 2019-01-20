using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    public NavMeshAgent m_agent;

    [Header("Status Confin")]
    public float walk_speed;
    public float run_speed;
    private bool isWalk;
    private bool isRun;

	// Use this for initialization
	void Start ()
    {
        //setting varibel
        m_agent = GetComponent<NavMeshAgent>();

        m_agent.speed = run_speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
