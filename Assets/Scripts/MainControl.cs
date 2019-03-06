using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class MainControl : MonoBehaviour {

	public static bool ManualControl = true;
	public static int action = -1;
	public static bool Updateaction = false;
	public static bool fixedupdate = true;
	public Camera cam;
	private int numActions = 4;
	private Boolean infoSend = false;
	private Boolean infoCheck = false;
	private Boolean imageCheck = false;


	public String host = "localhost";
	public Int32 port = 50002;
	internal Boolean socket_ready = false;
	Socket sender;
	byte[] bytes = null;

	private Boolean controlt = false;
	private Boolean isCoroutineStarted = false;
	WaitForEndOfFrame frameend = new WaitForEndOfFrame();
 
	void Start () {

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 240;


		if (ManualControl == false) {
			cam = GameObject.Find ("MyCamera").GetComponent<Camera> ();
			cam.CopyFrom (Camera.main);
			cam.cullingMask &=  ~(1 << LayerMask.NameToLayer("lifes"));
			//if (socket_ready == false) setupSocket();
			infoSend = false;
			infoCheck = false;
		}

	}


	void Update () {

		if (controlt == false) {
			//UnityEngine.Debug.Log (DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff"));
			controlt = true;
		}

		//UnityEngine.Debug.Log ("frame");

			if (GameController.lifes == 0) {
				GC.Collect ();
				SceneManager.LoadScene ("Stage1");
			}
					
	}

	void OnApplicationQuit()
	{
		closeSocket();
	}
		
	public void setupSocket()
	{
		try
		{
			sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sender.Connect("localhost", port);
			socket_ready = true;

		}
		catch (Exception e)
		{
			
			socket_ready = false;
			UnityEngine.Debug.Log("Socket error: " + e);
		}
	}


	public void closeSocket()
	{
		if (!socket_ready)
			return;
		sender.Close ();
		socket_ready = false;
	}

	private IEnumerator getScreen(){

		isCoroutineStarted = true;
		yield return frameend;
		//UnityEngine.Debug.Log (DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff"));
		RenderTexture currenRT = RenderTexture.active;
		RenderTexture.active = cam.targetTexture;
		cam.Render();
		Texture2D image = new Texture2D(Screen.width, Screen.height);
		image.ReadPixels(new Rect(0,0,Screen.width,Screen.height),0,0);
		image.Apply();
		RenderTexture.active = currenRT;
		bytes = image.EncodeToJPG();
		DestroyImmediate (currenRT);
		DestroyImmediate (image);
	}


}
