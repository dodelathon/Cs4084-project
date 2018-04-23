using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;

public class Create_Account : MonoBehaviour {
	Firebase.Auth.FirebaseAuth auth;
	Firebase.Auth.FirebaseUser user;
	public InputField DisplayNameIn;
	

	public void submitButtonPressed() {
		user = auth.CurrentUser;
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

	void InitializeFirebase() {

	  auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	  auth.StateChanged += AuthStateChanged;
	  AuthStateChanged(this, null);
	}

	void AuthStateChanged(object sender, System.EventArgs eventArgs) {
	  if (auth.CurrentUser != user) {
	    bool signedIn = (user != auth.CurrentUser && auth.CurrentUser != null);
	    if (!signedIn && user != null) {
	      Debug.Log("Signed out " + user.UserId);
	    }
	    user = auth.CurrentUser;
	    if (signedIn) {
	      Debug.Log("Signed in " + user.UserId);
	    }
	  }
	}
}