using UnityEngine;
using System.Collections;

public class RightPaddle : MonoBehaviour {
	float deltay;
    bool controller = false;
    bool ai = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!controller&&!ai)
        {
            if (Input.GetKey("joystick button 5"))
            {
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("up"))
            {
                transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(Vector3.up * Time.deltaTime * -1, Space.World);
            }
        }
        else {
            Vector3 inputDirection = Vector3.zero;
            inputDirection.y = Input.GetAxis("LeftJoystickVertical") * -2;
            transform.Translate(Vector3.up * inputDirection.y * Time.deltaTime, Space.World);
        }
        if (ai)
        {
            updateDeltay();
            transform.Translate(Vector3.up * Time.deltaTime * deltay, Space.World);
        }
	}

	void updateDeltay(){
		var ball = GameObject.Find ("Ball");
		deltay = ball.transform.position.y-transform.position.y;
		print (deltay);
	}

    public void setControl(int input)
    {
        switch (input)
        {
            case 0:
                ai = true;
                break;
            case 1:
                controller = false;
                break;
            case 2:
                controller = true;
                break;
        }
    }

    public void resetPaddle()
    {
        transform.position = new Vector3(4, 0, 5);
    }
}
