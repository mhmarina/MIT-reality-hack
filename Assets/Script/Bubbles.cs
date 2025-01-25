﻿using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public GameObject prefabA; // Prefab A
    public GameObject prefabB; // Prefab B
    public GameObject prefabC; // Prefab C

    public Vector3 startPosition; // 初始位置，可以在 Inspector 中设置
    public float floatSpeedA = 1f; // Prefab A 的上升速度
    public float floatSpeedB = 1.5f; // Prefab B 的上升速度
    public float floatSpeedC = 2f; // Prefab C 的上升速度
    public float destroyHeight = 10f; // 到达此高度后销毁

    // 根据索引生成物体
    public void SpawnObject(int index)
    {
        GameObject prefabToSpawn = null;
        float floatSpeed = 0f;

        // 根据索引选择生成的物体和对应的上升速度
        switch (index)
        {
            case 0:
                prefabToSpawn = prefabA;
                floatSpeed = floatSpeedA;
                break;
            case 1:
                prefabToSpawn = prefabB;
                floatSpeed = floatSpeedB;
                break;
            case 2:
                prefabToSpawn = prefabC;
                floatSpeed = floatSpeedC;
                break;
        }

        if (prefabToSpawn != null)
        {
            // 生成物体
            GameObject instance = Instantiate(prefabToSpawn, startPosition, Quaternion.identity);

            // 添加缓慢上升逻辑
            FloatingUpward floatingLogic = instance.AddComponent<FloatingUpward>();
            floatingLogic.floatSpeed = floatSpeed;
            floatingLogic.destroyHeight = destroyHeight;
        }
    }

    // 缓慢上升逻辑
    private class FloatingUpward : MonoBehaviour
    {
        public float floatSpeed = 1f; // 上升速度
        public float destroyHeight = 10f; // 销毁高度

        private Rigidbody rb;

        private void Start()
        {
            // 确保物体有 Rigidbody
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }

            // 设置 Rigidbody 为 Kinematic
            rb.isKinematic = true;

            // 确保物体初始角度固定
            transform.rotation = Quaternion.identity;
        }

        private void FixedUpdate()
        {
            // 锁定物体的旋转
            transform.rotation = Quaternion.identity;

            // 缓慢向上移动
            transform.position += Vector3.up * floatSpeed * Time.deltaTime;

            // 检查是否到达销毁高度
            if (transform.position.y >= destroyHeight)
            {
                Destroy(gameObject);
            }
        }
    }
}
