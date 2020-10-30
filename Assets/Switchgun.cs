using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchgun : MonoBehaviour
{
	public GameObject[] Guns;
	public GameObject CurrentGun;
	public float max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
		{
			for (int i = 0; i < Guns.Length; i++) 
			{
				if (Guns[i] != CurrentGun)
				{
					if (Vector3.Distance(transform.position, Guns[i].transform.position) < max)
					{
						CurrentGun.transform.parent = null;
						CurrentGun.transform.position = Guns[i].transform.position;
						if (CurrentGun.gameObject.name == "thompson")
						{
							CurrentGun.transform.eulerAngles = new Vector3(0f, 0f, 90f);							
						}
						else if (CurrentGun.gameObject.name == "MachineGun_01 parent")
						{
							CurrentGun.transform.eulerAngles = new Vector3(90f, 90f, 0f);							
						}
						else if (CurrentGun.gameObject.name == "SubmachineGun")
						{
							CurrentGun.transform.eulerAngles = new Vector3(90f, 90f, 0f);							
						}
						else if (CurrentGun.gameObject.name =="SVDparent")
						{
							CurrentGun.transform.eulerAngles = new Vector3(90f, 90f, 0f);							
						}
						CurrentGun = Guns[i];
						CurrentGun.transform.parent = this.gameObject.transform;
							if (CurrentGun.gameObject.name == "MachineGun_01 parent")
							{
							CurrentGun.transform.localEulerAngles = new Vector3(0f, 86.999f, 0f);
							CurrentGun.GetComponent<Shoot>().starting = new Vector3(0.17125f, -0.7f, 0.30337f);
							CurrentGun.transform.localPosition = new Vector3(0.17125f, -0.7f, 0.30337f);
							}
							else if (CurrentGun.gameObject.name == "SubmachineGun")
							{
								CurrentGun.transform.localEulerAngles = new Vector3(0f, 90.58401f, 0f);
								CurrentGun.GetComponent<Shoot>().starting = new Vector3(0.127f, -0.713f, 1.311f);
								CurrentGun.transform.localPosition = new Vector3(0.127f, -0.713f, 1.311f);
							}
							else if (CurrentGun.gameObject.name == "thompson")
							{
								CurrentGun.transform.localEulerAngles = new Vector3(0f, 1.5f, 0f);
								CurrentGun.GetComponent<Shoot>().starting = new Vector3(0.3f, -0.67f, 1.384f);
								CurrentGun.transform.localPosition = new Vector3(0.3f, -0.67f, 1.384f);
								
							}
							else if (CurrentGun.gameObject.name == "SVDparent")
							{
								CurrentGun.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
								CurrentGun.GetComponent<Shoot>().starting = new Vector3(0.38f, -1.41f, 2.31f);
								CurrentGun.transform.localPosition = new Vector3(0.38f, -1.41f, 2.31f);
							}
						break;
					}
				}
			}
		}
    }
}
