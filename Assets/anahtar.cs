using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anahtar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag=="karakter")
        {
            karakter.anahtar_sayisi++;
            Debug.Log(karakter.anahtar_sayisi);
            GameObject.Destroy(this.gameObject);
        }
    }

}
