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

// if isComplete && level == 3
// 	Invoke("Transition", 3)

// Transition():
// 	for (buttons):
// 		if (button.isClicked)
// 			WaitUntil(color.a == 1f)

// Animator:
