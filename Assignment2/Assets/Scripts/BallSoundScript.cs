using UnityEngine;
using System.Collections;

public class BallSoundScript : MonoBehaviour {
    public AudioSource BounceSound;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //rb = GetComponent<Rigidbody>();
    }

    public void addForce(Vector3 force)
    {
        rb.AddForce(force * 150);
    }

    void OnCollisionEnter(Collision col)
    {
        //print("COLLISION");
        BounceSound.Play();
        if (col.gameObject.name == "prop_powerCube")
        {
            Destroy(col.gameObject);
        }
    }
}
