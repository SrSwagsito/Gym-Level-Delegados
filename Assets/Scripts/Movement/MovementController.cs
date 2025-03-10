using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rigid;

    BaseState actualState; 

    public IdleState idle;
    public WalkState walk;
    public JumpState jump;
    public FallState fall;
    public DobleJumpState dobleJump;
    public WallJumpState wallJump;
    public HitState hit;
    public DeathState death;

    // Variables
    [SerializeField] public float jumpForce;
    [SerializeField] public float speed;
    [SerializeField] public bool isGrounded;
    [SerializeField] public float horizontal;
    [SerializeField] public KeyCode JumpButton;

    //Floor detection variables

    [SerializeField] Transform centerDetection;
    [SerializeField] LayerMask layerDetection;
    [SerializeField] float rayRange;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        idle = new IdleState(this);
        walk = new WalkState(this);
        jump = new JumpState(this);
        fall = new FallState(this);
        dobleJump = new DobleJumpState(this);
        wallJump = new WallJumpState(this);
        hit = new HitState(this);
        death = new DeathState(this);

        ChangeState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        actualState.UpdateState();
    }

    private void FixedUpdate()
    {
        actualState.FixedUpdateState();

        RaycastHit2D hit = Physics2D.Raycast(centerDetection.position, Vector2.down, rayRange, layerDetection);

        isGrounded = hit;

    }

    public void ChangeState(BaseState newState)
    {
        actualState = newState;
        actualState.StartState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(centerDetection.position, Vector2.down * rayRange);
    }
}
