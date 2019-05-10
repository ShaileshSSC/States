using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    private float timeToChangeDirection;

    private float change = 1.5f;

    [SerializeField]
    private new Rigidbody rigidbody;

    // Use this for initialization
    public void Start()
    {
        ChangeDirection();
    }

    // Update is called once per frame
    public void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0)
        {
            ChangeDirection();
        }

        rigidbody.velocity = transform.up * 2;
    }



    private void ChangeDirection()
    {
        float angle = Random.Range(180f, 0f);
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 newUp = quat * Vector3.up;
        newUp.y = 0;
        newUp.Normalize();
        transform.up = newUp;
        timeToChangeDirection = change;
    }
}
