using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Paddle controller
/// </summary>
public class PaddleController : MonoBehaviour
    {
    #region Members
    public float Speed = 10.0f;                                         // Speed paddle
    public float SpeedModificationOnEachRoboundForpaddle = 0.7f;        // This speed decrease after each rebound
    public int idPaddle = 0;                                            // Id of paddle (to separate command for Player 1 / 2)
    private Rigidbody rb = null;
    #endregion

    #region Manipaltors
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void Update () {
        if(idPaddle == 1)
        {
            if (Input.GetKey(KeyCode.Q))
                rb.MovePosition(transform.position + Vector3.back * Time.deltaTime * Speed);
            if (Input.GetKey(KeyCode.D))
                rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * Speed);
        }else if (idPaddle == 2)
        {
            if (Input.GetKey(KeyCode.DownArrow))
                rb.MovePosition(transform.position + Vector3.back * Time.deltaTime * Speed);
            if (Input.GetKey(KeyCode.UpArrow))
                rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * Speed);
        }
    }

    /// <summary>
    /// Decrease paddle speed, car is fun
    /// </summary>
    public void DecreesePaddleSpeed()
    {
        Speed = Speed * SpeedModificationOnEachRoboundForpaddle;
    }
    #endregion
}
