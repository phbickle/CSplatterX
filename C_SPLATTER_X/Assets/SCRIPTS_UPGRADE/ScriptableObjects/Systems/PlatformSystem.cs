using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform System", menuName = "Systems/PlatformSystem", order = 1)]
public class PlatformSystem : ScriptableObject
{
    public List<PlatformDetails> details;

    public EnumValue defaultPlatformType;

    public void SetPlatformMaterial(GameObject obj)
    {
        PlatformBehavior beh = obj.GetComponent<PlatformBehavior>();
        if(null == beh)
        {
            return;
        }

        MeshRenderer rend = obj.GetComponent<MeshRenderer>();
        if(null == rend)
        {
            return;
        }

        Collider2D col = obj.GetComponent<Collider2D>();
        if(null == col)
        {
            return;
        }

        int index = Random.Range(0, details.Count);
        var newMat = details[index].typeMaterial;
        var newPhysMat = details[index].physicMaterial;
        if(null == newMat)
        {
            return;
        }

        rend.material = newMat;
        col.sharedMaterial = newPhysMat;
    }
}
