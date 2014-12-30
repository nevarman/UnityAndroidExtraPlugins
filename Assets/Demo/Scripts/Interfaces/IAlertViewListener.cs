using UnityEngine;
using System.Collections;

public interface IAlertViewListener {

	void onAlertButtonClicked(string s);
	void onAlertNegativeButtonClicked(string s);
}
