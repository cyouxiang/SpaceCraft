using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float rate = 0.2f;
    public GameObject bullet;

	//void Start () {
    //    OpenFire ();
	//}
	
	public void Fire () {
        GameObject.Instantiate (bullet, transform.position, Quaternion.identity);
    }

    public void OpenFire () {
        InvokeRepeating ("Fire", 0.5f, rate);
    }

    public void StopFire () {
        CancelInvoke ("Fire");
    }
}
