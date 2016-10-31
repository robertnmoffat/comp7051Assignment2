using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {
    public GameObject player;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float rotSpeed = 90; // rotate speed in degrees/second

    public ControllerScript conScript;

    int targetx=1, targetz=1;
    float threshold = 0.25f;
    int currentMoveDir = 0;

    // Use this for initialization
    void Start () {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();

        print(Mathf.Abs(transform.position.z - targetz + 0.5f));

        if (Mathf.Abs(transform.position.x - targetx-0.5f) < threshold&&
            Mathf.Abs(transform.position.z - targetz - 0.5f) < threshold) getNextTargetSpace();


        if (controller.isGrounded)
        {
            //transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);
            //transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
            setDirection();
            //moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = new Vector3(0, 0, 0.08f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
    }

    //Set rotation to look in the direction the skeleton is going to move
    public void setDirection() {
        transform.LookAt(new Vector3(targetx + 0.5f, transform.position.y, targetz + 0.5f));
    }

    
    public void getNextTargetSpace() {
        int dir = currentMoveDir;
        int turnDir = Random.Range(0,1);
        //if (start == currentMoveDir) return;

        for (int i=0; i<4; i++) {
            switch (dir) {
                case 0:
                    if (conScript.isFloor(targetx, targetz+1)&&currentMoveDir!=1) {                        
                        targetz += 1;
                        currentMoveDir = dir;
                        dir = 5;
                        return;
                    }
                    break;
                case 1:
                    if (conScript.isFloor(targetx, targetz - 1) && currentMoveDir != 0)
                    {
                        targetz -= 1;
                        currentMoveDir = dir;
                        dir = 5;
                        return;
                    }
                    break;
                case 2:
                    if (conScript.isFloor(targetx+1, targetz) && currentMoveDir != 3)
                    {
                        targetx += 1;
                        currentMoveDir = dir;
                        dir = 5;
                        return;
                    }
                    break;
                case 3:
                    if (conScript.isFloor(targetx - 1, targetz) && currentMoveDir != 2)
                    {
                        targetx -= 1;
                        currentMoveDir = dir;
                        dir = 5;
                        return;
                    }
                    break;
            }

            if (turnDir == 0)
            {
                dir++;
                if (dir == 4) dir = 0;
            }
            else {
                dir--;
                if (dir == -1) dir = 3;
            }
        }

        switch (currentMoveDir) {
            case 0:
                currentMoveDir = 1;
                return;
            case 1:
                currentMoveDir = 0;
                return;
            case 2:
                currentMoveDir = 3;
                return;
            case 3:
                currentMoveDir = 2;
                return;
        }
    }

}
