using UnityEngine;
using System.Collections;

public class ShootPool : MonoBehaviour
{
    public delegate void FireAction();
	public event FireAction OnFire;
	
	protected void Update()
	{

		// crear un proyectil?
		if(Input.GetKeyDown(KeyCode.Space) == true)
		{
			// we just request an agent whether one is available or not
			PooledProjectile.Spawn(transform.position, transform.rotation);
			
			// Invocar el evento solo si alguien esta suscrito a el
			if(OnFire != null)
				OnFire();
		}
	}
}
