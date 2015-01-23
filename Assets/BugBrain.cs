using UnityEngine;
using System.Collections;

public class BugBrain : MonoBehaviour
{
    public WorldController controller;
    public static ArrayList bugList;
    float randomSelectionTime;
    public GameObject goalObject
    {
        get;
        set;
    }

    public float directionPower = 8;
    public bool isSwarming;
	// Use this for initialization
	void Start ()
    {
        randomSelectionTime = newRandomTime();
    }

    float newRandomTime()
    {
        return Time.fixedTime + Random.Range(5, 10);
    }
	// Update is called once per frame
	void Update ()
    {
        Vector3 directionToGoal = (goalObject.transform.position - transform.position).normalized;
        Debug.DrawLine(this.transform.position, goalObject.transform.position, Color.red);
        this.rigidbody.AddForce(directionToGoal * directionPower * 2);
        foreach(GameObject go in bugList)
        {
            Vector3 otherPosition = go.transform.position;
            Vector3 directionToOther = (transform.position - otherPosition).normalized;
            float distanceToOther = (transform.position - otherPosition).sqrMagnitude;
            if(distanceToOther == 0)
                continue;
            float fallOff = directionPower / distanceToOther;

            Vector3 vector = directionToOther * fallOff;
            gameObject.rigidbody.AddForce(vector);
            Debug.DrawRay(this.transform.position, vector);
        }

        if (Time.fixedTime > randomSelectionTime)
        {
            int randomeSelection = Random.Range(0, BugBrain.bugList.Count);
            goalObject = BugBrain.bugList[randomeSelection] as GameObject;
            randomSelectionTime = newRandomTime();
        }
	}
}
