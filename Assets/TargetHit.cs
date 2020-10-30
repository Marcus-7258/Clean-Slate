using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
	public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void OnCollisionEnter(Collision c){
		if(c.gameObject.tag == "Bullet" && c.gameObject.name != "Bullet Variant" && c.gameObject.name != "45acp" && c.gameObject.name != "Bullet Variant (1)" && c.gameObject.name != "BULLET"){
			canvas.GetComponent<score>().points++;
			this.transform.Rotate(90f,0f,0f, Space.World);
			Destroy(c.gameObject);
			StartCoroutine(GetHit());
		}
	}
	IEnumerator GetHit()
	{
		yield return new WaitForSeconds(5);
		this.transform.Rotate(-90f,0f,0f, Space.World);
	}
}