using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{


    public Transform target; // Hedef obje
    public float hookSpeed = 10f; // Grappling hook h�z�
    public float orbitSpeed = 5f; // D�n�� h�z�
    public float maxHookLength = 10f; // Maksimum hook uzunlu�u
    public LineRenderer lineRenderer; // Line Renderer bile�eni
    private bool isHooked = false; // Grappling hook ba�l� m�?
    private Quaternion initialRotation; // �lk ba�lang�� rotasyonu
    private Vector3 hookStartPosition; // Hookun ba�lang�� pozisyonu

    private void Start()
    {
        // �lk ba�lang�� rotasyonunu kaydet
        initialRotation = transform.rotation;

        // Hookun ba�lang�� pozisyonunu kaydet
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
            // Hedef objeyi ana obje etraf�nda d�nd�r
            Vector3 rotationAxis = Vector3.down;

            if (gameObject.CompareTag("LeftTag")) // Sol tagine sahipse
            {
                rotationAxis = Vector3.up;
            }

            target.transform.RotateAround(transform.position, rotationAxis, orbitSpeed * Time.deltaTime);

            // Ana objenin de kendisi etraf�nda d�nmesini sa�la
            transform.rotation = initialRotation * Quaternion.Euler(0f, orbitSpeed * Time.deltaTime, 0f);

            // Hook uzunlu�unu kontrol et ve s�n�rla
        
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