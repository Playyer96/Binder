using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	private Vector3 dir;

    [SerializeField]
    private float speedMultiplier;
    [SerializeField]
    private float speedIncreaseMilestone;
	[SerializeField]
	private float speed;


	private float speedStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	private float speedIncreaseMilestoneStore;

	public GameManager theGameManager;

    void Start()
    {
		dir = Vector3.left;
		speedStore = speed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }
		
    void Update()
    {
        if (transform.position.z > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
            speed = speed * speedMultiplier;
        }
        if (Input.GetMouseButtonDown(0))
        {
			if (dir == Vector3.forward) {
				dir = Vector3.left;

			} else {
				dir = Vector3.forward;
			}
        }
        float autoMove = speed * Time.deltaTime;
        transform.Translate(dir * autoMove);
    }
	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Wall") {
			theGameManager.RestartGame();
			speed = speedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
		}
        if(other.gameObject.tag == "PowerUp")
        {
            GetComponent<Shoot>().enabled=true;
            other.gameObject.SetActive(false);
        }
	}
}
