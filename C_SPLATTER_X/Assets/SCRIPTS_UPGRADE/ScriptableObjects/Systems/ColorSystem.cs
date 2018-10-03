using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform System", menuName = "Systems/PlatformSystem", order = 1)]
public class ColorSystem : ScriptableObject
{
    public List<ColorDetails> details;

    public ColorDetails currentColorType;

    public IntegerVariable colorIndex;
    public void SetGameColor(GameObject obj)
    {
        ColorBehavior beh = obj.GetComponent<ColorBehavior>();
        if(null == beh)
        {
            return;
        }

        Camera cam = obj.GetComponent<Camera>();
        if(null == cam)
        {
            return;
        }

        currentColorType = details[colorIndex.value];

        cam.backgroundColor = currentColorType.curreColor;

    }

    public void SetMeshRenderer(GameObject obj)
    {
        PlatformBehavior beh = obj.GetComponent<PlatformBehavior>();
        if(null == beh)
        {
            return;
        }

        MeshRenderer rend = obj.GetComponent<MeshRenderer>();
        if (rend == null)
        {
            return;
        }

        currentColorType = details[colorIndex.value];

        rend.enabled = currentColorType.canSeeFloor;
    }
}
