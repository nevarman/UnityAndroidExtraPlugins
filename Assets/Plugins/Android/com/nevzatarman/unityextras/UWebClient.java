package com.nevzatarman.unityextras;

import android.graphics.Bitmap;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import com.unity3d.player.UnityPlayer;

public class UWebClient extends WebViewClient{
	String sendMessageObject;
	public UWebClient(String gameObject) {
		this.sendMessageObject = gameObject;
	}
	@Override
	public void onPageStarted(WebView view, String url, Bitmap favicon) {
		// TODO Auto-generated method stub
		super.onPageStarted(view, url, favicon);
		UnityPlayer.UnitySendMessage(this.sendMessageObject, "onPageStarted", "Webview loading");
	}
	@Override
	public void onPageFinished(WebView view, String url) {
		// TODO Auto-generated method stub
		super.onPageFinished(view, url);
		UnityPlayer.UnitySendMessage(this.sendMessageObject, "onPageFinished", "Webview loaded");
	}
}
