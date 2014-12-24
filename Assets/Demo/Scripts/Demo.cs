using UnityEngine;
using System.Collections;

public class Demo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnityAndroidExtras.instance.Init();
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
	}
}
