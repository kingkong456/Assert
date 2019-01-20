using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRollerBallController : MonoBehaviour {
    private Rigidbody m_rb;
    public float speed;

	// Use this for initialization
	void Start ()
    {
        m_rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveMent = new Vector3(horizontal, 0, vertical);
        m_rb.AddForce(moveMent * speed * Time.deltaTime);
	}
}
