using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RaycastButtonInScene : MonoBehaviour
{
    public LayerMask _RaycastCollidableLayers;
    public float _CheckDistance = 100f;
    public RaycastHit _Hit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PerformRaycast();
        }
    }

    //Method
    void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _Hit, _CheckDistance, _RaycastCollidableLayers))
            _Hit.transform.GetComponent<Button>().onClick.Invoke();
    }
}
