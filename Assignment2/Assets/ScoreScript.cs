using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public Text scoreText;
    int leftScore = 0, rightScore = 0;

	// Use this for initialization
	void Start () {
        //scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = leftScore+" | "+rightScore;
	}

    public void increaseLeft() {
        leftScore++;
    }

    public void increaseRight() {
        rightScore++;
    }

    public void resetScores() {
        leftScore = 0;
        rightScore = 0;
    }

    public int checkWinner() {
        if (leftScore == 5) return 1;
        if (rightScore == 5) return 2;
        return 0;
    }
}
