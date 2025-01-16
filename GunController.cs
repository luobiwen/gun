
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // �ӵ�Ԥ�Ƽ�
    public Transform muzzlePoint;  // ǹ��λ��
    public float bulletSpeed = 20f;

    private AudioSource audioSource;  // ��Ч������
    private ParticleSystem muzzleFlash; // ����ϵͳ

    void Start()
    {
        // ��ȡ AudioSource �� ParticleSystem
        audioSource = GetComponent<AudioSource>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // ������
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // �����ӵ�
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = muzzlePoint.forward * bulletSpeed;

        // ������Ч
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // ����������Ч
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
    }
}
