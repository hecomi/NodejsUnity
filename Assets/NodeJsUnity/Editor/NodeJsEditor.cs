using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NodeJs))]
public sealed class NodeJsEditor : Editor
{
	public override void OnInspectorGUI()
	{
		var nodejs = target as NodeJs;

		var scriptPath = EditorGUILayout.TextField("Script Path", nodejs.scriptPath);
		if (scriptPath != nodejs.scriptPath) {
			nodejs.scriptPath = scriptPath;
		}

		var logLength = EditorGUILayout.IntField("Log Length", nodejs.logLength);
		if (logLength != nodejs.logLength) {
			nodejs.logLength = logLength;
		}

		EditorGUILayout.LabelField("Output Log");
		EditorGUI.indentLevel++;
		EditorGUILayout.TextArea(nodejs.log);
		EditorGUI.indentLevel--;
	}
}

