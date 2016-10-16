﻿using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {

	[SerializeField]
	private GameObject theWall;
	[SerializeField]
	private Transform genetationPoint;
	[SerializeField]
	private float distanceBetween;

	private float wallWidth;

    [SerializeField]
    private ObjectPooler wallPooled;
	[SerializeField]
	private float randomCoinThreshold;
	public CoinGenerator theCoinGenerator;


	void Start () {
		wallWidth = theWall.GetComponent<BoxCollider> ().size.y;
		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
	}
	void Update () {
	if(transform.position.z<genetationPoint.position.z){
           GameObject newWall= wallPooled.GetPooledObject();

            newWall.transform.position = transform.position;
            newWall.transform.rotation = transform.rotation;
            newWall.SetActive(true);
			if (Random.Range (0f, 100f) < randomCoinThreshold) {
				theCoinGenerator.SpawnCoins (new Vector3 (transform.position.x +10f, transform.position.y, transform.position.z));
			}
			transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z+wallWidth+distanceBetween);
		}
	}
}