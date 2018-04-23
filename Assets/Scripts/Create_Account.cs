using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;

public class Create_Account : MonoBehaviour {
	Firebase.Auth.FirebaseAuth auth;
	public InputField DisplayNameIn;
	
	public void submitButtonPressed() {
		Firebase.Auth.FirebaseUser user = auth.CurrentUser;
		if (user != null) {
  		Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
  			DisplayName=DisplayNameIn.text,
  		};
  		user.UpdateUserProfileAsync(profile).ContinueWith(task => {
		    if (task.IsCanceled) {
		      Debug.LogError("UpdateUserProfileAsync was canceled.");
		      return;
		    }
		    if (task.IsFaulted) {
		      Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
		      return;
		    }
		    SceneManager.LoadSceneAsync("Menu");
		    Debug.Log("User profile updated successfully.");
			});
  		}
	}
}