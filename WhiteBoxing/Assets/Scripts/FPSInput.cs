using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
	public float speed = 6f;
	public float gravity = -9.81f;	
	private CharacterController _charController;
	
	void Start()
	{
		_charController = GetComponent<CharacterController>();
	}

	void Update()
	{
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0f, deltaZ);
		movement.y = gravity;
		movement = Vector3.ClampMagnitude(movement, speed);
		movement *= Time.deltaTime;

		movement = transform.TransformDirection(movement);
		_charController.Move(movement);

	}


}
