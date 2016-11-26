using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("Controller hit");
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
