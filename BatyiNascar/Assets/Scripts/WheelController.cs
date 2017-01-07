using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class WheelController : MonoBehaviour
{
    [SerializeField]
    private WheelCollider wheelCollider;
    [SerializeField]
    private Transform wheelMesh;
    [SerializeField]
    private bool receiveMotorTorque;
    [SerializeField]
    private bool receiveSteer;
    [SerializeField]
    private bool receiveBrake;
    public bool ReceiveSteer {get {return receiveSteer;}}
    public bool ReceiveTorque {get {return receiveMotorTorque;}}
    public bool ReceiveBrake {get {return receiveBrake;}}
    public WheelCollider WheelCollider {get { return wheelCollider;}}

    private void Awake() {
        wheelCollider = GetComponent<WheelCollider>();
    }
    private void FixedUpdate() {
    }
 
}