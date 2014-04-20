using UnityEngine;
using System.Collections;
using SocketIOClient;
using EventItem = System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode>;

public class SocketIoTest : MonoBehaviour
{
	void OnWebsocketMessage(EventItem msg)
	{
		switch (msg.Key) {
			case "browser/move":
				transform.position = new Vector3(msg.Value["x"].AsFloat, msg.Value["y"].AsFloat) * 10.0f;
				break;
		}
	}
}
