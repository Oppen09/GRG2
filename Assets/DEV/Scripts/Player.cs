using UnityEngine;

/* 플레이어의 동작, 애니메이션, 충돌시 동작 제어 
 작성자: 이정훈
 최종 수정일자 : 2023.11.20 */
public class Player : MonoBehaviour
{
    enum State { Stand, Run, Jump, Slide, Hit}
    public float startJumpPower;
    public float jumpPower;
    bool isGround;
    bool isJumping;
 
    Rigidbody2D rigidBody2D;
    Animator animator;
    SoundManager soundManager;
    CapsuleCollider2D capsuleCollider2D;

    void Awake() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        soundManager = GetComponent<SoundManager>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();  
    }

    void Start() {
        soundManager.PlaySound(SoundManager.Sfx.start);
    }

    void Update() {
        
        //점프
        if (Input.GetButtonDown("Jump") && isGround) {
            rigidBody2D.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }
        isJumping = Input.GetButton("Jump");
    }

   
    void FixedUpdate() {
        //점프 높이 조절
        if (isJumping && !isGround) {
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigidBody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

   
    void OnCollisionExit2D(Collision2D collision) {
        //점프
        ChangeAnimation(State.Jump);
        soundManager.PlaySound(SoundManager.Sfx.Jump);
        isGround = false;

        //구멍으로 떨어질시 동작
        if (transform.position.y < -5)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }


    
    void OnCollisionStay2D(Collision2D collision) {
        //착지
        if (!isGround) {
            ChangeAnimation(State.Run);
            soundManager.PlaySound(SoundManager.Sfx.Land);
            jumpPower = 1;
        }
        isGround = true;

        //슬라이딩
        if (Input.GetButton("Down"))
        {
            ChangeAnimation(State.Slide);
            capsuleCollider2D.offset = new Vector2(0, 0.22F);
            capsuleCollider2D.size = new Vector2(1, 0.45F);
        }
        else
        {
            capsuleCollider2D.offset = new Vector2(0, 0.45F);
            capsuleCollider2D.size = new Vector2(1, 0.9F);
        }
    }

    //장애물 충돌
    void OnTriggerEnter2D(Collider2D collision) {
        soundManager.PlaySound(SoundManager.Sfx.Hit);     
        ChangeAnimation(State.Hit); 
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }


    //player 애니메이션 변경
    void ChangeAnimation(State state) {
        animator.SetInteger("State", (int)state);   
    }
    
}
