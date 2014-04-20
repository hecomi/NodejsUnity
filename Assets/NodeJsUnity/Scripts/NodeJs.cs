using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeJs : MonoBehaviour
{
	#region [ static members ]
	#if UNITY_STANDALONE_WIN
	private static readonly string NodeBinPath = "node.exe";
	#endif
	#if UNITY_STANDALONE_OSX
	private static readonly string NodeBinPath = "node";
	#endif
	private static readonly string NodeScriptPath = ".node/";
	private static string NodeBinFullPath;
	private static string NodeScriptFullPath;
	private static bool IsInitialized = false;
	#endregion

	#region [ member variables ]
	public string scriptPath = "";
	private System.Diagnostics.Process process_ = null;
	private List<string> logs_ = new List<string>();
	public int logLength = 10;
	public string log = "";
	#endregion

	#region [ getter / setter ]
	public bool isRunning { get; set; }
	#endregion

	#region [ member functions ]
	private void SetFullPath()
	{
		if (!IsInitialized) {
			NodeBinFullPath = System.IO.Path.Combine(Application.streamingAssetsPath, NodeBinPath);
			NodeScriptFullPath = System.IO.Path.Combine(Application.streamingAssetsPath, NodeScriptPath);
			IsInitialized = true;
		}
	}

	void Awake()
	{
		isRunning = false;
		SetFullPath();
		Run();
	}

	void OnApplicationQuit()
	{
		if (process_ != null && !process_.HasExited) {
			process_.Kill();
			process_.Dispose();
		}
	}

	void Run()
	{
		if (isRunning) {
			Debug.LogError("Already Running: " + scriptPath);
			return;
		}

		process_ = new System.Diagnostics.Process();
		process_.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		process_.StartInfo.FileName = NodeBinFullPath;
		process_.StartInfo.Arguments = NodeScriptFullPath + scriptPath;
		process_.StartInfo.CreateNoWindow = true;
		process_.StartInfo.RedirectStandardOutput = true;
		process_.StartInfo.RedirectStandardError = true;
		process_.StartInfo.UseShellExecute = false;
		process_.StartInfo.WorkingDirectory = NodeScriptFullPath;
		process_.OutputDataReceived += OnOutputData;
		process_.ErrorDataReceived += OnOutputData;
		process_.EnableRaisingEvents = true;
		process_.Exited += OnExit;
		process_.Start();
		process_.BeginOutputReadLine();
		process_.BeginErrorReadLine();
		isRunning = true;
	}

	void Stop()
	{
		if (!isRunning) {
			Debug.LogError("Already Stopping: " + scriptPath);
			return;
		}
		isRunning = true;
		process_.Kill();
		process_.Dispose();
	}

	void OnOutputData(object sender, System.Diagnostics.DataReceivedEventArgs e)
	{
		if (logs_.Count > logLength) logs_.RemoveAt(0);
		logs_.Add(e.Data);
		log = "";
		logs_.ForEach(line => { log += line + "\n"; });
	}

	void OnExit(object sender, System.EventArgs e)
	{
		isRunning = false;
		if (process_.ExitCode != 0) {
			Debug.LogError("Error! Exit Code: " + process_.ExitCode);
		}
	}
	#endregion
}
