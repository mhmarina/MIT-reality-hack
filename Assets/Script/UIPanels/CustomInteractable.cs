using UnityEngine;

public class CustomInteractable : MonoBehaviour
{
    public string key; // 对象的唯一标识符
    public MarineLifeManager manager; // 泡泡管理器

    public void OnInteract()
    {
        if (manager != null)
        {
            manager.DisplayInfo(key);
        }
        else
        {
            Debug.LogError("MarineLifeManager 未绑定到 CustomInteractable！");
        }
    }
}
