using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class MarineLifeManager : MonoBehaviour
{
    [System.Serializable]
    public class MarineLife
    {
        public string key;
        public string name;
        public string origin;
        public string type;
        public string threats;
    }

    [System.Serializable]
    public class MarineLifeData
    {
        public List<MarineLife> marine_life;
    }

    public string jsonFileName = "marine_life.json"; // JSON 文件名
    public TextMeshProUGUI bubbleText; // 显示的文字
    public Dictionary<string, MarineLife> marineLifeDict;

    void Awake()
    {
        LoadMarineLifeData();
    }

    // 加载 JSON 数据
    void LoadMarineLifeData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            MarineLifeData data = JsonUtility.FromJson<MarineLifeData>(jsonContent);
            marineLifeDict = new Dictionary<string, MarineLife>();

            foreach (var life in data.marine_life)
            {
                marineLifeDict[life.key] = life;
            }

            Debug.Log($"JSON 数据加载成功，共加载 {marineLifeDict.Count} 条记录！");
        }
        else
        {
            Debug.LogError("JSON 文件未找到！");
        }
    }

    // 显示信息到泡泡
    public void DisplayInfo(string key)
    {
        if(marineLifeDict == null){
            Debug.Log($"Object {key} not found");
        }
        else{
            if (marineLifeDict.TryGetValue(key, out MarineLife life))
            {
                bubbleText.text = $"Name: {life.name}\n" +
                                $"Origin: {life.origin}\n" +
                                $"Type: {life.type}\n" +
                                $"Threats: {life.threats}";
            }
                else
            {
                Debug.LogError($"未找到键 {key} 对应的数据！");
            }
        }
    }
}
