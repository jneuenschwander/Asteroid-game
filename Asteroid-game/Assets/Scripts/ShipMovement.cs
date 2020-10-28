using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour, IGameLogic
{
    private Rigidbody2D rb;
    public float acceleration;
    public float maxSpeed;
    public float inertia;
    public float angularSpeed;
    private float vertical;
    private float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.drag = inertia; //coeficiencia de resistencia al movimiento
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = InputManager.Vertical; //funcion que habilita el movimiento vertical
        horizontal = InputManager.Horizontal; //Funcion que habilita el movimiento horizontal
        Rotate ();
    }
    private void Rotate () { // rotacion por velocidad angular
        if (horizontal == 0) {
            return;
        }
        transform.Rotate (0, 0, -angularSpeed * horizontal * Time.deltaTime); //rota segun la velocidad angular
    }
    private void FixedUpdate () {
        MovementController();
    }
    public void OnLose () {
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
    }

    void MovementController()
    {
        var forwardMotor = Mathf.Clamp (vertical, 0f, 1f); // clamp limita el movimiento en 
        rb.AddForce (transform.up * (acceleration * forwardMotor));
        if (rb.velocity.magnitude > maxSpeed) { //velocidad maxima de viaje
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
