using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
        rb.drag = 0;
        rb.angularDrag = 0;

        rb.velocity = new Vector3 (
            Random.Range (-1f, 1f),
            Random.Range (-1f, 1f),
            Random.Range (-1f, 1f)
        ).normalized * speed;

        rb.angularVelocity = Random.Range (-50f, 50f);
    }

}
