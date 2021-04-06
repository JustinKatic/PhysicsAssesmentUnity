/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: changed material on object to invis shader mat and keeps refrence to default shader to change back too.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvis : MonoBehaviour
{
    SkinnedMeshRenderer m_jointsMeshRenderer;
    SkinnedMeshRenderer m_surfaceMeshRenderer;

    public GameObject m_jointsMesh;
    public GameObject m_surfaceMesh;

    Material m_jointsDefaultMat;
    Material m_surfaceDefaultMat;

    public Material m_invisMat;

    public float m_invisTime;

    public BoolVariable m_invisActive;


    private void Start()
    {
        m_jointsMeshRenderer = m_jointsMesh.GetComponent<SkinnedMeshRenderer>();
        m_surfaceMeshRenderer = m_surfaceMesh.GetComponent<SkinnedMeshRenderer>();

        m_jointsDefaultMat = m_jointsMeshRenderer.material;
        m_surfaceDefaultMat = m_surfaceMeshRenderer.material;

    }

    public void TurnOnInvis()
    {
        m_jointsMeshRenderer.material = m_invisMat;
        m_surfaceMeshRenderer.material = m_invisMat;
        m_invisActive.RuntimeValue = true;
        Invoke("TurnOffInvis", m_invisTime);
    }

    public void TurnOffInvis()
    {
        m_jointsMeshRenderer.material = m_jointsDefaultMat;
        m_surfaceMeshRenderer.material = m_surfaceDefaultMat;
        m_invisActive.RuntimeValue = false;
    }


}
