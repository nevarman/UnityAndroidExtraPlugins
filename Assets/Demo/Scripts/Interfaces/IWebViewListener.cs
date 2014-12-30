using UnityEngine;
using System.Collections;

public interface IWebViewListener {

	void onPageStarted(string s);
	void onPageFinished(string s);
}
