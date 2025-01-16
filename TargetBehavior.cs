using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public GameObject hitEffectPrefab; // 击中特效预制件

    void OnCollisionEnter(Collision collision)
    {
        // 检查碰撞物体是否是子弹
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 生成击中特效
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            }

            // 销毁目标物体
            Destroy(gameObject);

            // 销毁子弹
            Destroy(collision.gameObject);
        }
    }
}
