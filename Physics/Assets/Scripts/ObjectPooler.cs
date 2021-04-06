/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: Allows for pulling objects instead of destroying objects allows just to set inactive objects to active.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public int m_amountToPool;
        public GameObject m_objectToPool;
        public bool m_shouldExpand = true;
    }

    public static ObjectPooler m_sharedInstance;

    private List<GameObject> m_pooledObjects;

    public List<ObjectPoolItem> m_itemsToPool;


    private void Awake()
    {
        m_sharedInstance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        m_pooledObjects = new List<GameObject>();

        foreach (ObjectPoolItem item in m_itemsToPool)
        {
            for (int i = 0; i < item.m_amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.m_objectToPool);
                obj.SetActive(false);
                m_pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < m_pooledObjects.Count; i++)
        {
            if (!m_pooledObjects[i].activeInHierarchy && m_pooledObjects[i].tag == tag)
            {
                return m_pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in m_itemsToPool)
        {
            if (item.m_objectToPool.tag == tag)
            {
                if (item.m_shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.m_objectToPool);
                    obj.SetActive(false);
                    m_pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}
