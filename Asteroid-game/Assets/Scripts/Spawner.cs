using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float timeToSpawn; //tiempo para que vuelvan a aparecer
    public GameObject[] prefabs;// asteroide que aparece primero
    public Transform[] spawners; //objetos que poseen posicion mas no son prefabs

    IEnumerator Start () {
        while (true) {
            Instantiate (
                prefabs[Random.Range (0, prefabs.Length)], // error 
                spawners[Random.Range (0, spawners.Length)].position,// error
                
                Quaternion.identity
            );

            yield return new WaitForSeconds (timeToSpawn); //tiempo que espera
        }
    }

}