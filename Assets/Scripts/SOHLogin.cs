using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SOHLogin : MonoBehaviour
{
    public InputField EmailAddress, Password;

    public void LoginButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith((obj) => {
            SceneManager.LoadSceneAsync("Menu");
        });
    }

    public void GuestButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync().ContinueWith((obj) => {
            SceneManager.LoadSceneAsync("Menu");
        });
    }

    public void CreateNewUserButtonPressed()
    {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith((obj) => {
            SceneManager.LoadSceneAsync("create_account");
        });
    }
}