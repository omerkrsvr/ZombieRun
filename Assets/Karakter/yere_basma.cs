using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yere_basma : MonoBehaviour {

    // Use this for initialization
    karakter k;
	void Start () {
        k = transform.root.GetComponent<karakter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D()
    { 
        k.yerdemi = true;
    }
}
