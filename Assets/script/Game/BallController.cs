using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball controller
/// </summary>
public class BallController : MonoBehaviour
{
    #region Members
    // other controller needed
    Rigidbody rb = null;
    ScoreController scoreC;
    SoundController soundC;
    
    private bool endOfGame = false;                             // While false, game continuing 
    private int nextPosition;                                   // Int for know where the ball will going for the first rebound
    public float StartingSpeed = 10.0f;                         // Init speed, for reset later
    public float SpeedModificatorOnEachRobound = 1.05f;         // Modification for each robound
    public float Speed;                                         // Speed of the ball
    #endregion

    #region Manipulators
    /// <summary>
    /// Starting the game here
    /// </summary>
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

        // Ball working
        rb.position = new Vector3(20.0f, 0, 0);                 
        rb.velocity = new Vector3(nextPosition, 0, 0) * StartingSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && endOfGame)
        {
            endOfGame = false;
            Reset();
        }
    }

    // After the game, press space to reset
    public void Reset()                                         
    {
        scoreC.Reset();
        Start();
    }

    private void OnCollisionEnter(Collision collision)
    {
        MapController mc = collision.gameObject.GetComponent<MapController>();

        // Doing point, is a goal of this game
        // And Adding point to score
        // With particular sound 
        if (collision.gameObject.name == "West")                                    
        {                  
            soundC.RunPointSound();                                                 
            endOfGame = scoreC.AddPoint(2);
            if (!endOfGame)
                ResetBall(2);
            else
                EndOfGame();  
        }
        // Same as before
        else if (collision.gameObject.name == "East")                               
        {
            soundC.RunPointSound();
            endOfGame = scoreC.AddPoint(1);
            if (!endOfGame)
                ResetBall(1);
            else
                EndOfGame();
        }
        // But, if we hit north or south wall, we need a different soud !
        else
            soundC.RunWallSound();

        // Paddle stuff
        if (collision.gameObject.name.StartsWith("Paddle"))                         
        {
            // We need a lot of objects
            PaddleController pc = collision.gameObject.GetComponent<PaddleController>();
            Transform cube = pc.transform.Find("Cube");
            Transform center = cube.Find("Center");
            Transform positif = cube.Find("Positif");
            Transform negatif = cube.Find("Negatif");

            // Natural and correct direction after rebound
            Vector3 contactPoint = collision.contacts[0].point;
            Transform maxRange = (Vector3.Dot(positif.position, contactPoint - center.position) > 0) ? positif : negatif;
            float MaxDist = Mathf.Abs(maxRange.position.z - center.position.z);
            float distBetweenCenterContact = Mathf.Abs(contactPoint.z - center.position.z);

            if (MaxDist != 0)
                rb.velocity = Vector3.Lerp(center.forward, maxRange.forward, distBetweenCenterContact / MaxDist).normalized * Speed;

            // Some sounds
            soundC.RunPaddleSound();

            // Decrease PaddleSpeed 
            pc.DecreesePaddleSpeed();
            // And increese BallSpeed \../
            IncreeseBallSpeed();                                                    
        }
        return;
    }

    /// <summary>
    /// Increese ballspeed here
    /// </summary>    
    private void IncreeseBallSpeed()                                                                               
    {
        Speed *= SpeedModificatorOnEachRobound;
    }

    /// <summary>
    /// Reset the ball's position after point
    /// </summary>
    /// <param name="winner"></param>
    public void ResetBall(int winner)                                               
    {
        if (winner == 1)
            nextPosition = -1;
        else
            nextPosition = 1;
        Speed = StartingSpeed;
        rb.position = new Vector3(20.0f, 0, 0);
        rb.velocity = new Vector3(nextPosition, 0, 0) * Speed;
    }

    /// <summary>
    /// But we need to finish this game 
    /// </summary>    
    public void EndOfGame()                                                         
    {
        // Then when the maximum of point is reach : end !
        rb.position = new Vector3(20.0f, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
        
    }
    #endregion
}