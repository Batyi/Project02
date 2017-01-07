using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private WheelController[] wheelControllers;
    [SerializeField]
    private float maxSteerAngle;
    [SerializeField]
    private Transform massCenter;
    [SerializeField]
    private float engineTorque = 2500;
    [SerializeField]
    private float brakeTorque = 900;
    [SerializeField]
    private Rigidbody rigidbody;
    public AudioClip WallSound;
    private AudioSource audioSource;
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = massCenter.localPosition;
        wheelControllers = GetComponentsInChildren<WheelController>();
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision) {
        audioSource.PlayOneShot(WallSound);
        audioSource.Play();
    }
    void Update() {
    }
    private void FixedUpdate() {
        var steer = maxSteerAngle * Input.GetAxis("Horizontal");
        var torque = engineTorque * Input.GetAxis("Vertical");
        var brake = Input.GetKey(KeyCode.Space);
        for (int i = 0; i < wheelControllers.Length; i++) {
            if (wheelControllers[i].ReceiveSteer)
                wheelControllers[i].WheelCollider.steerAngle = steer;
            if (wheelControllers[i].ReceiveTorque)
                wheelControllers[i].WheelCollider.motorTorque = torque;
            if (brake && wheelControllers[i].ReceiveBrake)
                wheelControllers[i].WheelCollider.brakeTorque = this.brakeTorque;
            else
                wheelControllers[i].WheelCollider.brakeTorque = 0;
        }
    }
}