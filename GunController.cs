
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹预制件
    public Transform muzzlePoint;  // 枪口位置
    public float bulletSpeed = 20f;

    private AudioSource audioSource;  // 音效播放器
    private ParticleSystem muzzleFlash; // 粒子系统

    void Start()
    {
        // 获取 AudioSource 和 ParticleSystem
        audioSource = GetComponent<AudioSource>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // 鼠标左键
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 发射子弹
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = muzzlePoint.forward * bulletSpeed;

        // 播放音效
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // 触发火焰特效
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
    }
}
