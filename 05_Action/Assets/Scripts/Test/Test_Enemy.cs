using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Enemy : Test_Base
{
    Player player;
    
    protected override void Test1(InputAction.CallbackContext _)
    {
        player = GameManager.Inst.Player;
        player.Test_AddItem(ItemCode.SilverSword);
        player.Inventory[0].EquipItem(player.gameObject);
    }

    protected override void Test2(InputAction.CallbackContext _)
    {
        Enemy enemy = FindObjectOfType<Enemy>();
        enemy.Die();
    }
}
