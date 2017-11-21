using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyme : MonoBehaviour {
    public float ALiveTime;
	// Use this for initialization
	void Start () {
        Destroy (gameObject, ALiveTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
