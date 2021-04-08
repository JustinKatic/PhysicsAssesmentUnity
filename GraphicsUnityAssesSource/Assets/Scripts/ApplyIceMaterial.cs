using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************************************************************************
 *Name: Justin Katic
 *Date Created: Thurs April 1 2021
 *Description: Changes material to a new material keeping a refrence to the starting material so can change between the two.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/

public class ApplyIceMaterial : MonoBehaviour
{
    SkinnedMeshRenderer m_jointsMeshRenderer;
    SkinnedMeshRenderer m_surfaceMeshRenderer;

    Material m_jointsDefaultMat;
    Material m_surfaceDefaultMat;

    public GameObject m_jointsMesh;
    public GameObject m_surfaceMesh;

    public Material m_iceMat;

    public BoolVariable m_isSnowActive;

    bool iceEnabled = false;


    private void Start()
    {
        m_jointsMeshRenderer = m_jointsMesh.GetComponent<SkinnedMeshRenderer>();
        m_surfaceMeshRenderer = m_surfaceMesh.GetComponent<SkinnedMeshRenderer>();

        m_jointsDefaultMat = m_jointsMeshRenderer.material;
        m_surfaceDefaultMat = m_surfaceMeshRenderer.material;
    }
    private void OnDisable()
    {
        m_jointsMeshRenderer.material = m_jointsDefaultMat;
        m_surfaceMeshRenderer.material = m_surfaceDefaultMat;
    }

    private void Update()
    {
        if (m_isSnowActive.RuntimeValue)
        {
            TurnOnIce();
            iceEnabled = true;
        }
        else
        {
            TurnOffice();
            iceEnabled = false;
        }
    }

    public void TurnOnIce()
    {
        if (iceEnabled == false)
        {
            m_jointsMeshRenderer.material = m_iceMat;
            m_surfaceMeshRenderer.material = m_iceMat;
        }
    }

    public void TurnOffice()
    {
        if (iceEnabled == true)
        {
            m_jointsMeshRenderer.material = m_jointsDefaultMat;
            m_surfaceMeshRenderer.material = m_surfaceDefaultMat;
        }
    }
}
