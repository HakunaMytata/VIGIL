/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using System.Linq;

public class Inventory : MonoBehaviour
{

    private MenuDialog[] menuDialogs;
    private SayDialog[] sayDialogs;
    public CanvasGroup canvasGroup;
    //public Target target;

    public InventoryItem[] inventoryItems;
    public ItemSlot[] itemSlots;

    private Flowchart[] flowcharts;


    // Start is called before the first frame update
    void Start()
    {
        menuDialogs = FindObjectsOfType<MenuDialog>();
        sayDialogs = FindObjectsOfType<sayDialog>();
        canvasGroup = GetComponent<CanvasGroup>();
        //target = FindOBjectsOfType<Target>();
        flowcharts = FindObjectsOfType<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventory(!canvasGroup.interactable);
        }
    }

    private void ToggleInventory(bool setting)
    {
        ToggleCanvasGroup(canvasGroup, setting);
        InitializeItemSlots();

       /* if(!target.cutSceneInProgress)
        {
            target.inDialog = setting;
        }*/

      /*  foreach (MenuDialog menuDialog in menuDialogs)
        {
            JournalTools.ToggleCanvasGroup(menuDialog.GetComponent<CanvasGroup>(), !setting);
        }
        foreach (SayDialog sayDialog in sayDialogs)
        {
            sayDialog.dialogEnabled = !setting;
            if(setting) { Time.timeScale = 0f; } else { Time.timeScale = 1f; }
            JournalTools.ToggleCanvasGroup(sayDialog.GetComponent<CanvasGroup>(), !setting);
        }
        foreach (SayDialog sayDialog in sayDialogs)
        {
            sayDialog.dialogEnabled = !setting;
            if (setting) { Time.timeScale = 0f; } else { Time.timeScale = 1f; }
            JournalTools.ToggleCanvasGroup(sayDialog.GetComponent<CanvasGroup>(), !setting);
        }
    }

    public void InitializeItemSlots()
    {
        List<InventoryItem> ownedItem = GetOwnedItems(inventoryItems.ToList());
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < ownedItems.Count)
            {
                itemSlots[i].DisplayItem(ownedItems[i]);
            }
            else
            {
                itemSlots[i].ClearItem();
            }
        }
    }

    public List<InventoryItem> GetOwnedItems(List<InventoryItem> inventoryItems)
    {
        List<InventoryItem> ownedItems = new List<InventoryItem>();
        foreach (InvetoryItem item in inventoryItems)
        {

        }
    }


}
*/