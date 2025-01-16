using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public GameObject hitEffectPrefab; // ������ЧԤ�Ƽ�

    void OnCollisionEnter(Collision collision)
    {
        // �����ײ�����Ƿ����ӵ�
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // ���ɻ�����Ч
            if (hitEffectPrefab != null)
            {
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            }

            // ����Ŀ������
            Destroy(gameObject);

            // �����ӵ�
            Destroy(collision.gameObject);
        }
    }
}
