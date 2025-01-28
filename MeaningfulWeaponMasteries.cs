namespace MeaningfulWeaponMasteries
{
    using BepInEx;
    using HarmonyLib;
    using EFT.InventoryLogic;
    using EFT;

    [BepInPlugin(GUID, NAME, VERSION)]
    public class MeaningfulWeaponMasteries : BaseUnityPlugin
    {
        public const string GUID = "com.ehaugw.meaningfulweaponmasteries";
        public const string VERSION = "1.0.0";
        public const string NAME = "Meaningful Weapon Masteries";

        internal void Awake()
        {
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(SkillManager), "GetWeaponInfo")]
        public class SkillManager_GetWeaponInfo
        {
            [HarmonyPostfix]
            public static void Postfix(SkillManager __instance, ref SkillManager.GClass1981 __result, Item weapon)
            {
                int mastering = __instance?.GetMastering(weapon.TemplateId)?.Level ?? 0;
                //__result.DeltaErgonomics += 0.05f * mastering;
                __result.AimSpeed += 0.05f * mastering;
                __result.ReloadSpeed += 0.05f * mastering;
                __result.FixSpeed += 0.05f * mastering;
            }
        }

        //[HarmonyPatch(typeof(Weapon), "ErgonomicsDelta", MethodType.Getter)]
        //public class Weapon_ErgonomicsDelta
        //{
        //    [HarmonyPostfix]
        //    public static void Postfix(Weapon __instance, ref float __result)
        //    {
        //        __result += 0.2f;
        //    }
        //}
    }
}
