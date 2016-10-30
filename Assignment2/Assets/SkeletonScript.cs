using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {
    public GameObject player;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float rotSpeed = 90; // rotate speed in degrees/second

    

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        CharacterController controller = GetComponent<CharacterController>();

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

    public void setDirection() {
        //Quaternion rotation = Quaternion.LookRotation
        //  (player.transform.position - transform.position, transform.TransformDirection(Vector3.left));
        //transform.rotation = new Quaternion(rotation.z,0, rotation.w, 0);
        //transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        transform.LookAt(new Vector3(1, transform.position.y, 2));
    }
    

}
