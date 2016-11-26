using UnityEngine;
using System.Collections;

public class ShootBallScript : MonoBehaviour {
    public AudioSource BounceSound;
    public ControllerScript controllerScript;

    int lifeTime = 300;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        addForce(transform.forward);
    }
	
	// Update is called once per frame
	void Update () {
        lifeTime--;

        if (lifeTime == 0)
        {
            print("DEAD");
            Destroy(this.gameObject);
        }
	}

    public void addForce(Vector3 force) {
        rb.AddForce(force * 500);
    }

    void OnCollisionEnter(Collision col)
    {
        //print("COLLISION");
        if (col.gameObject.name != "player")
        {
            BounceSound.Play();
        }        
        if (col.gameObject.name == "skeleton_animated")
        {
            SkeletonScript skelScript = col.gameObject.GetComponent<SkeletonScript>();
            skelScript.addScore(10);
            Destroy(this.gameObject);
        }
    }
}
