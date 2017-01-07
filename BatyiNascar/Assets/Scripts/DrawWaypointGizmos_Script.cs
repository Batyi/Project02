using UnityEngine;
using System.Collections;

public class DrawWaypointGizmos_Script : MonoBehaviour {
	void  OnDrawGizmos (){
		Transform[] waypoints = gameObject.GetComponentsInChildren< Transform >();
		foreach(Transform waypoint in waypoints) {
			Gizmos.DrawSphere( waypoint.position, 1.0f );
		}
	}
}