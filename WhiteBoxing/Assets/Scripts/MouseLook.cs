using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float sensitivityHor = 9f;
	public float sensitivityVert = 9f;

	public float minVert = -45f;
	public float maxVert = 45f;

	private float _rotationX = 0f;

    public enum RotationAxis
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxis axes = RotationAxis.MouseXAndY;

    void Update()
    {
        if(axes == RotationAxis.MouseX)
		{
			//horizontal rotation
			transform.Rotate(0f,Input.GetAxis("Mouse X")*sensitivityHor,0f);
		}
		else if(axes == RotationAxis.MouseY)
		{
			//vertical rotation
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0f);
		}
		else
		{
			//horizontal and vertical rotation
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

			float delta = Input.GetAxis("Mouse X") * sensitivityHor;
			float _rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0f);
		}
    }
}
