// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent (typeof(Rigidbody))]
// public class SYJump : MonoBehaviour 
// {
// 	[SerializeField] private float _jumpVelocityChange;
// 	[SerializeField] private float _jumpAcceleration;
 
// 	[SerializeField] private float _startJumpTime;
// 	[SerializeField] private float _maxJumpTime;
	
// 	[SerializeField] private bool _isJumping;
 
// 	private Rigidbody _rigidBody;
 
// 	void Awake( )
// 	{
// 		_rigidBody = this.GetComponent();
// 	}
	
// 	void FixedUpdate() 
// 	{
// 		if ( Input.GetMouseButtonDown(0) && !_isJumping ) {
// 			_isJumping = true;
// 			_startJumpTime = Time.time;
//             _maxJumpTime = _startJumpTime + _airJumpTime;
// 			_rigidBody.AddForce(this.transform.up * _jumpVelocityChange, ForceMode.VelocityChange);
// 		}
// 		else if ( Input.GetMouseButton(0) && _isJumping && ( _startJumpTime + _maxJumpTime > Time.time ) ) 
// 		{
// 			_rigidBody.AddForce(Vector3.up * _jumpAcceleration, ForceMode.Acceleration);
// 		}
// 	}
 
// 	void OnCollisionEnter( Collision collision )
// 	{
// 		_isJumping = false;
// 	}
// }