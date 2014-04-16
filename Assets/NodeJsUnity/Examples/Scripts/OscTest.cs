using UnityEngine;
using System.Collections;

public class OscTest : MonoBehaviour
{
	void OnOscMessage(object msg)
	{
		var p = msg.ToString().Split(
			new string[]{","}, System.StringSplitOptions.None);
		transform.position = new Vector3(
			float.Parse(p[0]), float.Parse(p[1]), float.Parse(p[2]));
	}
}
