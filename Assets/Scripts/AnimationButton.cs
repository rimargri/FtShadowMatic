using UnityEngine;
using System.Collections;

public class AnimationButton : MonoBehaviour {

	// private Animator _anim;

	// void Start() {
	// 	_anim = GetComponent<Animator>();
	// }
	// public void Update()
	// {
	// 	// var anim = GetComponent(Animator);
	// 	var GameObj = GameObject.Find("Canvas/Panel/PRESSButton");
	// 	var but = GameObj.GetComponent <CheckButtonWasPressed> ();
	// 	if (but.buttonPressed == true) {
	// 		_anim.enabled = true;
	// 	}
	// }

	public AnimationCurve Curve;
	public float Duration;
	public Transform target;
	
	public void Animate()
	{
		StartCoroutine("Animation");
	}

	private IEnumerator Animation()
	{
		float start = Time.time;
		Vector3 position = target.position;
		Vector3 scale = target.localScale;

		while ((Time.time - start) <= Duration)
		{
			float f = (Time.time - start) / Duration;
			float ff = Curve.Evaluate(f);
			target.position = position + new Vector3(3f, 0f, 0f) * ff;
			target.localScale = scale + new Vector3(1f, 1f, 1f) * ff;
			yield return null;
		}
	}
}
