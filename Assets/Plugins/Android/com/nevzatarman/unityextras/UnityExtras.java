package com.nevzatarman.unityextras;

import java.util.List;

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
import android.view.View;
import android.widget.Toast;

import com.unity3d.player.UnityPlayer;

public class UnityExtras {

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

	public void alert(final String message) {
		final Activity a = UnityPlayer.currentActivity;
		a.runOnUiThread(new Runnable() {
			@Override
			public void run() {
				AlertDialog.Builder bld = new AlertDialog.Builder(a);
				bld.setMessage(message);
				bld.setNeutralButton("Ok", new OnClickListener() {
					@Override
					public void onClick(DialogInterface dialog, int which) {

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

	public void shareOnTwitter(String message,String fallBackUrl) {
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
		a.startActivity(new Intent(Intent.ACTION_VIEW,
				Uri.parse(fallBackUrl)));

	}
}
