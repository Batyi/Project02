using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AICar_Script : MonoBehaviour {
    [SerializeField]
    public GameObject waypointContainer;
	private List<Transform> waypoints;
	private Rigidbody rigidBody;

    void  Start (){
		rigidBody = GetComponent<Rigidbody> ();
        rigidBody.centerOfMass = new Vector3 (GetComponent<Rigidbody>().centerOfMass.x, -1.5f, rigidBody.centerOfMass.z);
		GetWaypoints();
	}
    	
	void  FixedUpdate (){
	}
	
	void  GetWaypoints () {
		Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren< Transform >();
		waypoints = new List<Transform> ();
		foreach( Transform potentialWaypoint in potentialWaypoints ) {
			if ( potentialWaypoint != waypointContainer.transform ) {
				waypoints.Add (potentialWaypoint);		
			}
		}
	}
}