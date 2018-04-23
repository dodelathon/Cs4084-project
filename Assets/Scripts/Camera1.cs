using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Camera1 : MonoBehaviour {

    private bool camAvalible;
    private WebCamTexture frontCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;
    public string dir;

    int _CaptureCounter = 0;

    private void Start()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("no cam");
            camAvalible = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }
        if (frontCam == null)
        {
            return;
        }
        frontCam.Play();
        background.texture = frontCam;
        camAvalible = true;


        
    }

    private void Update()
    {
        if (!camAvalible)
            return;
        float ratio = (float)frontCam.width / (float)frontCam.height;
        fit.aspectRatio = ratio;
        float scaleY = frontCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -frontCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
   public void snap()
    {

        Texture2D snapshot = new Texture2D(frontCam.width, frontCam.height);
        snapshot.SetPixels(frontCam.GetPixels());
        background.texture = snapshot;
        snapshot.Apply();
        StartCoroutine(CaptureTextureAsPNG());
        ++_CaptureCounter;
    }
    IEnumerator CaptureTextureAsPNG()
    {
        yield return new WaitForEndOfFrame();
        Texture2D _TextureFromCamera = new Texture2D(GetComponent<Renderer>().material.mainTexture.width,
        GetComponent<Renderer>().material.mainTexture.height);
        _TextureFromCamera.SetPixels((GetComponent<Renderer>().material.mainTexture as WebCamTexture).GetPixels());
        _TextureFromCamera.Apply();
        byte[] bytes = _TextureFromCamera.EncodeToPNG();
        string filePath = "SavedScreen1.png";

        File.WriteAllBytes(filePath, bytes);

    }
}
