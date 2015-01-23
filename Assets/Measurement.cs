using UnityEngine;
using System.Collections;

public class Measurement : MonoBehaviour
{
    public GameObject end;
    public float distanceToEnd;
    public float maxDistance = 5;
    public float norm;
    public float floored;
    public float ceiled;
    public float neg;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        distanceToEnd = (transform.position - end.transform.position).sqrMagnitude;
        norm = distanceToEnd / maxDistance;
        neg = maxDistance / distanceToEnd;
        ceiled = Mathf.Ceil(norm);
        floored = Mathf.Floor(norm);

	}
}
