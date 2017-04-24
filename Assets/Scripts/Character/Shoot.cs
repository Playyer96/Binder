using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float force;

    [SerializeField]
    private ObjectPooler bulletPool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("disparo");
            Shoots();
        }
    }

    private void Shoots()
    {
        GameObject bullet = bulletPool.GetPooledObject();
        bullet.SetActive(true);
        bullet.transform.position = spawnPoint.position;
        bullet.GetComponent<Rigidbody>().velocity=new Vector3(0,0,force);
        Debug.Log(bullet.GetComponent<Rigidbody>().velocity);
    }
}
