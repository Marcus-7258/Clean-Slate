using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour

{
	public float speed;
	public GameObject player;
	private float xangle;
	private float yangle;
    // Start is called before the first frame update
    void Start()
    {
        xangle = 0f;
		yangle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
		yangle-=speed*Input.GetAxis("Mouse Y");
		transform.eulerAngles = new Vector3(yangle,player.transform.eulerAngles.y,0f);
    }
}
