using UnityEngine;
using System.Collections;

public static class CGUIScaleModifier
{
	static Matrix4x4 current_matrix;
	public static void apply_scale()
	{
		current_matrix = GUI.matrix;
		float ratio = Screen.height / 480.0f;
		Vector3 scale = Vector3.one;
		scale.x = ratio;
		scale.y = ratio;
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
	}
	
	public static void restore_scale()
	{
		GUI.matrix = current_matrix;
	}
}
