using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Inventory : Test_Base
{
    Inventory inventory;

    private void Start()
    {
        inventory = new Inventory(6);
    }

    protected override void Test1(InputAction.CallbackContext _)
    {
        inventory.AddItem(ItemCode.Ruby);
    }

    protected override void Test2(InputAction.CallbackContext _)
    {
        inventory.AddItem(ItemCode.Emerald, 5);
    }

    protected override void Test3(InputAction.CallbackContext _)
    {
        inventory.AddItem(ItemCode.Sapphire);
    }

    protected override void Test4(InputAction.CallbackContext _)
    {
        inventory.PrintInventory();
    }
}
