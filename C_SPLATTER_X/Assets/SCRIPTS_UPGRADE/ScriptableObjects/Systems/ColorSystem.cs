using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color System", menuName = "Systems/ColorSystem", order = 1)]
public class ColorSystem : ScriptableObject
{
#if UNITY_EDITOR
    public string DeveloperDescription = "";
#endif

    [Header("Colors available to play, can be extended")]
    public List<ColorDetails> details;

    [Header("Current color at play")]
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
