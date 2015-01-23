using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
	public GameObject BugHive;

    public float timeInterval = 5;
    
    float nextTime;
    private GameObject goalObject;
	// Use this for initialization
	void Start ()
    {
        this.BugHive = GameObject.Instantiate(BugHive) as GameObject;
        nextTime = Time.fixedTime + timeInterval;
        goalObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder) as GameObject;
        Vector3 startingPoint = new Vector3(5, 0, 3);
        goalObject.transform.position = startingPoint;
        BugBrain.bugList = new ArrayList();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Time.fixedTime > nextTime)
        {
            Debug.Log("bug");
            GameObject bug = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
            bug.AddComponent<Rigidbody>();
            nextTime = Time.fixedTime + timeInterval;
            BugBrain bb = bug.AddComponent<BugBrain>();
            bb.goalObject = this.goalObject;
            bb.controller = this;
            BugBrain.bugList.Add(bug);
        }
	}
}