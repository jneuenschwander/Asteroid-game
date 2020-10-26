using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawner;
    public float shootRate = 0.5f;
    private bool shooting; //boleano que indica si esta disparando la nave
    private bool canShoot = true; // boleano que indica si la nave puede disparar
    void Update(){
        shooting = InputManager.Fire;
        Shoot ();
    }
    
    

    private void Shoot () {
        if (shooting && canShoot) { // si esta disparando y puede disparar
            StartCoroutine (FireRate ()); // se llama a una corutina que se encargara de hacer un disparo
        }
    }




    private IEnumerator FireRate () {
        canShoot = false; //se inicializa en falso
        var bullet = Instantiate ( 
            bulletPrefab,
            bulletSpawner.position,// se instancian los objetos con la posicion y rotacion de la nave
            bulletSpawner.rotation // se rota segun la direccion de la nave
        );
        Destroy (bullet, 5); // cada 5 segundos se destruyen las balas
        yield return new WaitForSeconds (shootRate); // se indica que se pare la rutina medio segundo por disparo
        canShoot = true; //se modifica la condicion para disparar a verdadero
     }
}
