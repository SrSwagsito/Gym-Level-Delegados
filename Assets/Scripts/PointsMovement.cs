using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public List<GameObject> points = new List<GameObject>();
    int frstPosition = 0;

    void Start()
    {
        if (points.Count == 0)
        {
            transform.position = points[0].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[frstPosition].transform.position, speed * Time.deltaTime);

            if (transform.position == points[frstPosition].transform.position)
            {
                frstPosition = (frstPosition + 1) % points.Count;
            }
        }

    }
}