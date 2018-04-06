using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Members
    Rigidbody rb = null;
    ScoreController scoreC;
    SoundController soundC;
    private bool endOfGame = false;
    private int nextPosition;

    public float StartingSpeed = 10.0f;
    public float SpeedModificatorOnEachRoboundLol = 1.05f;
    public float Speed;
    #endregion

    #region Manipulators
    public void Start()
    {
        Speed = StartingSpeed;
        scoreC = GameObject.FindObjectOfType<ScoreController>();
        soundC = GameObject.FindObjectOfType<SoundController>();
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            enabled = false;
            return;
        }

        Randomize rnd = new Randomize();
        int rand = rnd.Rand(0, 101);
        if (rand > 50)
            nextPosition = -1;
        else
            nextPosition = 1;

        rb.position = new Vector3(20.0f, 0, 0);
        rb.velocity = new Vector3(nextPosition, 0, 0) * StartingSpeed;
    }

    public void Reset()
    {
        scoreC.Reset();
        Start();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && endOfGame)
        {
            Reset();
        }
        else if (Input.GetKey(KeyCode.Escape) && !endOfGame)
        {
            Debug.Log("Faudrait pouvoir restart #TODO");
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        MapController mc = collision.gameObject.GetComponent<MapController>();
        if (collision.gameObject.name == "West")
        {
            soundC.RunPointSound();
            endOfGame = scoreC.AddPoint(2);
            ResetBall(2);
        }
        else if (collision.gameObject.name == "East")
        {
            soundC.RunPointSound();
            endOfGame = scoreC.AddPoint(1);
            ResetBall(1);
        }
        else
        {
            soundC.RunWallSound();
        }

        if (collision.gameObject.name.StartsWith("Paddle"))
        {
            PaddleController pc = collision.gameObject.GetComponent<PaddleController>();
            Transform cube = pc.transform.Find("Cube");
            Transform center = cube.Find("Center");
            Transform positif = cube.Find("Positif");
            Transform negatif = cube.Find("Negatif");

            Vector3 contactPoint = collision.contacts[0].point;
            Transform maxRange = (Vector3.Dot(positif.position, contactPoint - center.position) > 0) ? positif : negatif;

            float MaxDist = Mathf.Abs(maxRange.position.z - center.position.z);
            float distBetweenCenterContact = Mathf.Abs(contactPoint.z - center.position.z);

            if (MaxDist != 0)
                rb.velocity = Vector3.Lerp(center.forward, maxRange.forward, distBetweenCenterContact / MaxDist).normalized * Speed;

            soundC.RunPaddleSound();
            pc.IncreesePaddleSpeed();
            IncreeseBallSpeed();
        }

        return;
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.velocity *= SpeedModificatorOnEachRoboundLol;
    }

    private void IncreeseBallSpeed()
    {
        Speed *= SpeedModificatorOnEachRoboundLol;
    }

    public void EndOfGame()
    {
        endOfGame = true;
        rb.velocity = Vector3.zero;
        rb.position = new Vector3(20.0f, 0, 0);
    }

    public void ResetBall(int winner)
    {

        if (winner == 1)
            nextPosition = -1;
        else
            nextPosition = 1;

        rb.position = new Vector3(20.0f, 0, 0);
        rb.velocity = new Vector3(nextPosition, 0, 0) * StartingSpeed;
    }
    #endregion

}