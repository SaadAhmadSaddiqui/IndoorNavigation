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
    public GameObject FitToScanOverlay;
    public GameObject FitToScanOverlay2;
    public Text text; // start text


    // is used at start of application to set initial position
    void Update()
    {
        if (searchingForMarker)
        {
            Scan();
        }
    }
    /// <summary>
    /// Scans the barcode, grabs the text from it, and calls the Relocate method
    /// </summary>
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

    /// <summary>
    /// Locates you for the initial positioning on start of navigation.
    /// </summary>
    /// <param name="wt"></param>
    /// <returns></returns>
    public bool StartPosition(WebCamTexture wt)
    {
        bool succeeded = false;
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(wt.GetPixels32(), wt.width, wt.height);
            foreach (Transform transform in calibrationLocations.transform)
            {
                if (!transform.name.Equals(result.Text))
                {
                    succeeded = false;
                }
                else if (transform.name.Equals(result.Text))
                {
                    Relocate(result.Text);
                    succeeded = true;
                    break;
                }
            }
        }
        catch (Exception ex) 
        { 
            Debug.LogWarning(ex.Message);
        }
        return succeeded;
    }

    /// <summary>
    /// Moves to person indicator to the new spot and re-adjusts the direction.
    /// </summary>
    /// <param name="text">The result text scanned from the QR code.</param>
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
                Handheld.Vibrate();
                FitToScanOverlay2.SetActive(false);
                searchingForMarker = false;
                break;
            }
        }
    }

    /// <summary>
    /// Capture the screen using CameraImage.AcquireCameraImageBytes.
    /// </summary>
    /// <param name="callback">The process in Scan() is sent as a callback and then called here.</param>
    void CaptureScreenAsync(Action<byte[], int, int> callback)
    {
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

    /// <summary>
    /// The method for the Scan Marker button.
    /// </summary>
    public void onClick()
    {
        //counter++;
        Debug.Log("Clicked!");
        if (searchingForMarker == false)
        {
            Debug.Log("Trued");
            searchingForMarker = true;
            //FitToScanOverlay.SetActive(true);
            FitToScanOverlay2.SetActive(true);
            //first = true;
        }
        else if(searchingForMarker == true)
        {
            Debug.Log("Falsed");
            searchingForMarker = false;
            FitToScanOverlay2.SetActive(false);
            //first = false;
        }

    }
}