using UnityEngine;

public class FloatSeaAnimals : MonoBehaviour
{
    public GameObject prefabA; // Prefab A (Recyclable)

    public int spawnCount = 5; // Number of prefabs to spawn
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // Spawn area size
    public Vector3 startPosition = Vector3.zero; // Starting position

    public float floatRange = 1f; // Floating range
    public float floatSpeed = 2f; // Floating speed

    void Start()
    {
        // Instantiate the specified number of prefabs
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnPrefabA();
        }
    }

    // Spawn only prefabA
    private void SpawnPrefabA()
    {
        Vector3 randomPosition = startPosition + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(0f, 360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f)
        );

        GameObject instance = Instantiate(prefabA, randomPosition, randomRotation);

        // Add floating behavior
        FloatingObjects floating = instance.AddComponent<FloatingObjects>();
        floating.floatRange = floatRange;
        floating.floatSpeed = floatSpeed;

        // Add interaction logic
        instance.AddComponent<ObjectInteraction>();
    }

    // Nested FloatingObject class (改为左右浮动)
    private class FloatingObjects : MonoBehaviour
    {
        public float floatRange = 1f;
        public float floatSpeed = 2f;

        private Vector3 startPosition;
        private float randomOffset;
        private Rigidbody rb;

        void Start()
        {
            startPosition = transform.position;
            randomOffset = Random.Range(0f, 1f * Mathf.PI);

            // 添加或获取 Rigidbody 组件
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }
            rb.isKinematic = true; // 设置为 Kinematic，防止受物理力影响
        }

        void FixedUpdate()
        {
            // 计算左右浮动的偏移量
            float offsetX = Mathf.Sin(Time.time * floatSpeed + randomOffset) * floatRange;

            // 计算目标位置
            Vector3 targetPosition = startPosition + new Vector3(offsetX, 0, 0);

            // 使用 Rigidbody.MovePosition 移动物体
            rb.MovePosition(targetPosition);
        }
    }
}
