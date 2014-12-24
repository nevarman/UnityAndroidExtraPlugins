using UnityEngine;
using System.Collections;

public class UnityAndroidExtras : MonoBehaviour {

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
	public void alert(string message)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("alert",message);
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
}
