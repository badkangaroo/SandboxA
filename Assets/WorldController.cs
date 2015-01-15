using UnityEngine;
using System.Collections;

public class WorldController : MonoBehaviour
{
	public GameObject BugHive;
    public float timeInterval = 5;
    float nextTime;
	// Use this for initialization
	void Start ()
    {
        GameObject go = GameObject.Instantiate(BugHive) as GameObject;
        nextTime = Time.fixedTime + timeInterval;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Time.fixedTime > nextTime)
        {
            Debug.Log("bug");
            GameObject bug = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
            bug.AddComponent<Rigidbody>();
            Vector3 randomDirection = new Vector3(Random.Range(-1,1),0,Random.Range(-1,1));
            bug.rigidbody.AddForce(randomDirection);
            nextTime = Time.fixedTime + timeInterval;
        }
	}
}