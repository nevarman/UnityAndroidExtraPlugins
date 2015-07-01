using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(GUI.Button(new Rect(10,10,100,50),"Share FB"))
		{
			SocialPlugin.callShareOnFacebook();
		}
		if(GUI.Button(new Rect(10,70,100,50),"Share Tweet"))
		{
			SocialPlugin.callShareOnTwitter();
		}
		if(GUI.Button(new Rect(10,130,100,50),"Make Toast"))
		{
			SocialPlugin.makeToast("Toast!");
		}
		if(GUI.Button(new Rect(10,190,100,50),"Alert"))
		{
			SocialPlugin.alert("Alert!");
		}
		if(GUI.Button(new Rect(10,260,100,50),"Open share intent"))
		{
			SocialPlugin.openShareIntent("Sharing stuff!");
		}
	}
}
