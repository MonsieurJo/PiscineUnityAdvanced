using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AutoMoveCorrection : MonoBehaviour {

	public float maxSpeed = 100f;
	public float forwardAcceleration = 20f;

    public float straffMaxSpeed = 100f;
    public float straffTime = 0.1f;


	private Rigidbody _rigidbody;
	private float _smoothXVelocity;
	private float _smoothYVelocity;

	private void Awake(){
		_rigidbody = GetComponent<Rigidbody>();
		Assert.IsNotNull(_rigidbody);
	}

	// Use this for initialization
	void Start () {
		
	}

	private void FixedUpdate(){
		Vector3 newVelocity = _rigidbody.velocity;
		if (newVelocity.z > maxSpeed){
			newVelocity.z = maxSpeed;
		}
		else{
			newVelocity.z += forwardAcceleration * Time.fixedDeltaTime;
		}

        float targetXVelocity = Input.GetAxis("Horizontal") * straffMaxSpeed;
        float targetYVelocity = Input.GetAxis("Vertical") * straffMaxSpeed;

        newVelocity.x = Mathf.SmoothDamp(newVelocity.x, targetXVelocity, ref _smoothXVelocity, straffTime);
        newVelocity.y = Mathf.SmoothDamp(newVelocity.y, targetYVelocity, ref _smoothYVelocity, straffTime);

		_rigidbody.velocity = newVelocity;
	}
	
	// Update is called once per frame
	private void LateUpdate () {
		Debug.Log(_rigidbody.velocity.z);
	}
}
