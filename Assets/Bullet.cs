using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	
	private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent < Rigidbody > ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		rb.velocity= transform.forward*speed;
/*		speed-=0.001f;	
		if (speed < 0){
			Destroy(this.gameObject);
		}*/
    }
	
}
