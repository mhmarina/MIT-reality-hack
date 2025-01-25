using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class BatchProcessButtons : MonoBehaviour
{
    public float doubleClickThreshold = 0.3f; // 双击的最大时间间隔
    private Dictionary<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable, float> lastClickTimes = new Dictionary<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable, float>();

    private HashSet<Button> processedButtons = new HashSet<Button>(); // 记录已处理的按钮

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        ProcessAllButtons();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ProcessAllButtons();
    }

    void Update()
    {
        ProcessNewButtons();
        //ProcessAllButtons();
    }

    public void ProcessAllButtons()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            if (!processedButtons.Contains(button))
            {
                SetupButton(button);
            }
        }

        Debug.Log($"批量处理完成：找到 {buttons.Length} 个按钮！");
    }

    private void ProcessNewButtons()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            if (!processedButtons.Contains(button))
            {
                SetupButton(button);
            }
        }
    }

    private void SetupButton(Button button)
    {
        if (button.GetComponent<Collider>() == null)
        {
            var collider = button.gameObject.AddComponent<BoxCollider>();
            RectTransform rect = button.GetComponent<RectTransform>();
            collider.size = new Vector3(rect.rect.width, rect.rect.height, 1);
            collider.center = Vector3.zero;
        }

        XRInteractionManager interactionManager = FindObjectOfType<XRInteractionManager>();
        if (interactionManager == null)
        {
            Debug.LogError("未找到 XR Interaction Manager！");
            return;
        }

        UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable = button.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        if (interactable == null)
        {
            interactable = button.gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        }

        interactable.interactionManager = interactionManager;


            interactable.selectEntered.AddListener((interaction) => button.onClick.Invoke());
        

        processedButtons.Add(button); // 标记按钮为已处理
        Debug.Log($"按钮已处理：{button.name}");
    }

    private void HandleDoubleClick(UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable interactable, Button button)
    {
        float currentTime = Time.time;

        if (lastClickTimes.ContainsKey(interactable) && currentTime - lastClickTimes[interactable] <= doubleClickThreshold)
        {
            Debug.Log($"双击触发：{button.name}");
            button.onClick.Invoke();
            lastClickTimes[interactable] = -1f;
        }
        else
        {
            lastClickTimes[interactable] = currentTime;
        }
    }
}
