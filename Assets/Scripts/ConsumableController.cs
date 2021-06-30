using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour
{
    CharacterStat stats;

    private void Start()
    {
        stats = GetComponent<CharacterStat>();
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/"+item.ObjectSlug));
        if (item.ItemModifier)
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        else
            itemToSpawn.GetComponent<IConsumable>().Consume();
    }
}
