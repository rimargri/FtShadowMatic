using UnityEngine;
using UnityEngine.SceneManagement;
public class Rotator : MonoBehaviour
{
	public float speedH = 1000.0f;
	public float speedV = 1000.0f;
	public float speedMovement = 20.0f;
	public RaycastObject Raycaster;
	Vector3 targetPosition;
	private float coefficient4Rotate = 0.0105f;
	private float coefficient4Translate = 0.0035f;

	public void Start()
	{
		targetPosition = transform.position;
	}

	void rotationLevel1()
	{
		if (Raycaster.Selected == null) return;
		var obj = Raycaster.Selected.transform;
		if ((Input.GetKey(KeyCode.Mouse0))) {
			obj.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime * coefficient4Rotate, 0.0f, 0.0f, Space.World);
		}
	}

	void rotationLevel2()
	{
		if (Raycaster.Selected == null) return;
		var obj = Raycaster.Selected.transform;
		if (Input.GetKey(KeyCode.Mouse0)) {
			obj.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime * coefficient4Rotate, 0.0f, 0.0f, Space.World);
		}
		if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.Mouse0)) {
			obj.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime * coefficient4Rotate * (-1), 0.0f, Space.World);
		}
	}


	void rotationLevel3()
	{
		if (Raycaster.Selected == null) return;
		if (Raycaster.Selected.name != "globe-earth")
		{
			var obj = Raycaster.Selected.transform;
			if (Input.GetKey(KeyCode.Mouse0)) {
				obj.Rotate(Input.GetAxis("Mouse X") * speedH * Time.deltaTime * coefficient4Rotate, 0.0f, 0.0f, Space.Self);
			}
			if (((Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.RightControl))) && Input.GetKey(KeyCode.Mouse0)) {
				obj.Rotate(0.0f, Input.GetAxis("Mouse Y") * speedV * Time.deltaTime * (-1) * coefficient4Rotate, 0.0f, Space.Self);
			}
			else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Input.GetKey(KeyCode.Mouse0)) {
				obj.Translate(new Vector3 (10f, 0f, 0f) * Time.deltaTime * coefficient4Translate, Space.World);
			}
			else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Input.GetKey(KeyCode.Mouse0)) {
				obj.Translate(new Vector3 (-10f, 0f, 0f) * Time.deltaTime * coefficient4Translate, Space.World);
			}
		}
	}

	void Update()
	{
		var pauseMenu = GameObject.Find("Canvas/PauseMenu/Panel");
		var lvlWindow = GameObject.Find("Canvas/LvlManager/Panel");
		if (!(pauseMenu.activeSelf) && !(lvlWindow.activeSelf) && (PlayerPrefs.GetInt("completeLvl", 0) == 0)) {
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
