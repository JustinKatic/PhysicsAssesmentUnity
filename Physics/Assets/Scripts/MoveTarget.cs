/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: moves a target obj the player is looking at used for giving player a obj to look at asif its aiming
 *towards somthing with its animations
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public GameObject m_target;

    public float m_checkDistance = 100f;
    public float m_lerpTime;
    public RaycastHit m_hit;

    Vector3 m_oldTargetPos;

    Camera m_cam;

    private void Start()
    {
        m_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        m_oldTargetPos = m_target.transform.position;

        Ray ray = m_cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out m_hit, m_checkDistance))
        {
            m_target.transform.position = Vector3.Lerp(m_oldTargetPos, m_hit.point, m_lerpTime * Time.deltaTime);
        }

        else
        {
            Physics.Raycast(ray, m_checkDistance);
            m_target.transform.position = Vector3.Lerp(m_oldTargetPos, ray.GetPoint(m_checkDistance), m_lerpTime * Time.deltaTime);
        }
    }
}
