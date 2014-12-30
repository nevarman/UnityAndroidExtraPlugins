using UnityEngine;
using System.Collections;

public class UnityAndroidExtras : MonoBehaviour,IWebViewListener,IAlertViewListener {

	/** Instance */
	static UnityAndroidExtras _instance = null;
	public static UnityAndroidExtras instance
	{
		get
		{
			if(!_instance){
				_instance = FindObjectOfType(typeof(UnityAndroidExtras)) as UnityAndroidExtras;
				
				if(!_instance)
				{
					var obj = new GameObject("UnityAndroidExtras");
					_instance = obj.AddComponent<UnityAndroidExtras>();
				}
			}
			return _instance;
		}
	}
	// Events for Webview listeners
	public delegate void OnWebViewStartLoading();
	public static event OnWebViewStartLoading onWebViewStartLoading;
	public delegate void OnWebViewFinishLoading();
	public static event OnWebViewFinishLoading onWebViewFinishLoading;
	// Events for alertview listeners
	public delegate void OnAlertViewButtonClicked();
	public static event OnAlertViewButtonClicked onAlertViewButtonClicked;
	public delegate void OnAlertViewNegButtonClicked();
	public static event OnAlertViewNegButtonClicked onAlertViewNegativeButtonClicked;


	#if !DEBUGMODE && UNITY_ANDROID
	AndroidJavaObject jo =null;
	#endif

	// Use this for initialization
	void Start () {
		#if !DEBUGMODE && UNITY_ANDROID
		jo =  new AndroidJavaObject("com.nevzatarman.unityextras.UnityExtras");
		#endif
	}
	public void Init(){}

	public void shareOnFacebook(string fbLink)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnFacebook",fbLink);
		#endif
	}
	public void shareOnTwitter(string message,string fallBackUrl)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnTwitter",message,fallBackUrl);
		#endif
	}
	public void makeToast(string toast)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("makeToast",toast);
		#endif
	}
	public void alert(string message,string neutralButtonText)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("alert",message,neutralButtonText,gameObject.name);
		#endif
	}
	public void alert(string message,string neutralButtonText,string negativeButtonText)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("alert",message,neutralButtonText,negativeButtonText,gameObject.name);
		#endif
	}
	public void openShareIntent(string message)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openShareIntent",message);
		#endif
	}
	public void setImmersiveMode()
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("setImmersiveMode");
		#endif
	}
	public void openWebView(string url)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openWebView",url,gameObject.name);
		#endif
	}
	public void openWebView(string url,int marginLeft,int marginTop, int marginRight,int marginBottom)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openWebView",url,gameObject.name,marginLeft,marginTop,marginRight,marginBottom);
		#endif
	}
	public void closeWebView()
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("closeWebView");
		#endif
	}

	#region IWebViewListener implementation

	public void onPageStarted (string s)
	{
		if(onWebViewStartLoading != null)onWebViewStartLoading();
	}

	public void onPageFinished (string s)
	{
		if(onWebViewFinishLoading != null)onWebViewFinishLoading();
	}

	#endregion

	#region IAlertViewListener implementation

	public void onAlertButtonClicked (string s)
	{
		if(onAlertViewButtonClicked!=null) onAlertViewButtonClicked();
	}

	public void onAlertNegativeButtonClicked (string s)
	{
		if(onAlertViewNegativeButtonClicked!=null) onAlertViewNegativeButtonClicked();
	}

	#endregion
}
