using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWRayCast : MonoBehaviour
{
    Rigidbody2D rigid;
    //Uncomment when U have animator already
    SpriteRenderer sprt;
    Animator anim;
    float horizontalValue;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    bool jumpActivated = false;

    [SerializeField] Transform pivotRay;
    [SerializeField] float thaRayLong;
    [SerializeField] LayerMask layersIdentifier;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //Uncomment when U have animator already
        anim = GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            jumpActivated = true;
        }
    }

    private void FixedUpdate()
    {
        //Uncomment when U have animator already
        anim.SetBool("InMovement", horizontalValue != 0 ? true : false);

        Flip();

        rigid.velocity = new Vector2(horizontalValue * speed, rigid.velocity.y);

        //Uncomment when U have animator already
        anim.SetFloat("YVelocity", rigid.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(pivotRay.position, Vector2.down, thaRayLong, layersIdentifier);
        
        //if (hit)
        //{
        //    isGrounded = true;
        //}
        //else
        //{
        //    isGrounded = false;

        //}

        // Forma coreana de hacerlo:

        isGrounded = hit.collider != null;

        //Se refiere a que isGrounded siempre sera verdadera en el caso de recibir algo, cuando deja de recibir algo (En este caso null) sera falsa


        //Uncomment when U have animator already
        anim.SetBool("IsGrounded", isGrounded);

        if (jumpActivated)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //Uncomment when U have animator already
            anim.SetTrigger("Jump");
            jumpActivated = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(pivotRay.position, Vector2.down * thaRayLong);
    }
    public void Flip()
    {
        //Uncomment when U have animator already
        if (horizontalValue > 0 && sprt.flipX == true || horizontalValue < 0 && sprt.flipX == false)
        {
            sprt.flipX = !sprt.flipX;
        }
    }
}
