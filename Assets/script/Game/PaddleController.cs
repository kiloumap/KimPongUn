using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
    {
    #region Members
    public float Speed = 10.0f;
    public float SpeedModificationOnEachRoboundForpaddle = 0.7f;
    public int idPaddle = 0;
    private Rigidbody rb = null;
    #endregion

    #region Manipaltors
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update () {
        if(idPaddle == 1)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                rb.MovePosition(transform.position + Vector3.back * Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * Speed);
            }
        }else if (idPaddle == 2)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.MovePosition(transform.position + Vector3.back * Time.deltaTime * Speed);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * Speed);
            }
        }
    }

    public void IncreesePaddleSpeed()
    {
        Speed = Speed * SpeedModificationOnEachRoboundForpaddle;
    }
    #endregion
}
