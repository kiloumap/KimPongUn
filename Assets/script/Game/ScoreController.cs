using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Score controller
/// </summary>
public class ScoreController : MonoBehaviour {
    // Some controller needed
    BallController bc;                              
    SoundController soundC;

    [SerializeField]
    private Text score1, score2, Win, ReplayText;                    // Texte to display on screen

    private Transform Player1, Player2;                             // Players
    public int idScore = 0;                                         // Id to separate score for players 
    public int playerScore = 0;                                     // Players scores
    public int maxPoint = 1;                                        // Score to reach

    /// <summary>
    /// Starting in resetant text values;
    /// </summary>
    void Start () {
        score1.text = "0";
        score2.text = "0";
        Win.text = "";
        ReplayText.text = "";
    }   

    /// <summary>
    /// Adding points
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool AddPoint(int id)
    {
        if(id == 1)
        {
            int scr = int.Parse(score1.text) + 1;
            score1.text = scr.ToString();
            if(scr == maxPoint)
                return Victory(1);
        }
        else if(id == 2)
        {
            int scr = int.Parse(score2.text) + 1;
            score2.text = scr.ToString();
            if (scr == maxPoint)
                return Victory(2);
        }
        return false;
    }

    /// <summary>
    /// Victoryyyyyy
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private bool Victory(int id)
    {
        soundC = GameObject.FindObjectOfType<SoundController>();
        bc = GameObject.FindObjectOfType<BallController>();
        bc.EndOfGame();
        Win.text += "Victory for the Player " + id;
        ReplayText.text += "Press Space for replay";
        soundC.RunVictorySound();
        return true;
    }

    /// <summary>
    /// Reset game
    /// </summary>
    public void Reset()
    {
        score1.text = "0";
        score2.text = "0";
        Win.text = "";
        ReplayText.text = "";
    }
}
