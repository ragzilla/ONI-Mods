﻿using CaiLib.Utils;
using Harmony;
using static CaiLib.Logger.Logger;
using static CaiLib.Utils.BuildingUtils;
using static CaiLib.Utils.GameStrings;

namespace SteelLadder
{
	public static class SteelLadderPatches
	{
		public static class Mod_OnLoad
		{
			public static void OnLoad()
			{
				LogInit(ModInfo.Name, ModInfo.Version);
			}
		}

		[HarmonyPatch(typeof(GeneratedBuildings))]
		[HarmonyPatch(nameof(GeneratedBuildings.LoadGeneratedBuildings))]
		public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
		{
			public static void Prefix()
			{
				StringUtils.AddBuildingStrings(SteelLadderConfig.Id, SteelLadderConfig.DisplayName, SteelLadderConfig.Description, SteelLadderConfig.Effect);
				AddBuildingToPlanScreen(PlanMenuCategory.Base, SteelLadderConfig.Id, LadderFastConfig.ID);
			}
		}

		[HarmonyPatch(typeof(Db))]
		[HarmonyPatch(nameof(Db.Initialize))]
		public static class Db_Initialize_Patch
		{
			public static void Prefix()
			{
				AddBuildingToTechnology(GameStrings.Technology.Decor.HomeLuxuries, SteelLadderConfig.Id);
			}
		}
	}
}