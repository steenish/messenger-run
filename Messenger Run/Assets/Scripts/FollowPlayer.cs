using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;

    private Vector3 zOffset = new Vector3(0, 0, 10);

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
        if (player != null) {
            transform.position = player.transform.position - zOffset;
        } else {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}
}
