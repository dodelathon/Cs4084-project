using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SOHLogin : MonoBehaviour {
	Firebase.Auth.FirebaseAuth auth;
	Firebase.Auth.FirebaseUser user;
	public InputField EmailAddress, Password;

	public void LoginButtonPressed() {
		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith((obj)=> {
			if (EmailAddress.text!="" && Password.text!="") {
				SceneManager.LoadSceneAsync("Menu");
			}	
		});
	}

	public void CreateNewUserButtonPressed() {
		FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith((obj)=> {
			FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith(task=> {
				SceneManager.LoadSceneAsync("create_account");
			});
		});
	}

	public void GuestButtonPressed() {
		FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().ContinueWith((obj)=> {
			SceneManager.LoadSceneAsync("Menu");
		});
	}
	void InitializeFirebase() {

	  auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	  auth.StateChanged += AuthStateChanged;
	  AuthStateChanged(this, null);
	}

	void AuthStateChanged(object sender, System.EventArgs eventArgs) {
	  if (auth.CurrentUser != user) {
	    bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
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