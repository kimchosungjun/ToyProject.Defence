using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public GameObject go;
    public abstract void InteractionObject();
    public virtual void SendObjectInfo(GameObject _go) { go = _go; InteractionObject(); }
}
