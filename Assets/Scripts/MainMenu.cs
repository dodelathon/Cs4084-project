using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject levelbtnPrefab;
    public GameObject levelbtnContainer;
    private Transform camTrans;
    private Transform camDesiredLookAt;
    private const float CameraTransitionSpeed = 3.0f;

    private void Start()
    {
        camTrans = Camera.main.transform;
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach(Sprite thumbnail in thumbnails)
        {
            GameObject cointainer = Instantiate(levelbtnPrefab) as GameObject;
            cointainer.GetComponent<Image>().sprite = thumbnail;
            cointainer.transform.SetParent(levelbtnContainer.transform, false);

            string sceneName = thumbnail.name;
            cointainer.GetComponent<Button>().onClick.AddListener(() => loadLevel(sceneName));
        }
    }

    private void Update()
    {
        if (camDesiredLookAt != null)
        {
            camTrans.rotation = Quaternion.Slerp(camTrans.rotation, camDesiredLookAt.rotation, CameraTransitionSpeed * Time.deltaTime);
        }
    }
    private void loadLevel (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void lookAtMenu(Transform menuTrans)
    {
        camDesiredLookAt = menuTrans;
    }
    public void loadCamera()
    {
        SceneManager.LoadScene(2);
    }

}
