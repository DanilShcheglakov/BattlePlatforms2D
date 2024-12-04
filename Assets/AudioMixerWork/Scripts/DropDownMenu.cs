using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VolumeSlider))]
public class DropdownEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		VolumeSlider script = (VolumeSlider)target;

		GUIContent arrayLabel = new GUIContent("Channel");
		script.IndexOfChannel = EditorGUILayout.Popup(arrayLabel, script.IndexOfChannel, script.Channels);
	}
}