using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool isAnimation = true;
    public int frameCountPerSeconds = 10;
    public float timer = 0f;//預設計時器為0
    public Sprite[] sprites;//建立圖片陣列
    private SpriteRenderer spriteRenderer;

    private bool isMouseDown = false;
    private Vector3 lastMousePosition = Vector3.zero;
    private Transform myPlayer;

    public float specialGunTime = 15f;
    private float restSpecialGun;
    private int gunCount = 1;
    public Gun gunTop;
    public Gun gunLeft;
    public Gun gunRight;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        myPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        restSpecialGun = specialGunTime;
        specialGunTime = 0f;
        gunTop.OpenFire();
    }

	void Update () {
	    if (isAnimation) {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1f / frameCountPerSeconds));
            int frame = frameIndex % 2;
            spriteRenderer.sprite = sprites[frame];

            if (specialGunTime > 0) {
                if (gunCount == 1) {
                    TransformToSpecialGun();
                }

                specialGunTime -= Time.deltaTime;
            } else {
                if (gunCount == 2) {
                    TransformToNormalGun();
                }
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
            lastMousePosition = Vector3.zero;
        }

        if (isMouseDown && GameManager._instance.gameState == GameState.Running) {
            if (lastMousePosition != Vector3.zero) {
                Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;
                transform.position = transform.position + offset;
                CheckPlayerPosition();
            }
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
	}

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Award") {
            GetComponent<AudioSource>().Play();
            if (other.GetComponent<Award>().type == 0) {
                specialGunTime = restSpecialGun;
                Destroy(other.gameObject);
            } else if (other.GetComponent<Award>().type == 1) {
                BombManage._instance.AddBomb();
                Destroy(other.gameObject);
            }
        } else if (other.tag == "Enemy") {
            Application.LoadLevel("SpaceCraft");
            print("Reload");
        }
    }

    private void CheckPlayerPosition () {
        Vector3 pos = transform.position;
        float x = pos.x;
        float y = pos.y;

        if (x < -2.3f)
            x = -2.3f;

        if (x > 2.3f)
            x = 2.3f;

        if (y < -3.9f)
            y = -3.9f;

        if (y > 3.5f)
            y = 3.5f;

        transform.position = new Vector3(x, y, 0);
    }

    private void TransformToSpecialGun () {
        gunCount = 2;
        gunTop.StopFire();
        gunLeft.OpenFire();
        gunRight.OpenFire();
    }

    private void TransformToNormalGun () {
        gunCount = 1;
        gunTop.OpenFire();
        gunLeft.StopFire();
        gunRight.StopFire();
    }
}
