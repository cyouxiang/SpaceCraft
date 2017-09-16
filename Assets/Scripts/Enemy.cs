using UnityEngine;
using System.Collections;

public enum EnemyType {
    SmallEnemy,
    MiddleEnemy,
    BigEnemy
}

public class Enemy : MonoBehaviour {

    public int hp = 1;
    public float speed = 2;
    public int score = 0;
    public EnemyType type = EnemyType.SmallEnemy;

    public bool isDeath = false;
    public Sprite[] explosionSprites;
    private float timer = 0f;
    public int explosionAnimationFrame = 10;
    private SpriteRenderer spriteRenderer;

    public float HitTimer = 0.2f;
    private float ResetHitTimer;
    public Sprite[] HitSprites;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ResetHitTimer = HitTimer;
        HitTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate (Vector3.down * speed * Time.deltaTime);
        if (this.transform.position.y <= -6f) {
            Destroy(this.gameObject);
        }

        if (isDeath) {
            timer += Time.deltaTime;
            int frameIndex = (int)(timer / (1f / explosionAnimationFrame));
            if (frameIndex >= explosionSprites.Length) {
                Destroy(this.gameObject);
            } else {
                spriteRenderer.sprite = explosionSprites[frameIndex];
            }
        } else {
            if (type == EnemyType.MiddleEnemy || type == EnemyType.BigEnemy) {
                if (HitTimer >= 0) {
                    HitTimer -= Time.deltaTime;
                    int frameIndex = (int)((ResetHitTimer - HitTimer) / (1f / explosionAnimationFrame));
                    frameIndex %= 2;
                    spriteRenderer.sprite = HitSprites[frameIndex];
                }
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space) && BombManage._instance.bombCount > 0) || (Input.touchCount >= 2 && BombManage._instance.bombCount > 0)) {
            isDeath = true;
            GameManager._instance.playerScore += score;
        }
	}

    public void BeHit () {
        hp -= 1;
        if (hp <= 0) {
            isDeath = true;
            GameManager._instance.playerScore += score;
        } else {
            HitTimer = ResetHitTimer;
        }
    }

    //public void BeforeDie () {
    //    GameManager._instance.playerScore += score;
    //}
}
