using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player_ItemDrop : Test_Base
{
    private void Start()
    {
        Player player = GameManager.Inst.Player;

        player.Test_AddItem(ItemCode.Ruby, 3);
        player.Test_AddItem(ItemCode.Emerald, 8);
        player.Test_AddItem(ItemCode.Sapphire, 3);
    }
}
