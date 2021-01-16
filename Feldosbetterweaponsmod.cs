using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
namespace Feldosbetterweaponsmod
{
	public class Feldosbetterweaponsmod : Mod
	{
		public override void Load()
		{
			if (!Main.dedServ) // do not run this code on the server
			{
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/misc/covidbinus"), ItemType("Covidbinus"), TileType("Covidbinus"));
			}
		}
		public override void Unload()
		{
		}
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil bows", new int[]
			{
				ItemID.DemonBow,
				ItemID.TendonBow
			});
			RecipeGroup.RegisterGroup("Feldosbetterweaponsmod:Evilbows", group);
		}
	}
}