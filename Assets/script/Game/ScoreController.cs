using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public int idScore = 0;
    public int playerScore = 0;
    private Transform Player1, Player2;
    BallController bc;
    SoundController soundC;

    [SerializeField]
    public Text score1, score2, Win, ReplayText;
    public int maxPoint = 10;

    // Use this for initialization
    void Start () {
        score1.text = "0";
        score2.text = "0";
        Win.text = "";
        ReplayText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool AddPoint(int id)
    {
        if(id == 1)
        {
            int scr = int.Parse(score1.text) + 1;
            score1.text = scr.ToString();
            if(scr == maxPoint)
            {
                return Victory(1);
            }
        }
        else if(id == 2)
        {
            int scr = int.Parse(score2.text) + 1;
            score2.text = scr.ToString();
            if (scr == maxPoint)
            {
                return Victory(2);
            }
        }
        return false;
    }

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

    public void Reset()
    {
        score1.text = "0";
        score2.text = "0";
        Win.text = "";
        ReplayText.text = "";
    }
}
