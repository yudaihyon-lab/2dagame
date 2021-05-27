using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotGrid : MonoBehaviour
{
	[SerializeField]
	private GameObject slotPrefab;

	private int slotNunmber = 20;

    [SerializeField]
    private Item[] allItems;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slotNunmber; i++)
        {
        	GameObject slotObj = Instantiate(slotPrefab, this.transform);

        	Slot slot = slotObj.GetComponent<Slot>();

        	//スロットにアイテムをセットしたい
            if (i<allItems.Length)
            {
                 slot.SetItem(allItems[i]); 
            }
            else
            {
                slot.SetItem(null);
            }
 
        }
    }

}
