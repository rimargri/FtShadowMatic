using UnityEngine;

class HandlerButton : MonoBehaviour
{
	public bool clicked = false;

	void LateUpdate()
	{
		clicked = false;
	}

	public void Click()
	{
		clicked = true;
	}
}
