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

	/// <summary>
	/// Shares a link on facebook.
	/// </summary>
	/// <param name="fbLink">Fb link.</param>
	public void shareOnFacebook(string fbLink)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnFacebook",fbLink);
		#endif
	}
	/// <summary>
	/// Shares a text on twitter.If application is not installed opens browser with a twitter link.
	/// </summary>
	/// <param name="message">Message.</param>
	/// <param name="fallBackUrl">Fall back URL.</param>
	public void shareOnTwitter(string message,string fallBackUrl)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnTwitter",message,fallBackUrl);
		#endif
	}
	/// <summary>
	/// Makes the toast.
	/// </summary>
	/// <param name="toast">Toast.</param>
	/// <param name="length"(must be either 0 or 1!)>Length.</param>
	public void makeToast(string toast,int length)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("makeToast",toast,length);
		#endif
	}
	/// <summary>
	/// Alert the specified message with neutralButton.
	/// </summary>
	/// <param name="message">Message.</param>
	/// <param name="neutralButtonText">Neutral button text.</param>
	public void alert(string message,string neutralButtonText)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("alert",message,neutralButtonText,gameObject.name);
		#endif
	}
	/// <summary>
	/// Alert the specified message,with neutralButton and negativeButton.
	/// </summary>
	/// <param name="message">Message.</param>
	/// <param name="neutralButtonText">Neutral button text.</param>
	/// <param name="negativeButtonText">Negative button text.</param>
	public void alert(string message,string neutralButtonText,string negativeButtonText)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("alert",message,neutralButtonText,negativeButtonText,gameObject.name);
		#endif
	}
	/// <summary>
	/// Opens the android default share intent.
	/// </summary>
	/// <param name="message">Message.</param>
	public void openShareIntent(string message)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openShareIntent",message);
		#endif
	}
	/// <summary>
	/// Sets the immersive mode for supporting devices(devices that have virtual button)
	/// </summary>
	public void setImmersiveMode()
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("setImmersiveMode");
		#endif
	}
	/// <summary>
	/// Opens fullscreen web view.
	/// </summary>
	/// <param name="url">URL.</param>
	public void openWebView(string url)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openWebView",url,gameObject.name);
		#endif
	}
	/// <summary>
	/// Opens the web view with margins
	/// </summary>
	/// <param name="url">URL.</param>
	/// <param name="marginLeft">Margin left.</param>
	/// <param name="marginTop">Margin top.</param>
	/// <param name="marginRight">Margin right.</param>
	/// <param name="marginBottom">Margin bottom.</param>
	public void openWebView(string url,int marginLeft,int marginTop, int marginRight,int marginBottom)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openWebView",url,gameObject.name,marginLeft,marginTop,marginRight,marginBottom);
		#endif
	}
	/// <summary>
	/// Closes the web view.
	/// </summary>
	public void closeWebView()
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("closeWebView");
		#endif
	}
	/// <summary>
	/// Checks if a specific application istalled.(usefull for giving gold credit etc...)
	/// </summary>
	/// <returns><c>true</c>, if application istalled was ised, <c>false</c> otherwise.</returns>
	/// <param name="bundleName">Bundle name.</param>
	public bool isApplicationIstalled(string bundleName)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		return jo.Call<bool>("isApplicationInstalled",bundleName);
		#endif
	}
	/// <summary>
	/// Opens another application if it's installed
	/// </summary>
	/// <param name="bundleName">Bundle name.</param>
	public void openApplication(string bundleName)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openApplication",bundleName);
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
