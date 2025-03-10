using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animClassic;
    public Rigidbody2D rigidClassic;
    public SpriteRenderer sprt;
    public Collider2D obj;
    public Collider2D[] objs;

    float horizontalV;
    [SerializeField] public float myVelocity;
    public Transform center2See;
    public Vector2 visionSize;
    public LayerMask layers2See;

    float distance;
    [SerializeField] List<Damager> damagerList;
    // Start is called before the first frame update
    void Start()
    {
        animClassic = GetComponent<Animator>();
        rigidClassic = GetComponent<Rigidbody2D>();
        InvokeRepeating("EnemyDetection", 0, 0.3f);
    }
    private void FixedUpdate()
    {
        Flip();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(center2See.position, visionSize);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Flip()
    {
        //Uncomment when U have animator already
        if (horizontalV > 0 && sprt.flipX == true || horizontalV < 0 && sprt.flipX == false)
        {
            sprt.flipX = !sprt.flipX;
        }
    }
    public void DamagerActivation()
    {
        foreach (var item in damagerList)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void DamagerDeactivation()
    {
        foreach (var item in damagerList)
        {
            item.gameObject.SetActive(false);
        }

    }
    public void EnemyDetection()
    {

        objs = Physics2D.OverlapBoxAll(center2See.position, visionSize, 0, layers2See);
        animClassic.SetBool("PlayerDetected", obj);

        if (objs.Length > 0)
        {
            float distance = Mathf.Infinity;
            int ind = -1;
            for (int i = 0; i < objs.Length; i++)
            {
                if (Vector2.Distance(transform.position, objs[i].transform.position) < distance)
                {
                    distance = Vector2.Distance(transform.position, objs[i].transform.position);
                    ind = i;

                }
            }
            obj = objs[ind];

        }
        else
        {
            obj = null;
        }
        if (obj != null)
        {
            distance = Vector2.Distance(transform.position, obj.transform.position);
            animClassic.SetFloat("Distance", distance);
        }
    }
}