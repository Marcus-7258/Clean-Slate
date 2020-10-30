using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private float xangle;
	private Rigidbody rb;
	public float speed;
	public float turningspeed;
	// Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		xangle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float mz = Input.GetAxis("Vertical");
        float mx = Input.GetAxis("Horizontal");		
		rb.AddForce(transform.forward*mz*speed);
		rb.AddForce(transform.right*mx*speed);
		xangle+=turningspeed*Input.GetAxis("Mouse X");
		transform.eulerAngles = new Vector3(0f,xangle,0f);
    }
}
