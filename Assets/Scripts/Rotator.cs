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
			transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime * (-1), 0.0f, 0.0f, Space.Self);
		}
	}

	void rotationLevel2()
	{
		if (Input.GetKey(KeyCode.Mouse0) && !(Input.GetKey(KeyCode.Space))) {
			transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime * (-1), 0.0f, 0.0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse0)) {
			transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime * (-1), 0.0f, Space.Self);
		}
		
		// if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse0))
		// {
		// 	transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime * (-1), Input.GetAxis("Mouse Y") * speedV * Time.deltaTime, 0.0f, Space.Self);
		// }
	}

	void rotationLevel3()
	{
		if (Raycaster.Selected == null) return;
		if (Input.GetKey(KeyCode.Mouse0) && !(Input.GetKey(KeyCode.Space))) {
			Raycaster.Selected.transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse0)) {
			Raycaster.Selected.transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime * (-1), 0.0f, Space.Self);
		}
		if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.M)) {
			Raycaster.Selected.transform.Translate(Vector3.forward * speedMovement * Time.deltaTime, Space.Self);			
		}


		// if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0)) && Input.GetKey(KeyCode.M)) {
		// 	Raycaster.Selected.transform.Translate(Vector3.forward * speedMovement * Time.deltaTime, Space.Self);			
		// }
		// else if (Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.Mouse0))) {
		// 	Raycaster.Selected.transform.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime  * (-1), 0.0f, Space.Self);
		// }
		// else if ((Input.GetKey(KeyCode.Mouse0))) {
		// 	Raycaster.Selected.transform.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime, 0.0f, 0.0f, Space.Self);
		// }
	}

// 57.57

// -647.535

// 423.572



// 48.749

// -636.747

// 430.827



	void Update()
	{
		var pauseMenu = GameObject.Find("Canvas/PauseMenu/Panel");
		if (!(pauseMenu.activeSelf)) {
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
}
