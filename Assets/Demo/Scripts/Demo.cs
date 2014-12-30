using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {
	public string url = "http://www.nevzatarman.com";
	public int marginLeft,marginTop,marginRight,marginBottom;

	// Listen for the events
	void OnEnable()
	{
		UnityAndroidExtras.onWebViewStartLoading += onPageStarted;
		UnityAndroidExtras.onWebViewFinishLoading += onPageStarted;
		UnityAndroidExtras.onAlertViewButtonClicked += onAlertButtonClicked;
		UnityAndroidExtras.onAlertViewNegativeButtonClicked += onAlertNegativeButtonClicked;
	}
	void OnDisable()
	{
		UnityAndroidExtras.onWebViewStartLoading -= onPageStarted;
		UnityAndroidExtras.onWebViewFinishLoading -= onPageStarted;
		UnityAndroidExtras.onAlertViewButtonClicked -= onAlertButtonClicked;
		UnityAndroidExtras.onAlertViewNegativeButtonClicked -= onAlertNegativeButtonClicked;
	}

	void Start () {
		UnityAndroidExtras.instance.Init();
	}

	void Update()
	{
		// Closing web view example
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
			UnityAndroidExtras.instance.alert("Alert!","Ok");
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
			UnityAndroidExtras.instance.openWebView(url,marginLeft,marginTop,marginRight,marginBottom);
		}
		if(GUI.Button(new Rect(10,470,200,50),"Open webView without margins"))
		{
			UnityAndroidExtras.instance.openWebView(url);
		}
		if(GUI.Button(new Rect(230,10,200,50),"Alert with negative button"))
		{
			UnityAndroidExtras.instance.alert("Alert!","Ok","Cancel");
		}
	}

	#region IWebViewListener implementation
	// web view listeneres called when page starts loading
	public void onPageStarted ()
	{
		Debug.Log("page loading");
	}
	// web view listeneres called when page starts loading is done
	public void onPageFinished ()
	{
		Debug.Log("page loaded");
	}

	#endregion

	#region IAlertViewListener implementation

	public void onAlertButtonClicked ()
	{
		Debug.Log("clicked");
	}

	public void onAlertNegativeButtonClicked ()
	{
		Debug.Log(" neg clicked");
	}

	#endregion
}
