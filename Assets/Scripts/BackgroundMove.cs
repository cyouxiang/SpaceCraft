using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

    public float BackguoundMoveSpeed = 4f;//背景移動速度

	void Update () {
        this.transform.Translate(Vector3.down * BackguoundMoveSpeed * Time.deltaTime);//往下移動背景
        Vector3 position = this.transform.position;//獲取物體當前座標

        if (position.y <= -8.52) {
            this.transform.position = new Vector3(position.x, position.y + 8.52f * 2, position.z);
        }
	}
}
