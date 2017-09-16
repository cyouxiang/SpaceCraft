using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject Enemy0Prefab;
    public float Enemy0Rate = 0.5f;

    public GameObject Enemy1Prefab;
    public float Enemy1Rate = 0.5f;

    public GameObject Enemy2Prefab;
    public float Enemy2Rate = 0.5f;

    public GameObject Award0Prefab;
    public float Award0Rate = 0.5f;

    public GameObject Award1Prefab;
    public float Award1Rate = 0.5f;

    void Start () {
        InvokeRepeating("CreateEnemy0", 1, Enemy0Rate);
        InvokeRepeating("CreateEnemy1", 5, Enemy1Rate);
        InvokeRepeating("CreateEnemy2", 10, Enemy2Rate);

        InvokeRepeating("CreateAward0", 5, Award0Rate);
        InvokeRepeating("CreateAward1", 10, Award1Rate);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void CreateEnemy0 () {
        float x = Random.Range(-2.0f, 2f);
        GameObject.Instantiate(Enemy0Prefab,new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateEnemy1 () {
        float x = Random.Range(-1.9f, 1.9f);
        GameObject.Instantiate(Enemy1Prefab,new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateEnemy2 () {
        float x = Random.Range(-1.35f, 1.35f);
        GameObject.Instantiate(Enemy2Prefab,new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateAward0 () {
        float x = Random.Range(-2.1f, 2.1f);
        GameObject.Instantiate(Award0Prefab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateAward1 () {
        float x = Random.Range(-2.1f, 2.1f);
        GameObject.Instantiate(Award1Prefab, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
}
