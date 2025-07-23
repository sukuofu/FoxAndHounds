using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static GameObject InstantiateObjectByName(string name)
    {
        var obj = Resources.Load($"Prefabs/{name}") as GameObject;
        var instance = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
        instance.name = instance.name.Replace("(Clone)", "");
        return instance;
    }
}
