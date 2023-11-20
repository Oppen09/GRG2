using UnityEngine;

/* �÷��̾��� ����, �ִϸ��̼�, �浹�� ���� ���� 
 �ۼ���: ������
 ���� �������� : 2023.11.20 */
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
        
        //����
        if (Input.GetButtonDown("Jump") && isGround) {
            rigidBody2D.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }
        isJumping = Input.GetButton("Jump");
    }

   
    void FixedUpdate() {
        //���� ���� ����
        if (isJumping && !isGround) {
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigidBody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

   
    void OnCollisionExit2D(Collision2D collision) {
        //����
        ChangeAnimation(State.Jump);
        soundManager.PlaySound(SoundManager.Sfx.Jump);
        isGround = false;

        //�������� �������� ����
        if (transform.position.y < -5)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }


    
    void OnCollisionStay2D(Collision2D collision) {
        //����
        if (!isGround) {
            ChangeAnimation(State.Run);
            soundManager.PlaySound(SoundManager.Sfx.Land);
            jumpPower = 1;
        }
        isGround = true;

        //�����̵�
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

    //��ֹ� �浹
    void OnTriggerEnter2D(Collider2D collision) {
        soundManager.PlaySound(SoundManager.Sfx.Hit);     
        ChangeAnimation(State.Hit); 
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }


    //player �ִϸ��̼� ����
    void ChangeAnimation(State state) {
        animator.SetInteger("State", (int)state);   
    }
    
}
