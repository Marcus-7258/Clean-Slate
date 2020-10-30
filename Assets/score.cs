using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
	public int points;
	public Text scoretext; 
    // Start is called before the first frame update
    void Start()
    {
	
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "score:" + points;
    }
}
// Always save :)