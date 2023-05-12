using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Minimap : Test_Base
{
    void Start()
    {
        ItemFactory.MakeItem(ItemCode.Ruby, 10);

        GameObject obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(5, 0, 0);
        obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(-5, 0, 0);
        obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(0, 0, 5);
        obj = ItemFactory.MakeItem(ItemCode.Emerald);
        obj.transform.position = new Vector3(0, 0, -5);


    }
}
