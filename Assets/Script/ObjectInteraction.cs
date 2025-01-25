using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Bubbles foams; // 引用 Foams，用于生成物体

    private int spawnIndex = 0; // 当前的生成计数（1-2-3 循环）

    private void OnTriggerEnter(Collider other)
    {
        // 检测触发的物体标签
        if (other.CompareTag("Recyclable"))
        {
            spawnIndex = (spawnIndex + 1) % 3; // 按顺序循环计数（0-1-2-0）
            foams.SpawnObject(spawnIndex); // 调用 Foams 的生成方法
            Destroy(other.gameObject); // 销毁放入垃圾桶的物体

            Debug.Log($"Spawned Object Index: {spawnIndex + 1}"); // 输出当前生成的物体索引
        }
    }
}
