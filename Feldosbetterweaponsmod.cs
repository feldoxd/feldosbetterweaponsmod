using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace Feldosbetterweaponsmod
{
	public class Feldosbetterweaponsmod : Mod
	{
        [Obsolete]
        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil bows", new int[]
			{
				ItemID.DemonBow,
				ItemID.TendonBow
			});
			RecipeGroup.RegisterGroup("Feldosbetterweaponsmod:Evilbows", group);
		}

		public static void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
	}



	public class Recipes : ModSystem
    {

	}

}