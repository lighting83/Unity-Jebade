using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUI : MonoBehaviour
{
	private Camera _camera;

	private void Start()
	{
		_camera = GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void OnGUI()
	{
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 4;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	

}
