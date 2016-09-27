using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	private Vector3 dir;

	[SerializeField]
	private float speed;
	[SerializeField]
	private GameObject textStart;
	[SerializeField]
	private GameObject textControls;


	public MonoBehaviour shootLeft;
	public MonoBehaviour shootRight;

    // Use this for initialization
    void Start()
    {
        dir = Vector3.zero;
        shootLeft.enabled = false;
        shootRight.enabled = false;
		textStart.SetActive (true);
		textControls.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
                shootLeft.enabled = true;
                shootRight.enabled = false;
				textStart.SetActive (false);
				textControls.SetActive (true);
            }
            else
            {
                dir = Vector3.forward;
                shootRight.enabled = true;
                shootLeft.enabled = false;
				textStart.SetActive (false);
				textControls.SetActive (true);
            }
        }
        float autoMove = speed * Time.deltaTime;
        transform.Translate(dir * autoMove);
    }
}
