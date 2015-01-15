using UnityEngine;
using System.Collections;

public class BugBrain : MonoBehaviour
{
    public GameObject goalObject
    {
        get;
        set;
    }

    public float directionPower = 8;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 directionToGoal = goalObject.transform.position - transform.position;
        Vector3 directionNormalized = directionToGoal.normalized;
        this.rigidbody.AddForce(directionNormalized * directionPower);
	}
}
