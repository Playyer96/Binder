using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour {

	[SerializeField]
	private float wallWidth;
    [SerializeField]
	private Transform genetationPoint;
    [SerializeField]
    private ObjectPooler wallPooled;
	[SerializeField]
	private float randomCoinThreshold;

	private CoinGenerator theCoinGenerator;
    private ObstacleGenerator theObstacleGenerator;
    private PowerUpGenerator thePowerUpGenerator;

	void Start () {
		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
        theObstacleGenerator = FindObjectOfType<ObstacleGenerator>();
        thePowerUpGenerator = FindObjectOfType<PowerUpGenerator>();
	}
	void Update () {
        if (transform.position.z < genetationPoint.position.z)
        {
            GameObject newWall = wallPooled.GetPooledObject();

            newWall.transform.position = transform.position;
            newWall.transform.rotation = transform.rotation;
            newWall.SetActive(true);
            
            CoinGenerator();
            ObstaclesGenerator();
            PowerUpGenerator();

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + wallWidth);
        }
	}

    private void CoinGenerator()
    {
        if (Random.Range(0f, 100f) < randomCoinThreshold)
        {
            theCoinGenerator.SpawnCoins(new Vector3(Random.Range(-15, -3), transform.position.y, transform.position.z));
        }
    }

    private void ObstaclesGenerator()
    {
        if (Random.Range(0f, 100f) < randomCoinThreshold)
        {
            theObstacleGenerator.SpawnObstacles(new Vector3(Random.Range(-15, -3), transform.position.y, transform.position.z));
        }
    }

    private void PowerUpGenerator()
    {
        if (Random.Range(0f, 100f) < randomCoinThreshold / 2)
        {
            thePowerUpGenerator.SpawnPowerUp(new Vector3(Random.Range(-15, -3), transform.position.y, transform.position.z));
        }
    }
}
