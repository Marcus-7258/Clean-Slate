using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public GameObject Bullet;
	public Transform BulletLoc;
	public Vector3 starting; 
	public GameObject player;
	public int BulletCount;
	public GameObject canvas;
	public GameObject camera;
 	private int StartBulletCount;
	private bool press; 
	private Animator anim;
	private bool Reloadpress;
	private AudioSource audio;
    // Start is called before the first frame update
    void Start(){
        starting = this.transform.localPosition;
		press = false;
		anim = this.GetComponent<Animator>();
		StartBulletCount = BulletCount;
		Reloadpress = false;
		audio = this.GetComponent<AudioSource>();
		canvas.SetActive(false);
    }
	IEnumerator shoot(){
		if (gameObject.name == "SVDparent")
		{
			if (BulletCount > 0){
				Instantiate	(Bullet, new Vector3(BulletLoc.position.x, BulletLoc.position.y, BulletLoc.position.z), player.transform.rotation, null);
				BulletCount--;
				audio.Play();
				yield return new WaitForSeconds(0.12f);
			}
			if (BulletCount == 0){
				anim.SetTrigger("Shoot");
				press = false;
				audio.Stop();
			}
		}else
		{
			while (press && BulletCount>0){
				if (BulletCount > 0){
					Instantiate	(Bullet, new Vector3(BulletLoc.position.x, BulletLoc.position.y, BulletLoc.position.z), player.transform.rotation, null);
					BulletCount--;
					audio.Play();
					yield return new WaitForSeconds(0.12f);
				}
				if (BulletCount == 0){
					anim.SetTrigger("Shoot");
					press = false;
					audio.Stop();
				}
			}	
		}
	}
	IEnumerator reload (){
		if (this.gameObject.name == "MachineGun_01 parent")
				{
					yield return new WaitForSeconds(1.09f);					
				}
				else if (this.gameObject.name == "thompson")
				{
					yield return new WaitForSeconds(2.183f);
				}		
				else if (this.gameObject.name == "SubmachineGun")
				{
					yield return new WaitForSeconds(1.167f);
				}
				else if (this.gameObject.name == "SVDparent")
				{
					yield return new WaitForSeconds(1.667f);
				}
				anim.SetTrigger("DoReload");
		BulletCount = StartBulletCount;
		Reloadpress = false;
	}
    // Update is called once per frame
    void Update()
    {
		if (transform.parent != null && transform.parent.name == "Player")
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (BulletCount > 0 && press == false){
					press = true;
					anim.SetTrigger("Shoot");
					StartCoroutine("shoot");
				}
			}	
			else if (Input.GetMouseButtonUp(0))
			{
			if (BulletCount >= 0 && press == true)
				{
					anim.SetTrigger("Shoot");
					press = false;
					audio.Stop();
				}
			}
			if (Input.GetMouseButtonDown(1))
			{
				if (this.gameObject.name == "MachineGun_01 parent")
				{
					this.transform.localPosition = new Vector3(-0.03f, -0.53f, 0.119f);	
				}
				else if (this.gameObject.name == "thompson")
				{
					this.transform.localPosition = new Vector3(0.028f, -0.6400001f, 1.143f);
					this.transform.localEulerAngles = new Vector3(0f, 1.5f, 0f);
				}
				else if (this.gameObject.name == "SubmachineGun")
				{
					this.transform.localPosition = new Vector3(0.02f, -0.618f, 1.311f);
					this.transform.localEulerAngles = new Vector3(0f, 90.58401f, 0f);
				}
				else if (this.gameObject.name == "SVDparent")
				{
					this.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
					canvas.SetActive(true);
					for (int i=0; i<transform.childCount-1; i++)
					{
						transform.GetChild(i).gameObject.SetActive(false);
					}
					camera.transform.localPosition = new Vector3(0f, 0f, 26.53f);
//				Debug.Log(camera.transform.localPosition);
				}
			}
			else if (Input.GetMouseButtonUp(1))
			{
				this.transform.localPosition = starting;
				canvas.SetActive(false);
				for (int i=0; i<transform.childCount-1; i++)
				{
					transform.GetChild(i).gameObject.SetActive(true);
				}
				camera.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
			if (Input.GetKeyDown(KeyCode.R) && BulletCount == 0 && press == false && Reloadpress == false){
				anim.SetTrigger("DoReload");
				StartCoroutine("reload");
				Reloadpress = true;
			}
		}
	}
}
//Always Save :)
//Always put a semicolon in each line except the if statements, functions, loops, yeah thats it:D