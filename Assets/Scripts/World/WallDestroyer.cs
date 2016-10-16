using UnityEngine;
using System.Collections;

public class WallDestroyer : MonoBehaviour {

	[SerializeField]
	private GameObject wallDestructionPoint;

	void Start () {
	wallDestructionPoint=GameObject.Find("WallDestructionPoint");
	}
	void Update () {
	if(transform.position.z<wallDestructionPoint.transform.position.z){
            //Destroy(gameObject);
            gameObject.SetActive(false);
		}
	}
}
