using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class LocationPermissionManager : MonoBehaviour
{
    [Header("Ref UI Text for permission status")]
    public Text StatusText;

    [Header("Wait time after requesting permissions to ask for permissions again")]
    public float DelayAfterRequestPermissions = 2f;

    // UNSUPPORTED UNITY VERION
    // private bool DontAskAgain = false;

     private void Start()
    {
        try
        {
            // Check if permission is already granted
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                // Bind to callback functions and request user permission
                // var callbacks = new PermissionCallbacks();
                // callbacks.PermissionDenied += PermissionCallbacks_PermissionDenied;
                // callbacks.PermissionGranted += PermissionCallbacks_PermissionGranted;
                // callbacks.PermissionDeniedAndDontAskAgain += PermissionCallbacks_PermissionDeniedAndDontAskAgain;
                // Permission.RequestUserPermission(Permission.FineLocation, callbacks);
                Permission.RequestUserPermission(Permission.FineLocation);

                // Check after DelayAfterRequestPermissions seconds if permissions are granted
                StartCoroutine(CheckPermissionAfterDelay(DelayAfterRequestPermissions));
            }
            else
            {
                UpdateUI(true);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error checking or requesting location permission:  " + ex.Message);
            UpdateUI(false);
        }
    }

    // Coroutine to request permission again
    private IEnumerator CheckPermissionAfterDelay(float delay)
    {
        // UNSUPPORTED UNITY VERION: Check if the user has requested not to ask again
        // if(DontAskAgain)
        // {
        //     yield break;
        // }
         
        yield return new WaitForSeconds(delay);
        try
        {
            // Check if permission is already granted
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                // UNSUPPORTED UNITY VERION: Bind to callback functions and request user permission
                // var callbacks = new PermissionCallbacks();
                // callbacks.PermissionDenied += PermissionCallbacks_PermissionDenied;
                // callbacks.PermissionGranted += PermissionCallbacks_PermissionGranted;
                // callbacks.PermissionDeniedAndDontAskAgain += PermissionCallbacks_PermissionDeniedAndDontAskAgain;
                // Permission.RequestUserPermission(Permission.FineLocation, callbacks);
                Permission.RequestUserPermission(Permission.FineLocation);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error checking or requesting location permission after " + delay + " seconds: " + ex.Message);
            UpdateUI(false);
        }
    }

    private void UpdateUI(bool granted)
    {
        if (StatusText != null)
        {
            if(granted)
            {
                StatusText.text = "Location Permission: Granted";
                Debug.Log("Location permission successfully granted.");
            }
            else
            {
                StatusText.text = "Location Permission: Denied";
                Debug.Log("Location permission denied.");
            }
        }
        else
        {
            Debug.LogWarning("A UI Text has not been assigned to display the permission status.");
        }
    }

    // UNSUPPORTED UNITY VERION: Callback funcitions
    // internal void PermissionCallbacks_PermissionGranted(string permissionName)
    // {
    //     Debug.Log("Permission Granted: " + permissionName);
    //     if (StatusText != null)
    //     {
    //         UpdateUI(true);
    //     }
    // }

    // internal void PermissionCallbacks_PermissionDenied(string permissionName)
    // {
    //     Debug.Log("Permission Denied: " + permissionName);
    //     if (StatusText != null)
    //     {
    //         UpdateUI(false);
    //     }
    // }

    // internal void PermissionCallbacks_PermissionDeniedAndDontAskAgain(string permissionName)
    // {
    //     Debug.Log("Permission Denied And Dont Ask Again: " + permissionName);
    //     DontAskAgain = true;

    //     if (StatusText != null)
    //     {
    //         UpdateUI(false);
    //     }
    // }
}
