using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CheckButtonWasPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public bool buttonPressed;
	public void OnPointerDown(PointerEventData eventData){
		buttonPressed = true;
		Debug.Log("button pressed");
	}
	public void OnPointerUp(PointerEventData eventData){
		buttonPressed = false;
	}

}
