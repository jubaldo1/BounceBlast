using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public PlayerController playerstuff;

    // Text for GameWin/Lose
    public Text GameWin;
    public Text GameOver;

    // Time
    public Text time;
    public float floatTime;
    public int intTime;
    public int startTime;
    public int numOfBalls;

    // Collectables
    public GameObject ballPrefab;
    public Collider[] allBalls;
    public int ballsCollected;

    private void Awake()
    {
        ballsCollected = 0;
        numOfBalls = 5;
        allBalls = new Collider[numOfBalls];

        for (int i = 0; i < numOfBalls; i++)
        {
            GameObject ball;
            ball = Instantiate(ballPrefab, new Vector3(Random.Range(-25f, 25f), 15f,Random.Range(-25f, 25f)), new Quaternion(0, 0, 0, 0));
            allBalls[i] = ball.GetComponent<Collider>();
        }
    }

    // Use this for initialization
    void Start () {
        playerstuff = GetComponent<PlayerController>();

        floatTime = 0.0f;
        startTime = 60;
        GameWin.text = "";
        GameOver.text = "";
	}
	
    void Update()
    {
        Debug.Log("Key pressed: " + Input.inputString);
    }

	// Update is called once per frame
	void FixedUpdate () {
        floatTime += Time.deltaTime;
        intTime = (int)floatTime;

        if ((startTime - intTime) <= 0)
        {
            time.text = "Time: " + 0;
            time.enabled = false;
            ballsCollected = 0;
            GameOver.text = "Game Over!";

            if (Input.GetKey(KeyCode.Space))
            {
                RestartLevel();
            }
        }
        else if (ballsCollected == allBalls.Length)
        {
            GameWin.text = "Congratulations!\n You Win!";
            floatTime = 5;
            time.enabled = false;

            if (Input.GetKey(KeyCode.Space))
            {
                RestartLevel();
            }
        }
        else
        {
            time.text = "Time: " + (startTime - intTime);
        }
	}

    public Collider[] GetAllBalls()
    {
        return allBalls;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
