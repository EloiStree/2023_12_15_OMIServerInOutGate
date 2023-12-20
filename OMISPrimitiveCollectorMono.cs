using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class OMISPrimitiveCollectorMono : MonoBehaviour, I_GetPrimitiveArrayToPush
{
    public char m_uniqueCharId=',';
    public Dictionary<string, bool> m_registerBool = new Dictionary<string, bool>();
    public Dictionary<string, float> m_registerFloat = new Dictionary<string, float>();
    public Dictionary<string, Vector3> m_registerVector3 = new Dictionary<string, Vector3>();
    public Dictionary<string, Quaternion> m_registerQuaternion = new Dictionary<string, Quaternion>();

    public UnityEvent m_namedInDictionaryChanged;
    public UnityEvent m_booleanChanged;

    public void GetArray(out bool[] values, out string[] namedId)
    {
        namedId = m_registerBool.Keys.ToArray();
        values = m_registerBool.Values.ToArray();
    }

    public void GetArray(out float[] values, out string[] namedId)
    {
        namedId = m_registerFloat.Keys.ToArray();
        values = m_registerFloat.Values.ToArray();
    }

    public void GetArray(out Vector3[] values, out string[] namedId)
    {
        namedId = m_registerVector3.Keys.ToArray();
        values = m_registerVector3.Values.ToArray();
    }

    public void GetArray(out Quaternion[] values, out string[] namedId)
    {
        namedId = m_registerQuaternion.Keys.ToArray();
        values = m_registerQuaternion.Values.ToArray();
    }

    public char GetUniqueCharId()
    {
        return m_uniqueCharId;
    }

    public void Push(string name, bool value)
    {
        if (!m_registerBool.ContainsKey(name))
        {
            NotifyNameChanged();
            m_registerBool.Add(name, value);
        }
        else m_registerBool[name] = value;
        m_booleanChanged.Invoke();
    }
    public void Push(string name, float value)
    {
        if (!m_registerFloat.ContainsKey(name))
        {
            NotifyNameChanged();
            m_registerFloat.Add(name, value);
        }
        else m_registerFloat[name] = value;
    }
    public void Push(string name, Vector3 value)
    {
        if (!m_registerVector3.ContainsKey(name))
        {
            NotifyNameChanged();
            m_registerVector3.Add(name, value);
        }
        else m_registerVector3[name] = value;
    }
    public void Push(string name, Quaternion value)
    {
        if (!m_registerQuaternion.ContainsKey(name))
        {
            NotifyNameChanged();
            m_registerQuaternion.Add(name, value);
        }
        else m_registerQuaternion[name] = value;
    }

    private void NotifyNameChanged()
    {
        m_namedInDictionaryChanged.Invoke();
    }
}
