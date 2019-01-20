using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomPath : MonoBehaviour {
    private EnemyController m_controller;

    [Header("Enemy path config")]
    public float max_z_distance;
    public float max_x_distance;
    private Vector3 origin_Point;
    private bool isOut_OriginPoint= false;
    private Vector3 nextPoint;
    private bool inWalker = false;

    [Header("Timer")]
    public float time_betaweetPath;
    private float timer;

	// Use this for initialization
	void Start ()
    {
        //setting varible
        m_controller = GetComponent<EnemyController>();

        origin_Point = transform.position;
        timer = time_betaweetPath;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(timer <= 0)
        {
            //goto next path
            //or
            //goto origin point
            if(isOut_OriginPoint && !inWalker)
            {
                //goto origin point
                nextPoint = origin_Point;
                inWalker = true;
            }
            else if(!isOut_OriginPoint &&  !inWalker)
            {
                //next point
                //random new point
                nextPoint = random_new_point();
                inWalker = true;
            }

            //set next point
            m_controller.m_agent.SetDestination(nextPoint);
            Debug.Log(Vector3.Distance(transform.position, nextPoint));

            //is end point yet?
            if(Vector3.Distance(transform.position, nextPoint) <= 1.5f)
            {
                //reset randomyet
                //set isoutorigin
                //reset timer
                isOut_OriginPoint = !isOut_OriginPoint;
                timer = time_betaweetPath;
                inWalker = false;
            }
        }
        else if(timer > 0)
        {
            //count down timer
            timer -= Time.deltaTime;
        }
	}

    Vector3 random_new_point()
    {
        //Random new point
        float x = Random.Range((-1 * max_x_distance), max_x_distance);
        float z = Random.Range((-1 * max_z_distance), max_z_distance);

        Vector3 newPoint = transform.position + new Vector3(x, 0, z);
        Debug.Log(newPoint);

        return newPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(max_x_distance, 0, max_z_distance));
    }
}
