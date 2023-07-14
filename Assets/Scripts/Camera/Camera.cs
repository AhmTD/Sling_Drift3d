using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // Takip edilecek obje
    public float followSpeed = 5f; // Kamera takip hýzý

    private Vector3 offset; // Kamera ile obje arasýndaki mesafe

    private void Start()
    {
        // Kamera ile obje arasýndaki baþlangýç mesafesini kaydet
        offset = transform.position - target.position;
    }

    private void Update()
    {
        // Hedef konumunu al
        Vector3 targetPosition = target.position + offset;

        // Hedef konuma doðru hareket et
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(90f, target.transform.rotation.y, 0f);
    }
}
