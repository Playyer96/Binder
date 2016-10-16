using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

	[SerializeField]
	private ObjectPooler coinPool;
	[SerializeField]
	private float distanceBetweenCoins;

	public void SpawnCoins(Vector3 startPosition){
		GameObject coin1 = coinPool.GetPooledObject ();
		coin1.transform.position = startPosition;
		coin1.SetActive (true);

		GameObject coin2 = coinPool.GetPooledObject ();
		coin2.transform.position = new Vector3 (startPosition.x- distanceBetweenCoins, startPosition.y, startPosition.z-Random.Range(0,20));
		coin2.SetActive (true);

		GameObject coin3 = coinPool.GetPooledObject ();
		coin3.transform.position = new Vector3 (startPosition.x + distanceBetweenCoins , startPosition.y, startPosition.z +Random.Range(0,10));
		coin3.SetActive (true);
	}
}
