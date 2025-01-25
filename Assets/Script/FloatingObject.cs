using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    // 外部变量控制浮动的幅度和速度
    public float floatRange = 1f; // 浮动幅度
    public float floatSpeed = 2f; // 浮动速度

    // 是否启用多方向浮动
    public bool enableMultiDirection = true;

    // 单独控制每个轴的浮动幅度
    public Vector3 floatAxisRange = new Vector3(1f, 1f, 1f); // X, Y, Z 轴的浮动范围

    // 随机性参数
    private float randomOffsetX;
    private float randomOffsetY;
    private float randomOffsetZ;

    private Vector3 startPosition; // 初始位置

    void Start()
    {
        // 记录初始位置
        startPosition = transform.position;

        // 为每个轴生成随机初始相位
        randomOffsetX = Random.Range(0f, 2f * Mathf.PI);
        randomOffsetY = Random.Range(0f, 2f * Mathf.PI);
        randomOffsetZ = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // 根据是否启用多方向浮动计算位置偏移
        Vector3 offset = Vector3.zero;

        if (enableMultiDirection)
        {
            // 多方向浮动（X, Y, Z）
            offset.x = Mathf.Sin(Time.time * floatSpeed + randomOffsetX) * floatAxisRange.x;
            offset.y = Mathf.Sin(Time.time * floatSpeed + randomOffsetY) * floatAxisRange.y;
            offset.z = Mathf.Sin(Time.time * floatSpeed + randomOffsetZ) * floatAxisRange.z;
        }
        else
        {
            // 仅 Y 轴浮动
            offset.y = Mathf.Sin(Time.time * floatSpeed + randomOffsetY) * floatRange;
        }

        // 更新对象位置
        transform.position = startPosition + offset;
    }
}
