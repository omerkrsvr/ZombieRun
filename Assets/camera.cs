using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    GameObject karakterd;
    public float ymesafe, xmesafe;
    // Use this for initialization
    void Start()
    {
        karakterd = GameObject.FindGameObjectWithTag("karakter");
    }
    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(karakterd.transform.position.x + xmesafe, karakterd.transform.position.y + ymesafe, karakterd.transform.position.y);
    }
}
