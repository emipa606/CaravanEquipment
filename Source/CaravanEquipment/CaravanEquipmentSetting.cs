﻿using SquirtingElephant.Helpers;
using Verse;

namespace SquirtingElephant.CaravanEquipment;

public class CaravanEquipmentSetting : IExposable
{
    private ThingDef _ThisThingDef;
    private int AlloyCost = 1;

    private string DefName;
    private float Mass = 1f;

    public CaravanEquipmentSetting(string defName, int alloyCost, float mass)
    {
        DefName = defName;
        AlloyCost = alloyCost;
        Mass = mass;
    }

    private ThingDef ThisThingDef
    {
        get
        {
            if (_ThisThingDef == null)
            {
                _ThisThingDef = DefDatabase<ThingDef>.GetNamed(DefName);
            }

            return _ThisThingDef;
        }
        set => _ThisThingDef = value;
    }

    /// <summary>
    ///     Note: The forceSave being set to true is required because this class is used inside a generic list.
    /// </summary>
    public void ExposeData()
    {
        Scribe_Values.Look(ref DefName, DefName + "_ThingDef", DefName, true);
        Scribe_Values.Look(ref AlloyCost, DefName + "_AlloyCost", 1, true);
        Scribe_Values.Look(ref Mass, DefName + "_Mass", 1, true);
    }

    public void DoSettingsWindowContents(int rowIdx)
    {
        Widgets.ThingIcon(SE_Settings.Table.GetFieldRect(0, rowIdx), ThisThingDef);
        Widgets.Label(SE_Settings.Table.GetFieldRect(1, rowIdx), ThisThingDef.label);

        var bufferAlloyCost = AlloyCost.ToString();
        Widgets.TextFieldNumeric(SE_Settings.Table.GetFieldRect(2, rowIdx), ref AlloyCost, ref bufferAlloyCost, 1,
            1000);

        var bufferMass = Mass.ToString();
        Widgets.TextFieldNumeric(SE_Settings.Table.GetFieldRect(3, rowIdx), ref Mass, ref bufferMass, 1, 1000);

        SE_Settings.Table.ApplyMouseOverEntireRow(rowIdx);
        TooltipHandler.TipRegion(SE_Settings.Table.GetFieldRect(1, rowIdx), ThisThingDef.description);
    }

    public void ApplySettingsToDefs()
    {
        SE_Helper.SetThingAlloyCost(DefName, AlloyCost);
        Utils.SetThingStat(DefName, "Mass", Mass);
    }
}