﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 4.5f;

	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > 4.3f) {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Enemy") {
            if (!other.GetComponent<Enemy>().isDeath) {
                other.gameObject.SendMessage("BeHit");
                Destroy(this.gameObject);
            }
        }
    }
}
