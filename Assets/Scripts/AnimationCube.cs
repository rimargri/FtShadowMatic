using UnityEngine;
using System.Collections;

public class AnimationCube : MonoBehaviour {
	public AnimationCurve Curve;
	public float Duration;
	public Transform[] target;

	public void Animate()
	{
		StartCoroutine("Animation");
	}

	private IEnumerator Animation()
	{
		foreach (Transform trans in target)
		{
			float start = Time.time;
			Vector3 position = trans.position;
			Vector3 scale = trans.localScale;

			while ((Time.time - start) <= Duration)
			{
				float f = (Time.time - start) / Duration;
				float ff = Curve.Evaluate(f);
				trans.position = position + new Vector3(3f, 0f, 0f) * ff;
				trans.localScale = scale + new Vector3(1f, 1f, 1f) * ff;
				yield return null;
			}
		}
	}
}
