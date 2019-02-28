using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public Collider playCol;
    public Collider[] allBalls;

    // why does this work?????
    public GameObject GM;
    public GameManager GMScript;
    
    // Use this for initialization
    void Start () {
        // give the game script the GameManager object's Game Manager script
        GMScript = GM.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        playCol = GetComponent<Collider>();

        allBalls = new Collider[GMScript.GetAllBalls().Length];
        allBalls = GMScript.GetAllBalls();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddForce(transform.right * h * speed, ForceMode.Force);
        rb.AddForce(transform.forward * v * speed, ForceMode.Force);

        for(int i = 0; i < allBalls.Length; i++)
        {
            Debug.Log("Entered allBalls loop");
            if (allBalls[i] != null)
            {    
                Physics.IgnoreCollision(playCol, allBalls[i]);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            GMScript.ballsCollected++;
            other.gameObject.SetActive(false);
        }
    }
}
