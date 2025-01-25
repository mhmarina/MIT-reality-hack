using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public GameObject prefabA; // Prefab A
    public GameObject prefabB; // Prefab B
    public GameObject prefabC; // Prefab C

    public Vector3 startPosition = new Vector3(0, 5, 0); // 初始位置
    public Vector3 targetPositionA = new Vector3(-5, 0, 0); // Prefab A 的目标位置
    public Vector3 targetPositionB = new Vector3(0, 0, 5); // Prefab B 的目标位置
    public Vector3 targetPositionC = new Vector3(5, 0, 0); // Prefab C 的目标位置

    public float floatSpeed = 1f; // 移动到目标位置的速度
    public float randomFloatRange = 0.5f; // 小范围随机浮动的范围
    public float randomFloatSpeed = 1f; // 小范围浮动的速度

    // 根据索引生成物体
    public void SpawnObject(int index)
    {
        GameObject prefabToSpawn = null;
        Vector3 targetPosition = Vector3.zero;

        // 根据索引选择生成的物体和目标位置
        switch (index)
        {
            case 0:
                prefabToSpawn = prefabA;
                targetPosition = targetPositionA;
                break;
            case 1:
                prefabToSpawn = prefabB;
                targetPosition = targetPositionB;
                break;
            case 2:
                prefabToSpawn = prefabC;
                targetPosition = targetPositionC;
                break;
        }

        if (prefabToSpawn != null)
        {
            // 生成物体
            GameObject instance = Instantiate(prefabToSpawn, startPosition, Quaternion.identity);

            // 添加浮动逻辑
            FloatingMovement floating = instance.AddComponent<FloatingMovement>();
            floating.targetPosition = targetPosition;
            floating.floatSpeed = floatSpeed;
            floating.randomFloatRange = randomFloatRange;
            floating.randomFloatSpeed = randomFloatSpeed;
        }
    }

    // 浮动逻辑
    private class FloatingMovement : MonoBehaviour
    {
        public Vector3 targetPosition; // 目标位置
        public float floatSpeed = 1f; // 移动速度
        public float randomFloatRange = 0.5f; // 小范围随机浮动的范围
        public float randomFloatSpeed = 1f; // 小范围浮动的速度

        private Vector3 offset; // 用于小范围浮动的偏移值
        private bool reachedTarget = false; // 标记是否到达目标位置
        private float randomOffsetX;
        private float randomOffsetY;
        private float randomOffsetZ;

        private void Start()
        {
            // 随机生成浮动的偏移值
            randomOffsetX = Random.Range(0f, Mathf.PI * 2f);
            randomOffsetY = Random.Range(0f, Mathf.PI * 2f);
            randomOffsetZ = Random.Range(0f, Mathf.PI * 2f);
        }

        private void FixedUpdate()
        {
            if (!reachedTarget)
            {
                // 平滑移动到目标位置
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, floatSpeed * Time.deltaTime);

                // 判断是否到达目标位置
                if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
                {
                    reachedTarget = true; // 设置为到达目标位置
                }
            }
            else
            {
                // 在目标位置附近随机浮动
                offset.x = Mathf.Sin(Time.time * randomFloatSpeed + randomOffsetX) * randomFloatRange;
                offset.y = Mathf.Cos(Time.time * randomFloatSpeed + randomOffsetY) * randomFloatRange;
                offset.z = Mathf.Sin(Time.time * randomFloatSpeed + randomOffsetZ) * randomFloatRange;

                transform.position = targetPosition + offset;
            }
        }
    }
}