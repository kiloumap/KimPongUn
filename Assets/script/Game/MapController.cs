using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
    public Rigidbody rb;
    SoundController sc;
    
    // Use this for initialization
    void Start () {
        sc = GameObject.FindObjectOfType<SoundController>();
        sc.RunGeneralSound();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
    
    }   
}
