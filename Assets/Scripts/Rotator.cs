using UnityEngine;
using UnityEngine.SceneManagement;
public
 class Rotator : MonoBehaviour
{

	public float speedH = 1000.0f;
	public float speedV = 1000.0f;
	public float speedMovement = 20.0f;


	// private void Start()
	// {
	// 	Cursor.lockState = CursorLockMode.Locked;
	// }

	void rotationLevel1()
	{
		if ((Input.GetKey(KeyCode.Mouse0))) {
			transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
		}
	}

	void rotationLevel2()
	{
		if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0))) {
			transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime, 0.0f, Space.Self);
		}
		else if ((Input.GetKey(KeyCode.Mouse0))) {
			transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
		}
	}

	void rotationLevel3()
	{
		if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0)) && Input.GetKey(KeyCode.M)) {
			transform.Translate(Vector3.forward * speedMovement * Time.deltaTime, Space.Self);			
		}
		else if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0))) {
			transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime, 0.0f, Space.Self);
		}
		else if ((Input.GetKey(KeyCode.Mouse0))) {
			transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
		}
	}


	void Update()
	{
		if (SceneManager.GetActiveScene().name == "Level 1") {
			rotationLevel1();
		}
		if (SceneManager.GetActiveScene().name == "Level 2") {
			rotationLevel2();
		}
		if (SceneManager.GetActiveScene().name == "Level 3") {
			rotationLevel3();
		}
	}
}
