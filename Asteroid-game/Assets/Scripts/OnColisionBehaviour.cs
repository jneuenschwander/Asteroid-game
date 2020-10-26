using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColisionBehaviour : MonoBehaviour
{
    public GameObject[] subAsteroids;
    public int numberOfAsteroids;
    private void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag ("Bullet")) {
            Destroy (gameObject);
            Destroy (col.gameObject);
            for (var i = 0; i < numberOfAsteroids; i++) {
                Instantiate (
                    subAsteroids[Random.Range (0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                );
            }
        }
        if (col.CompareTag ("Player")) {
            var asteroids = FindObjectsOfType<AsteroidMovement>();
            for(var i = 0; i < asteroids.Length; i++) {
                Destroy(asteroids[i].gameObject);
            }
            col.GetComponent<ShipMovement>().OnLose();
        }
    }
}
