using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Android_Camera : MonoBehaviour {

    private bool camAvalible;
    private WebCamTexture frontCam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;


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
            if(devices[i].isFrontFacing)
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
        float scaleY = frontCam.videoVerticallyMirrored ? -1f: 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -frontCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
