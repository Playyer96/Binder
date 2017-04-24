using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour {

    [SerializeField]
    private ObjectPooler powerUpPool;
    [SerializeField]
    private float distanceBetweenPowerUps;

    public void SpawnPowerUp(Vector3 startPosition)
    {
        GameObject coin1 = powerUpPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

        GameObject coin2 = powerUpPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPosition.x - distanceBetweenPowerUps, startPosition.y, startPosition.z - Random.Range(0, 20));
        coin2.SetActive(true);

        GameObject coin3 = powerUpPool.GetPooledObject();
        coin3.transform.position = new Vector3(startPosition.x + distanceBetweenPowerUps, startPosition.y, startPosition.z + Random.Range(0, 10));
        coin3.SetActive(true);
    }
}
