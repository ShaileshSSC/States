using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Transform objectT;
    private readonly string objectName = "Cube";
    private Vector3 distanceObject, triggerRadius;
    private readonly float movementSpeed = 3;
    void Start()
    {
        objectT = GameObject.Find(objectName).GetComponent<Transform>();
        triggerRadius = new Vector3(4, 4, 4);
    }

    void Update()
    {
        FaceTowardsAndWalkToObject();
    }

    Vector3 DistanceToObject()
    {
        Vector3 result = objectT.position - transform.position;
        return result;
    }

    private void FaceTowardsAndWalkToObject()
    {
        distanceObject = DistanceToObject();
        float pX = Mathf.Abs(DistanceToObject().x), pZ = Mathf.Abs(DistanceToObject().z);
        if (pX < triggerRadius.x && pX > objectT.localScale.x || pZ < triggerRadius.z && pZ > objectT.localScale.z)
        {
            transform.rotation =  Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, distanceObject, 1, 0.0f));
            transform.Translate(0, 0, movementSpeed * Time.deltaTime);
        }
        if (pX <= objectT.localScale.x && pZ <= objectT.localScale.z)
        {
            Attack();
        } 
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }

}
