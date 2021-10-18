using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    public void SimpleRaycast()
    {
        MultipleRaycastScript.instance.selectedRaycast = "SimpleRaycast";
    }
    public void OppositeRaycast()
    {
        MultipleRaycastScript.instance.selectedRaycast = "OppositeRaycast";
    }
    public void RaycastAll()
    {
        MultipleRaycastScript.instance.selectedRaycast = "RaycastAll";
    }
}
