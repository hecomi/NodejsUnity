using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SocketIOClient;
using SimpleJSON;
using EventItem = System.Collections.Generic.KeyValuePair<string, SimpleJSON.JSONNode>;

public class SocketIO : MonoBehaviour
{
	public string serverUrl = "http://127.0.0.1:8080";
	public List<GameObject> sendTargets;

	private Client client_;
	public Client client {
		get { return client_; }
	}
	private Queue<EventItem> eventQueue_ = new Queue<EventItem>();

	void Awake()
	{
		client_ = new Client(serverUrl);

		client_.Opened  += SocketOpened;
		client_.Message += SocketMessage;
		client_.Error   += SocketError;
		client_.SocketConnectionClosed += SocketConnectionClosed;

		client_.Connect();
	}

	void Update()
	{
		if (!client_.IsConnected) {
			client_.Connect();
		}
		while (eventQueue_.Count > 0) {
			var item = eventQueue_.Dequeue();
			sendTargets.ForEach(target => {
				target.SendMessage("OnWebsocketMessage", item, SendMessageOptions.DontRequireReceiver);
			});
		}
	}

	void OnApplicationQuit()
	{
		if (client_.IsConnected) {
			client_.Close();
			client_.Dispose();
		}
	}

	public void SocketOpened(object sender, EventArgs e)
	{
		Debug.Log("Connected to " + serverUrl);
	}

		private void SocketMessage(object sender, MessageEventArgs e)
		{
			if (e == null || e.Message.MessageText == null) { return; }
			try {
				var jsonText = e.Message.MessageText;
				var root = SimpleJSON.JSON.Parse(jsonText);
				eventQueue_.Enqueue(new EventItem(root["name"], root["args"][0]));
			} catch (Exception error) {
				Debug.LogError(error.Message + error.StackTrace);
			}
		}

	private void SocketConnectionClosed(object sender, EventArgs e)
	{
		Debug.Log("Close connection");
	}

	private void SocketError(object sender, ErrorEventArgs e)
	{
		Debug.LogError(e.Message);
	}
}
