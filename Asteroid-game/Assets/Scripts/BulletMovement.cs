using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;

    void Update () {
        ConstantMovement();
    }

    void ConstantMovement()
    {
        transform.position += transform.up * (speed * Time.deltaTime);
    }
}
