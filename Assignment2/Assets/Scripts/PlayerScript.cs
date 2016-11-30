using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    public Canvas touchUI;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public GameObject canvas;

    private Vector3 moveDirection = Vector3.zero;
    public float rotSpeed = 90; // rotate speed in degrees/second
    int collisions = 1;
    bool movingForward = false;

    // Use this for initialization
    void Start () {
        if (Application.platform == RuntimePlatform.Android)
        {
            touchUI.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android) {
            getTouchInput();
        }        

        if (Input.GetKeyDown("w")|| Input.GetKeyDown("joystick button 3")) {
            toggleCollisions();
        }

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown("joystick button 7"))
        {
            resetPosition();
        }

        if (Input.GetKey(KeyCode.PageUp)) {
            Camera.main.transform.Rotate(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            Camera.main.transform.Rotate(1, 0, 0);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            canvas.SetActive(false);
        }

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded||collisions==0)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            Camera.main.transform.Rotate(Input.GetAxis("ControllerRightStickVert"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            //if (Input.GetButton("Jump"))
               // moveDirection.y = jumpSpeed;

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
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(1.5f, 0.5f, -0.5f);
        
    }

    public void getTouchInput() {

        foreach (Touch touch in Input.touches)
        {
            if (touch.tapCount == 2) {
                resetPosition();
            }
        }

        if (Input.touchCount > 0 &&
       Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;


            Camera cam = GetComponent<Camera>();

            //cam.transform.rotate(touchDeltaPosition.y * speed / 2,0,0);
            Camera.main.transform.Rotate(-touchDeltaPosition.y * speed / 2,0,0);
            transform.Rotate(0, touchDeltaPosition.x * speed/2, 0);
            
        }

        if (movingForward) {
            CharacterController controller = GetComponent<CharacterController>();
            moveDirection = new Vector3(0, 0, 0.25f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    //Move player forward
    public void startMoveForward() {
        movingForward = true;        
    }

    public void endMoveForward() {
        movingForward = false;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "doorBlock")
            SceneManager.LoadScene("PongScene");

        //if(hit.gameObject.tag!="Untagged")
        //print(hit.gameObject.tag);
    }

    void OnCollisionEnter(Collision col)
    {
        print("Start Pong");
        if (col.gameObject.name == "player")
        {
            print("Start Pong");
        }
    }

}
