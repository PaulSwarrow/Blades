using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class CharacterInteractionController
{

    //settings:
    public float distance;

    //vars:
    private LayerMask mask;
//    private InteractionTarget currentTarget;

    internal void init()
    {
    }

    internal void Use()
    {
//        if(currentTarget)
//        {
//            currentTarget.Trigger();
//        }
    }


    internal void Draw()
    {
//        List< InteractionTarget> list = InteractionTarget.activeTargets;
//        InteractionTarget target;
//        bool canInteract;
//        for (int i = 0; i < list.Count; i++)
//        {
//            target = list[i];
//            if (target && target.IsVisible(Camera.main))
//            {
//                canInteract = target.IsInteractable(Camera.main);
//                DrawInteractable(target, canInteract);
//                currentTarget = canInteract ? target : null;
//            }
//        }

    }

    //Logic:
   /* private void DrawInteractable(InteractionTarget target, bool highlight)
    {
        Camera cam = Camera.main;
        Vector3 pivot = target.Pivot.position;
        GUIStyle style = target.LabelStyle;
        if (highlight)
        {
            style.normal.textColor = Color.yellow;
            style.fontSize = 35;
        }
        else
        {
            style.normal.textColor = Color.white;
            style.fontSize = 25;
        }
        Vector3 point = cam.WorldToViewportPoint(pivot);

        bool onScreen = point.z > 0 && point.x > 0 && point.x < 1 && point.y > 0 && point.y < 1;
        if (onScreen)
        {
            GUI.TextField(new Rect(Screen.width * point.x, Screen.height * (1 - point.y), 0, 0), target.Label, style);
        }
    }*/

}
