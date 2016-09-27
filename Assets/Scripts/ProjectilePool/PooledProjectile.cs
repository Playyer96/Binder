using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PooledProjectile : MonoBehaviour
{
	static private List<PooledProjectile> pooledProjectiles;

	static public PooledProjectile Spawn(Vector3 position, Quaternion rotation ){

		foreach( PooledProjectile pooledProjectile in pooledProjectiles ){

			if( pooledProjectile.gameObject.activeInHierarchy == false ){

				pooledProjectile.transform.position = position;
				pooledProjectile.transform.rotation = rotation;
				
				pooledProjectile.gameObject.SetActive(true);
				
				return pooledProjectile;
			}
		}

		return null;
	}

	protected void Start()
	{
		gameObject.SetActive(false);
	}
	
	protected void OnEnable(){
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		GetComponent<Rigidbody>().AddForce(transform.right * 25, ForceMode.Impulse);
	}

    protected void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

	protected void Awake()
	{
		if( pooledProjectiles == null ){
			pooledProjectiles = new List<PooledProjectile>();
		}
		pooledProjectiles.Add(this);
	}
	
	protected void OnDestroy()
	{
		pooledProjectiles.Remove(this);
		if(pooledProjectiles.Count == 0){
			pooledProjectiles = null;
		}
	}
}
