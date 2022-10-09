using SquirtingElephant.Helpers;
using Verse;

namespace SquirtingElephant.CaravanEquipment;

public static class SE_Helper
{
    public static void SetThingAlloyCost(string thingDefName, int newAlloyCost)
    {
        var thingDef = Utils.GetDefByDefName<ThingDef>(thingDefName);

        var costDef =
            thingDef?.costList.FirstOrDefault(c => c.thingDef == DefDatabase<ThingDef>.GetNamed("LightAlloy"));
        if (costDef != null)
        {
            costDef.count = newAlloyCost;
        }
    }
}