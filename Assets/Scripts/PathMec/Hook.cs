using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{


    public Transform target; // Hedef obje
    public float hookSpeed = 10f; // Grappling hook hýzý
    public float orbitSpeed = 5f; // Dönüþ hýzý
    public float maxHookLength = 10f; // Maksimum hook uzunluðu
    public LineRenderer lineRenderer; // Line Renderer bileþeni
    private bool isHooked = false; // Grappling hook baðlý mý?
    private Quaternion initialRotation; // Ýlk baþlangýç rotasyonu
    private Vector3 hookStartPosition; // Hookun baþlangýç pozisyonu

    private void Start()
    {
        // Ýlk baþlangýç rotasyonunu kaydet
        initialRotation = transform.rotation;

        // Hookun baþlangýç pozisyonunu kaydet
        hookStartPosition = target.position;
    }

    private void Update()
    {
        Vector3 hookDirection = target.position - transform.position;
        float hookLength = hookDirection.magnitude;
        if (Input.GetMouseButton(0) && hookLength <= maxHookLength)
        {
            OnHook();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OffHook();
        }

        if (isHooked)
        {
            // Hedef objeyi ana obje etrafýnda döndür
            Vector3 rotationAxis = Vector3.down;

            if (gameObject.CompareTag("LeftTag")) // Sol tagine sahipse
            {
                rotationAxis = Vector3.up;
            }

            target.transform.RotateAround(transform.position, rotationAxis, orbitSpeed * Time.deltaTime);

            // Ana objenin de kendisi etrafýnda dönmesini saðla
            transform.rotation = initialRotation * Quaternion.Euler(0f, orbitSpeed * Time.deltaTime, 0f);

            // Hook uzunluðunu kontrol et ve sýnýrla
        
            if (hookLength > maxHookLength)
            {
                hookDirection = hookDirection.normalized * maxHookLength;
                target.position = transform.position + hookDirection;
            }
        }
    }

    public void OnHook()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, target.position);
        lineRenderer.SetPosition(1, transform.position);
        isHooked = true;
    }

    public void OffHook()
    {
        lineRenderer.positionCount = 0;
        isHooked = false;
    }

  
   

 
 
}