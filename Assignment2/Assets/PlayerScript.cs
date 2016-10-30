using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float rotSpeed = 90; // rotate speed in degrees/second
    public Camera cam;
    int collisions = 1;

    // Use this for initialization
    void Start () {
        //Physics.IgnoreLayerCollision(0,0,true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w")) {
            toggleCollisions();
        }

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded||collisions==0)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime*collisions;
        controller.Move(moveDirection * Time.deltaTime);
    }

    //turns on and off collisions. also turns off gravity so that you dont fall through the floor
    public void toggleCollisions() {
        if (collisions == 1)
        {
            Physics.IgnoreLayerCollision(0, 0, true);
            collisions = 0;
        }
        else
        {
            Physics.IgnoreLayerCollision(0, 0, false);
            collisions = 1;
        }
    }

    public void resetPosition() {
        transform.Translate(new Vector3(1,1,1));
    }
}
