using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour,IWebViewListener {
	public string url = "http://www.nevzatarman.com";
	public int marginLeft,marginTop,marginRight,marginBottom;

	void Start () {
		UnityAndroidExtras.instance.Init();
	}

	void Update()
	{
		// if back button pressed close webView or call it on OnDisable
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			UnityAndroidExtras.instance.closeWebView();
		}
	}
	
	void OnGUI () {
		if(GUI.Button(new Rect(10,10,100,50),"Share FB"))
		{
			UnityAndroidExtras.instance.shareOnFacebook("https://www.facebook.com/nexxmboile");
		}
		if(GUI.Button(new Rect(10,70,100,50),"Share Tweet"))
		{
			UnityAndroidExtras.instance.shareOnTwitter("Awesome tutorial @nexxmobile","https://www.twitter.com/nexxmobile");
		}
		if(GUI.Button(new Rect(10,130,100,50),"Make Toast"))
		{
			UnityAndroidExtras.instance.makeToast("Toast!");
		}
		if(GUI.Button(new Rect(10,190,100,50),"Alert"))
		{
			UnityAndroidExtras.instance.alert("Alert!");
		}
		if(GUI.Button(new Rect(10,260,100,50),"Open share intent"))
		{
			UnityAndroidExtras.instance.openShareIntent("Sharing stuff!");
		}
		if(GUI.Button(new Rect(10,330,200,50),"Toggle Immersive Mode(check supporting device)"))
		{
			UnityAndroidExtras.instance.setImmersiveMode();
		}
		if(GUI.Button(new Rect(10,400,200,50),"Open webView with margins"))
		{
			UnityAndroidExtras.instance.openWebView(url,gameObject.name,marginLeft,marginTop,marginRight,marginBottom);
		}
		if(GUI.Button(new Rect(10,470,200,50),"Open webView without margins"))
		{
			UnityAndroidExtras.instance.openWebView(url,gameObject.name);
		}
	}

	#region IWebViewListener implementation
	// web view listeneres called when page starts loading
	public void onPageStarted (string s)
	{
		Debug.Log(s);
	}
	// web view listeneres called when page starts loading is done
	public void onPageFinished (string s)
	{
		Debug.Log(s);
	}

	#endregion
}
