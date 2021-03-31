using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public GameObject target;

    public float _CheckDistance = 100f;
    public float lerpTime;
    public RaycastHit _Hit;

    Vector3 oldTargetPos;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        oldTargetPos = target.transform.position;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _Hit, _CheckDistance))
        {
            target.transform.position = Vector3.Lerp(oldTargetPos, _Hit.point, lerpTime * Time.deltaTime);
        }

        else
        {
            Physics.Raycast(ray, _CheckDistance);
            target.transform.position = Vector3.Lerp(oldTargetPos, ray.GetPoint(_CheckDistance), lerpTime * Time.deltaTime);
        }
    }
}
