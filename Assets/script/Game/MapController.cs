using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Map Controller
/// </summary>
public class MapController : MonoBehaviour {
    public Rigidbody rb;
    SoundController sc;
    
    
    void Start () {
        sc = GameObject.FindObjectOfType<SoundController>();
        sc.RunGeneralSound();
        rb = GetComponent<Rigidbody>();
    }
	
	
	void Update () {
    
    }   
}
