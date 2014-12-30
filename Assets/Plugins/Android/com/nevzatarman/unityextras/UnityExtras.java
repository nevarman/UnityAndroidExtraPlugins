package com.nevzatarman.unityextras;

import java.util.List;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.ComponentName;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.net.Uri;
import android.os.Build;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;

public class UnityExtras {
	LinearLayout _webViewLayout;
	WebView _webView;

	public UnityExtras() {

	}

	public void makeToast(final String message) {
		final Activity a = UnityPlayer.currentActivity;
		a.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				Toast.makeText(a, message, Toast.LENGTH_SHORT).show();
			}
		});
	}

	public void openShareIntent(final String message) {
		final Activity a = UnityPlayer.currentActivity;
		Intent sharingIntent = new Intent(android.content.Intent.ACTION_SEND);
		sharingIntent.setType("text/plain");
		sharingIntent.putExtra(android.content.Intent.EXTRA_SUBJECT,
				"Subject Here");
		sharingIntent.putExtra(android.content.Intent.EXTRA_TEXT, message);
		a.startActivity(sharingIntent);
	}

	public void alert(final String message,final String buttonText,final String gameObject) {
		final Activity a = UnityPlayer.currentActivity;
		a.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				AlertDialog.Builder bld = new AlertDialog.Builder(a);
				bld.setMessage(message);
				bld.setNeutralButton(buttonText, new OnClickListener() {
					@Override
					public void onClick(DialogInterface dialog, int which) {
						UnityPlayer.UnitySendMessage(gameObject, "onAlertButtonClicked", "neutralButton");
					}
				});
				bld.create().show();
			}
		});
	}
	public void alert(final String message,final String buttonText,final String negativeButtonText,final String gameObject) {
		final Activity a = UnityPlayer.currentActivity;
		a.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				AlertDialog.Builder bld = new AlertDialog.Builder(a);
				bld.setMessage(message);
				bld.setNeutralButton(buttonText, new OnClickListener() {
					@Override
					public void onClick(DialogInterface dialog, int which) {
						UnityPlayer.UnitySendMessage(gameObject, "onAlertButtonClicked", "neutralButton");
					}
				});
				bld.setNegativeButton(negativeButtonText, new OnClickListener() {
					
					@Override
					public void onClick(DialogInterface dialog, int which) {
						UnityPlayer.UnitySendMessage(gameObject, "onAlertNegativeButtonClicked", "negativeButton");
					}
				});
				bld.create().show();
			}
		});
	}

	@TargetApi(Build.VERSION_CODES.KITKAT)
	public void setImmersiveMode() {
		if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.KITKAT) {
			final Activity a = UnityPlayer.currentActivity;
			a.runOnUiThread(new Runnable() {

				@Override
				public void run() {
					a.getWindow()
							.getDecorView()
							.setSystemUiVisibility(
									View.SYSTEM_UI_FLAG_LAYOUT_STABLE
											| View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
											| View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
											| View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
											| View.SYSTEM_UI_FLAG_FULLSCREEN
											| View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY);

				}
			});

		}
	}

	public void shareOnFacebook(String fbLink) {
		final Activity a = UnityPlayer.currentActivity;
		try {
			Intent shareIntent = new Intent(Intent.ACTION_SEND);
			shareIntent.setType("text/plain");
			String shareText = fbLink;
			shareIntent.putExtra(Intent.EXTRA_TEXT, shareText);
			String appName = "facebook";
			final PackageManager pm = a.getPackageManager();
			final List<?> activityList = pm.queryIntentActivities(shareIntent,
					0);
			int len = activityList.size();
			for (int i = 0; i < len; i++) {
				final ResolveInfo app = (ResolveInfo) activityList.get(i);
				if ((app.activityInfo.name.contains(appName))) {
					final ActivityInfo activity = app.activityInfo;
					final ComponentName name = new ComponentName(
							activity.applicationInfo.packageName, activity.name);
					shareIntent.setComponent(name);
					a.startActivity(shareIntent);
					return;
				}
			}
		} catch (Exception e) {
			a.startActivity(new Intent(Intent.ACTION_VIEW, Uri.parse(fbLink)));
			return;
		}
		a.startActivity(new Intent(Intent.ACTION_VIEW, Uri.parse(fbLink)));
	}

	public void shareOnTwitter(String message, String fallBackUrl) {
		final Activity a = UnityPlayer.currentActivity;
		Intent shareIntent = new Intent(Intent.ACTION_SEND);
		shareIntent.setType("text/plain");
		String shareText = message;
		shareIntent.putExtra(Intent.EXTRA_TEXT, shareText);
		String appName = "twitter";
		final PackageManager pm = a.getPackageManager();
		final List<?> activityList = pm.queryIntentActivities(shareIntent, 0);
		int len = activityList.size();
		for (int i = 0; i < len; i++) {
			final ResolveInfo app = (ResolveInfo) activityList.get(i);
			if ((app.activityInfo.name.contains(appName))) {
				final ActivityInfo activity = app.activityInfo;
				final ComponentName name = new ComponentName(
						activity.applicationInfo.packageName, activity.name);
				shareIntent.setComponent(name);
				a.startActivity(shareIntent);
				return;
			}
		}
		a.startActivity(new Intent(Intent.ACTION_VIEW, Uri.parse(fallBackUrl)));

	}

	public void openWebView(final String url, final String gameObject) {
		Activity a = UnityPlayer.currentActivity;
		a.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				setWebView(url, gameObject, 0, 0, 0, 0);
			}
		});
	}

	public void openWebView(final String url, final String gameObject,
			final int _marginLeft, final int _marginTop,
			final int _marginRight, final int _marginBottom) {
		Activity a = UnityPlayer.currentActivity;
		a.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				setWebView(url, gameObject, _marginLeft, _marginTop,
						_marginRight, _marginBottom);
			}
		});
	}

	/** DONT FORGET TO CALL IT ON ONDISABLE */
	public void closeWebView() {
		Activity a = UnityPlayer.currentActivity;
		a.runOnUiThread(new Runnable() {

			@Override
			public void run() {
				_webView = null;
				try {
					if (_webViewLayout != null)
						_webViewLayout.clearAnimation();
					_webViewLayout.removeAllViews();
				} catch (Exception e) {
					e.printStackTrace();
				}

			}
		});
	}

	@SuppressLint("SetJavaScriptEnabled")
	private void setWebView(String _url, String gameObject, int _marginLeft,
			int _marginTop, int _marginRight, int _marginBottom) {
		try {
			final Activity a = UnityPlayer.currentActivity;
			if(_webView == null)
			{
				_webViewLayout = new LinearLayout(a);
				LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(
						ViewGroup.LayoutParams.MATCH_PARENT,
						LayoutParams.MATCH_PARENT);
				layoutParams.setMargins(_marginLeft, _marginTop, _marginRight,
						_marginBottom);

				_webViewLayout.setLayoutParams(layoutParams);
				_webViewLayout.requestLayout();
				_webViewLayout.setFocusable(true);
				_webViewLayout.setFocusableInTouchMode(true);
				
				_webView = new WebView(a);
				
				_webView.setLayoutParams(layoutParams);
				_webView.requestFocusFromTouch();
				_webView.setFocusable(true);
				_webView.setFocusableInTouchMode(true);
				
				_webViewLayout.addView(_webView);
				_webViewLayout.bringToFront();

				// _webView.setLayoutParams(layoutParams);
				WebSettings webSettings = _webView.getSettings();
				webSettings.setUseWideViewPort(true);
				webSettings.setLoadWithOverviewMode(true);

				webSettings.setJavaScriptEnabled(true);
				_webView.setWebViewClient(new UWebClient(gameObject));
				a.addContentView(_webViewLayout, layoutParams);
			}
			_webView.loadUrl(_url);
		} catch (Exception e) {
			Log.e("Unity", e.toString());
			UnityPlayer.UnitySendMessage(gameObject, "onPageStarted",
					"Connection Error");
			closeWebView();
		}
	}

}
