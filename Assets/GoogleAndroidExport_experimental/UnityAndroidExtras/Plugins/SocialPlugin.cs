//#define DEBUGMODE // Commnet this ON RELEASE!
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class SocialPlugin : MonoBehaviour 
{

#if !DEBUGMODE && UNITY_ANDROID
	private static AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	private static AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
#endif

	public static void callShareOnFacebook()
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnFacebook");
		#endif
	}
	public static void callShareOnTwitter()
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("shareOnTwitter");
		#endif
	}
	public static void makeToast(string toast)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("makeToast",toast);
		#endif
	}
	public static void alert(string message)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("alert",message);
		#endif
	}
	public static void openShareIntent(string message)
	{
		#if !DEBUGMODE && UNITY_ANDROID
		jo.Call("openShareIntent",message);
		#endif
	}
}
