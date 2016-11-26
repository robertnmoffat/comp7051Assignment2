using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
    float velx = -2, vely = 0;
    ScoreScript score;
    public bool playing = false;
    public Canvas gameOverCanvas;
    public Text messageText;


	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("ScoreText");
        score = (ScoreScript)go.GetComponent(typeof(ScoreScript));
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.forward * Time.deltaTime);
        if (playing) {
            transform.Translate(Vector3.left * Time.deltaTime * velx, Space.World);
            transform.Translate(Vector3.up * Time.deltaTime * vely, Space.World);
        }

		if (transform.position.x > 6 || transform.position.x < -6) {
            if (transform.position.x > 0)
                score.increaseLeft();
            else
                score.increaseRight();

			velx = -2; 
			vely = 0;

			transform.position = new Vector3 (0,0,5);

            switch (score.checkWinner()) {
                case 0:
                    break;
                case 1:
                    score.resetScores();                    
                    messageText.text = "Left Wins!";
                    playing = false;
                    gameOverCanvas.enabled = true;
                    
                    break;
                case 2:
                    score.resetScores();
                    playing = false;
                    messageText.text = "Right Wins!";
                    gameOverCanvas.enabled = true;
                    
                    break;
            }
		}
    }

    void OnTriggerEnter(Collider col)
    {
        print("Collision detected with trigger object " + col.name);

        if (col.name == "Left Paddle")
        {
            float deltaY = transform.position.y - col.transform.position.y;
            print(deltaY);
            velx = velx*-1.1f;
			vely = deltaY * 2;
        }
        if (col.name == "Right Paddle")
        {
            float deltaY = transform.position.y - col.transform.position.y;
            print(deltaY);
            velx = velx*-1.1f;
			vely = deltaY * 2;
        }
        if (col.name == "Top Wall"||col.name=="Bottom Wall")
        {
            vely = vely*-1;
        }
        //if (col.gameObject.name == "prop_powerCube")

    }

    public void startPlay() {
        playing = true;
    }

    public void stopPlay() {
        playing = false;
    }
}
