using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

public class PostProcessSwap : Editor {

	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
		if(target == BuildTarget.Android )
		{
			string bundle = PlayerSettings.bundleIdentifier;
			bundle = bundle.Replace(".","/");
//			Debug.Log(bundle);

			string copyDirJava = string.Empty;
			string copyDirXml = string.Empty;
			string copyDirRoot = pathToBuiltProject+"/"+PlayerSettings.productName;
//			Debug.Log("path "+ copyDirRoot );

			//Files to copy
			DirectoryInfo copyDirectoryInfo = new DirectoryInfo("Assets/UnityAndroidExtras/Editor/Files");
			//Root folder to put files in
			if(Directory.Exists(copyDirRoot))
			{
				DirectoryInfo[] copyToDirectoryInfo = new DirectoryInfo(copyDirRoot).GetDirectories();
				// if we export project
				if(copyToDirectoryInfo.Length > 0 )
				{
					foreach(DirectoryInfo d in copyToDirectoryInfo)
					{
						// if we have src folder
						if(d.Name == "src")
						{
							copyDirJava = d.FullName + "/" + bundle;
							//						Debug.Log(copyDirJava);
						}
					}
					copyDirXml = copyDirRoot;
					// get java files
					FileInfo[] javaFiles= copyDirectoryInfo.GetFiles("*java");
					// if we have any xml files also
					FileInfo[] xmlFiles= copyDirectoryInfo.GetFiles("*xml");
					foreach(FileInfo i in javaFiles)
					{
						i.CopyTo(copyDirJava+"/"+i.Name,true);
						Debug.Log("java file copied");
						Debug.Log("You can import the project into eclipse and run!");
					}
					foreach(FileInfo j in xmlFiles)
					{
						j.CopyTo(copyDirXml+"/"+j.Name,true);
						Debug.Log("xml file copied");
					}
				}
			}
			else 
			{
				Debug.LogWarning("You have to export as google android project for this project to work!");
			}
		}
	}
}
