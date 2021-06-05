using UnityEngine;
using UnityEngine.SceneManagement;
public class Rotator : MonoBehaviour
{

	public float speedH = 1000.0f;
	public float speedV = 1000.0f;
	public float speedMovement = 20.0f;

	public RaycastObject Raycaster;


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
		// if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0))) {
		// 	transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime, 0.0f, Space.Self);
		// }
		// else if ((Input.GetKey(KeyCode.Mouse0))) {
		// 	transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
		// }
		
		// if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0))) {
		if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse0)) {
			transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime, 0.0f, Space.Self);
		}
	}

	void rotationLevel3()
	{
		// bool objectSelected = false;
		// var obj = GameObject.Find("Walls");
		// if (PlayerPrefs.GetString("globe") == "base") {
		// 	obj = GameObject.Find("Globe/globe-base"); 
		// 	objectSelected = true;
		// }
		// if (PlayerPrefs.GetString("globe") == "earth") {
		// 	obj = GameObject.Find("Globe/globe-earth"); 
		// 	objectSelected = true;
		// }
		// if (objectSelected && Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0)) && Input.GetKey(KeyCode.M)) {
		// 	obj.transform.Translate(Vector3.forward * speedMovement * Time.deltaTime, Space.Self);			
		// }
		// else if (objectSelected && Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0))) {
		// 	obj.transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime, 0.0f, Space.Self);
		// }
		// else if (objectSelected && (Input.GetKey(KeyCode.Mouse0))) {
		// 	obj.transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
		// }
		if (Raycaster.Selected == null) return;
		if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0)) && Input.GetKey(KeyCode.M)) {
			Raycaster.Selected.transform.Translate(Vector3.forward * speedMovement * Time.deltaTime, Space.Self);			
		}
		else if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0))) {
			Raycaster.Selected.transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime, 0.0f, Space.Self);
		}
		else if ((Input.GetKey(KeyCode.Mouse0))) {
			Raycaster.Selected.transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
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
