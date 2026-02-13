using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRScreenshot : MonoBehaviour
{
    public Button screenshotButton;

    private void Start()
    {
        if (screenshotButton != null)
        {
            screenshotButton.onClick.AddListener(TakeScreenshot);
        }
    }

    private void TakeScreenshot()
    {
        StartCoroutine(TakeScreenshotCoroutine());
        DestroyTextManager.Instance.DestroyText.gameObject.SetActive(false);        
    }

    private IEnumerator TakeScreenshotCoroutine()
    {
        // Wait until the end of the frame when all graphics updates have been made
        yield return new WaitForEndOfFrame();

        // Get the main camera and create a new RenderTexture
        Camera mainCamera = Camera.main;
        RenderTexture renderTex = new RenderTexture(Screen.width, Screen.height, 24);
        mainCamera.targetTexture = renderTex;

        // Render the camera's view to the target texture
        mainCamera.Render();

        // Create a new texture and read the active RenderTexture into it
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTex;
        screenshotTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshotTexture.Apply();

        // Reset the camera and RenderTexture
        mainCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTex);

        // Save the screenshot to the user's gallery
        var appName = Application.productName;
        var sceneName = SceneManager.GetActiveScene().name;
        var fileName = $"{appName}_{sceneName}_{System.DateTime.Now:yy_MM_dd-HH_mm_ss}";
        var imageUrl = VRAndroidExtensions.SaveImageToGallery(screenshotTexture, fileName, "Screenshot from " + appName);
        Debug.Log("Screenshot saved: " + imageUrl);

    }

}

public class VRAndroidExtensions
{
    private static AndroidJavaObject _activity;

    private static AndroidJavaObject Activity
    {
        get
        {
            if (_activity != null) return _activity;
            var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            return _activity;
        }
    }

    private const string MediaStoreImagesMediaClass = "android.provider.MediaStore$Images$Media";

    public static string SaveImageToGallery(Texture2D texture2D, string title, string description)
    {
        using var mediaClass = new AndroidJavaClass(MediaStoreImagesMediaClass);
        using var cr = Activity.Call<AndroidJavaObject>("getContentResolver");
        var image = Texture2DToAndroidBitmap(texture2D);
        var imageUrl = mediaClass.CallStatic<string>("insertImage", cr, image, title, description);
        Debug.Log("Screenshot saved: " + imageUrl);
        return imageUrl;
    }

    private static AndroidJavaObject Texture2DToAndroidBitmap(Texture2D texture2D)
    {
        var encoded = texture2D.EncodeToPNG();
        using var bf = new AndroidJavaClass("android.graphics.BitmapFactory");
        return bf.CallStatic<AndroidJavaObject>("decodeByteArray", encoded, 0, encoded.Length);
    }
}
