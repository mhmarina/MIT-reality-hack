using UnityEngine;

public class CustomInteractable : MonoBehaviour
{
    public string key; // 对象的唯一标识符
    private MarineLifeManager manager; // 泡泡管理器

    public void Awake(){
        manager = FindObjectOfType<MarineLifeManager>();
    }

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
