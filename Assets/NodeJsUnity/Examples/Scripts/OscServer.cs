using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;

public class OscServer : MonoBehaviour
{
	public int listenPort = 6666;
	UdpClient udpClient;
	IPEndPoint endPoint;
	Osc.Parser osc = new Osc.Parser ();

	void Start ()
	{
		endPoint = new IPEndPoint (IPAddress.Any, listenPort);
		udpClient = new UdpClient (endPoint);
	}

	void Update ()
	{
		while (udpClient.Available > 0) {
			osc.FeedData (udpClient.Receive (ref endPoint));
		}

		while (osc.MessageCount > 0) {
			var msg = osc.PopMessage ();

			var target = GameObject.Find (msg.path.Replace ("/", "_"));
			if (target) {
				target.SendMessage ("OnOscMessage", msg.data [0]);
			}

			// Debug.Log (msg);
		}
	}
}
