using UnityEngine;
using System.Collections;

public class EasySuspension : MonoBehaviour {
	public float naturalFrequency = 10;
	public float dampingRatio = 0.8f;
	public float forceShift = 0.03f;
	public bool setSuspensionDistance = true;
    private WheelCollider[] wheels;
	void Start ()
	{
		wheels = GetComponentsInChildren<WheelCollider> ();
	}

	void Update () {
		for (int i = 0; i < wheels.Length; i++) {
			WheelCollider wc = wheels[i];
			JointSpring spring = wc.suspensionSpring;

			spring.spring = Mathf.Pow(Mathf.Sqrt(wc.sprungMass) * naturalFrequency, 2);
			spring.damper = 2 * dampingRatio * Mathf.Sqrt(spring.spring * wc.sprungMass);
			wc.suspensionSpring = spring;
            
			Vector3 wheelRelativeBody = transform.InverseTransformPoint(wc.transform.position);
			float distance = GetComponent<Rigidbody>().centerOfMass.y - wheelRelativeBody.y + wc.radius;
			wc.forceAppPointDistance = distance - forceShift;

			if (spring.targetPosition > 0 && setSuspensionDistance)
				wc.suspensionDistance = wc.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
            
		}
	}
    
}
