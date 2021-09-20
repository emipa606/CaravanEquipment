using SquirtingElephant.Helpers;
using UnityEngine;
using Verse;

namespace SquirtingElephant.CaravanEquipment
{
    public class SE_Settings : Mod
    {
        private const float SCROLL_AREA_OFFSET_TOP = 200f;
        public static SettingsData Settings;

        public static TableData Table = new TableData(new Vector2(10f, 0f), new Vector2(10f, 10f),
            new[] { 32f, 225f, 110f, 110f }, new[] { 32f }, 4, 8);

        // Scrolling:
        private Vector2 ScrollPosition = Vector2.zero;
        private Rect ViewRect = new Rect(0f, 0f, 100.0f, 200.0f);

        public SE_Settings(ModContentPack content) : base(content)
        {
            Settings = GetSettings<SettingsData>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var ls = new Listing_Standard();
            ls.Begin(inRect);

            Utils.MakeTextFieldNumericLabeled(ls, "SECE_PPowerGenAmount", ref Settings.PPowerGenPowerGeneration, 1,
                100000);
            ls.Gap(24f);

            AddLA_HospitalBedSettings(ls);
            ls.GapLine();

            BeginScrollView(ref ls,
                new Rect(0, SCROLL_AREA_OFFSET_TOP, inRect.width, inRect.height - SCROLL_AREA_OFFSET_TOP),
                ref ScrollPosition, ref ViewRect);

            CreateHeaders();
            for (var i = 0; i < Settings.Standard.Count; i++)
            {
                Settings.Standard[i].DoSettingsWindowContents(i + 1);
            }

            EndScrollView(ref ls, ref ViewRect, inRect.width, ls.CurHeight);
            ls.End();

            Main.ApplySettingsToDefs();
        }

        private static void CreateHeaders()
        {
            Widgets.Label(Table.GetHeaderRect(1), "SECE_ItemName".Translate().CapitalizeFirst());
            Widgets.Label(Table.GetHeaderRect(2), "SECE_AlloyCost".Translate().CapitalizeFirst());
            Widgets.Label(Table.GetHeaderRect(3), "SECE_Mass".Translate().CapitalizeFirst());
        }

        private static void AddLA_HospitalBedSettings(Listing_Standard ls)
        {
            ls.Label("SECE_LAHospitalBedStats".Translate().CapitalizeFirst());
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_BedRestEff", ref Settings.PHospitalBed_BedRestEff, 0.1f, 10f);
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_ImmunityGainSpeedFactor",
                ref Settings.PHospitalBed_ImmunityGainSpeedFactor, 0.1f, 10f);
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_MedicalTendQualityOffset",
                ref Settings.PHospitalBed_MedicalTendQualityOffset, 0.1f, 10f);
            Utils.MakeTextFieldNumericLabeled(ls, "SECE_SurgerySuccessChanceFactor",
                ref Settings.PHospitalBed_SurgerySuccessChanceFactor, 0.1f, 10f);
        }

        private static void BeginScrollView(ref Listing_Standard listingStandard, Rect rect, ref Vector2 scrollPosition,
            ref Rect viewRect)
        {
            Widgets.BeginScrollView(rect, ref scrollPosition, viewRect);
            rect.height = 100000f;
            rect.width -= 20f;
            listingStandard.Begin(rect.AtZero());
        }

        private void EndScrollView(ref Listing_Standard listingStandard, ref Rect viewRect, float width, float height)
        {
            viewRect = new Rect(0f, 0f, width, height);
            Widgets.EndScrollView();
            listingStandard.End();
        }

        public override string SettingsCategory()
        {
            return "SECE_SettingsCategory".Translate();
        }
    }
}