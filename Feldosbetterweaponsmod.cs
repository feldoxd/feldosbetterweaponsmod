using Terraria.ModLoader;
using Terraria;
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
	}
}