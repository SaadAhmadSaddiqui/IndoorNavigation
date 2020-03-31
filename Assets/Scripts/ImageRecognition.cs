using GoogleARCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class ImageRecognition : MonoBehaviour
{
    public GameObject person;
    public GameObject calibrationLocations;
    private bool searchingForMarker = true;
    //private bool first = true;
    private int counter = 0;
    public GameObject FitToScanOverlay;
    public GameObject FitToScanOverlay2;
    public Text text; // start text


    // is used at start of application to set initial position


    /// <summary>
    /// Capture and scan the current frame 
    /// </summary>
    /// 

    void Update()
    {
        if (searchingForMarker)
        {
            Scan();
        }
    }

    public void Scan()
    {
        System.Action<byte[], int, int> callback = (bytes, width, height) =>
        {
            if (bytes == null)
            {
                // No image is available.
                return;
            }

            // Decode the image using ZXing parser
            IBarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(bytes, width, height, RGBLuminanceSource.BitmapFormat.Gray8);
            var resultText = result.Text;

            // result action
            //if (first)
            //{
                Relocate(resultText);
                //first = false;
            //}
        };

        CaptureScreenAsync(callback);
    }

    public bool StartPosition(WebCamTexture wt)
    {
        bool succeeded = false;
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(wt.GetPixels32(), wt.width, wt.height);
            if (result != null)
            {
                Relocate(result.Text);
                succeeded = true;
                FitToScanOverlay.SetActive(false);
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        return succeeded;
    }
    // move to person indicator to the new spot
    private void Relocate(string text)
    {
        text = text.Trim(); //remove spaces
                            //find the correct location scanned and move the person to its position
        foreach (Transform child in calibrationLocations.transform)
        {
            if (child.name.Equals(text))
            {
                person.transform.position = child.position;
                Camera.main.transform.parent.transform.rotation = child.rotation;
                break;
            }
        }
        FitToScanOverlay.SetActive(false);
        FitToScanOverlay2.SetActive(false);
        searchingForMarker = false;
    }

    /// <summary>
    /// Capture the screen using CameraImage.AcquireCameraImageBytes.
    /// </summary>
    /// <param name="callback"></param>
    void CaptureScreenAsync(Action<byte[], int, int> callback)
    {

        //Task.Run(() =>
        //{
            
        //});
        byte[] imageByteArray = null;
        int width;
        int height;
        using (var imageBytes = Frame.CameraImage.AcquireCameraImageBytes())
        {
            if (!imageBytes.IsAvailable)
            {
                callback(null, 0, 0);
                return;
            }

            int bufferSize = imageBytes.YRowStride * imageBytes.Height;

            imageByteArray = new byte[bufferSize];
            text.text = "Reached CaptureScreenAsync";

            Marshal.Copy(imageBytes.Y, imageByteArray, 0, bufferSize);

            width = imageBytes.Width;
            height = imageBytes.Height;
        }

        callback(imageByteArray, width, height);
    }

    // handle scanmarker button click
    public void onClick()
    {
        //counter++;
        Debug.Log("Clicked!");
        if (searchingForMarker == false)
        {
            Debug.Log("Trued");
            searchingForMarker = true;
            //FitToScanOverlay.SetActive(true);
            FitToScanOverlay.SetActive(true);
            //first = true;
        }
        else if(searchingForMarker == true)
        {
            Debug.Log("Falsed");
            searchingForMarker = false;
            FitToScanOverlay.SetActive(false);
            //first = false;
        }

    }
}