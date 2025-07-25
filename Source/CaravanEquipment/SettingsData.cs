using System.Collections.Generic;
using Verse;

namespace SquirtingElephant.CaravanEquipment;

public class SettingsData : ModSettings
{
    public readonly List<CaravanEquipmentSetting> Standard =
    [
        new("PortableHospitalBed", 12, 4f),
        new("PortableTable1x2c", 12, 1f),
        new("PortableDiningChair", 3, 0.1f),
        new("LA_WoodFiredGenerator", 5, 3f),
        new("CELA_Turret_MiniTurret", 8, 15f),
        new("PortableHeater", 7, 0.5f),
        new("PortableCooler", 7, 0.5f)
    ];

    public float PHospitalBed_BedRestEff = 1;
    public float PHospitalBed_ImmunityGainSpeedFactor = 1.11f;
    public float PHospitalBed_MedicalTendQualityOffset = 0.1f;
    public float PHospitalBed_SurgerySuccessChanceFactor = 1.1f;

    public int PPowerGenPowerGeneration = 725;

    public override void ExposeData()
    {
        Scribe_Values.Look(ref PHospitalBed_BedRestEff, "SECE_PHospitalBed_BedRestEff", 1f);
        Scribe_Values.Look(ref PHospitalBed_ImmunityGainSpeedFactor, "SECE_PHospitalBed_ImmunityGainSpeedFactor",
            1.11f);
        Scribe_Values.Look(ref PHospitalBed_MedicalTendQualityOffset, "SECE_PHospitalBed_MedicalTendQualityOffset",
            0.1f);
        Scribe_Values.Look(ref PHospitalBed_SurgerySuccessChanceFactor,
            "SECE_PHospitalBed_SurgerySuccessChanceFactor", 1.1f);

        Scribe_Values.Look(ref PPowerGenPowerGeneration, "SECE_PPowerGenPowerGeneration", PPowerGenPowerGeneration);

        Standard.ForEach(s => s.ExposeData());
    }
}