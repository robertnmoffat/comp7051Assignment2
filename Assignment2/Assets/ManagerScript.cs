using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour {
    public BallScript ballScript;
    public Canvas menuCanvas;
    public Canvas gameOverCanvas;
    public Canvas consoleCanvas;
    public Dropdown leftDrop, rightDrop;
    public LeftPaddleScript leftPaddleScript;
    public RightPaddle rightPaddleScript;
    public InputField inputText;

    public bool usingConsole = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        handleTouch();

        if (Input.GetKey("c")&&!usingConsole)
        {
            usingConsole = true;
            consoleCanvas.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Return)&&usingConsole) {
            inputText.text = "";
        }
	if (Input.GetKeyDown(KeyCode.Escape)&&usingConsole) {
            usingConsole = false;
		consoleCanvas.enabled = false;
        }

    }

    public void playButtonFunction() {
        leftPaddleScript.setControl(leftDrop.value);
        rightPaddleScript.setControl(rightDrop.value);
        ballScript.startPlay();
        menuCanvas.enabled = false;
    }

    public void goBackToMaze() {
        SceneManager.LoadScene("MainScene");
    }

    public void startNewGame() {
        leftPaddleScript.resetPaddle();
        rightPaddleScript.resetPaddle();
        gameOverCanvas.enabled = false;
        menuCanvas.enabled = true;
    }

    public void handleTouch() {
        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            print(nbTouches + " touch(es) detected");

            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);

                print("Touch index " + touch.fingerId + " detected at position " + touch.position);
            }

            leftPaddleScript.movePaddleTo(new Vector3(-4,Input.GetTouch(nbTouches).position.y,5));
        }
    }
}
