using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : Interaction
{
    public override void InteractionObject()
    {
        Tile tile = go.GetComponent<Tile>();
        if (tile == null)
        {
            Debug.Log("Ÿ���� ���ƴ�");
            return;
        }
    }

}
