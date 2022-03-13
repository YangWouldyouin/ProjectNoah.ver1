//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ItemActions : Actions
//{
//    [SerializeField] ItemDatabase itemDatabase;
//    [SerializeField] bool giveItem; // This will decide whether we are giveing or receiving the item
//    [SerializeField] int amount;
//    [SerializeField] Actions[] yesActions, noActions;

//    public int itemId;
//    // ���� ���� �������� �����, �������� �����Ϳ� ���ؼ� �÷��̾ �� �������� �ٰ����� �ƴ����� ����

//    [SerializeField] Item currentItem;
//    public Item CurrentItem { get { return currentItem; } }

//    public ItemDatabase ItemDatabase { get { return itemDatabase; } }

//    public void ChangeItem(Item item)
//    {
//        if (CurrentItem.ItemId == item.ItemId)
//            return; // ���� �������̹Ƿ� �ٲ� �ʿ� ����

//        if (itemDatabase != null) // If the itemDatabase is not empty
//            currentItem = Extensions.CopyItem(item);
//    }

//    public override void Act()
//    {
//        //check if giveItem is true, then give the item
//        if (giveItem) // -> we will give item from our Inventory
//        {
//            int itemOwned = DataManager.Instance.Inventory.CheckAmount(CurrentItem);

//            //check if we own the item
//            if (itemOwned > 0)
//            {
//                if (CurrentItem.AllowMultiple && amount <= itemOwned)
//                {
//                    //pass the item, invoke yesActions
//                    DataManager.Instance.Inventory.ModifyItemAmount(CurrentItem, amount, true);

//                    Extensions.RunActions(yesActions);
//                }
//                else if (!CurrentItem.AllowMultiple && itemOwned == 1)
//                {
//                    //remove the item from inventory, and then invoke yesActions
//                    DataManager.Instance.Inventory.ModifyItemAmount(CurrentItem, itemOwned, true); // itemOwned �� ������ 1��

//                    Extensions.RunActions(yesActions);
//                }
//                else
//                {
//                    //don't have the item
//                    Extensions.RunActions(noActions);
//                }
//            }
//        }
//        else // we receive the item
//        {
//            //else receive the item
//            if (CurrentItem.AllowMultiple)
//            {
//                DataManager.Instance.Inventory.ModifyItemAmount(CurrentItem, amount);
//                Extensions.RunActions(yesActions);
//            }
//            else if (!CurrentItem.AllowMultiple)
//            {
//                if (DataManager.Instance.Inventory.CheckAmount(CurrentItem) == 1)
//                {
//                    //already have
//                    Extensions.RunActions(noActions);
//                }
//                else
//                {
//                    DataManager.Instance.Inventory.ModifyItemAmount(CurrentItem, 1);
//                    Extensions.RunActions(yesActions);
//                }
//            }
//        }
//    }

//}

