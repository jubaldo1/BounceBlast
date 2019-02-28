using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(player.transform.position);
    }

}
