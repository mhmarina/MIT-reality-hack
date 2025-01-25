using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneChangerXR : MonoBehaviour
{
    public string targetSceneName = "YourSceneName"; // Replace with your scene name

    // Called when the object is selected
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
