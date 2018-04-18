using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;

    private float zOffset = -10f;
    private float yOffset = 5f;
    private float xOffset = 0f;
    private float maxXOffset = 2f;

    // Update is called once per frame
    void Update() {
        if (player != null) {
            updateXOffset();
            transform.position = new Vector3(player.transform.position.x + xOffset, Mathf.Clamp(player.transform.position.y, yOffset, Mathf.Infinity), zOffset);
        } else {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Checks direction of player movement, and changes xOffset accordingly. Returns updated value of xOffset
    void updateXOffset() {
        if (isMovingRight()) {
            xOffset += 0.05f;
        } else if (isMovingLeft()) {
            xOffset -= 0.05f;
        } else {
            if (System.Math.Abs(xOffset) < 0.1) {
                xOffset = 0f;
            } else {
                xOffset /= 1.2f;
            }
        }
        xOffset = Mathf.Clamp(xOffset, -maxXOffset, maxXOffset);
    }

    bool isMovingRight() {
        return ((Rigidbody2D)player.GetComponent(typeof(Rigidbody2D))).velocity.x > 0;
    }

    bool isMovingLeft() {
        return ((Rigidbody2D)player.GetComponent(typeof(Rigidbody2D))).velocity.x < 0;
    }
}