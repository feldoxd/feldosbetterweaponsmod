using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
namespace Feldosbetterweaponsmod
{
	public class Feldosbetterweaponsmod : Mod
	{
		public override void Load()
		{
			if (!Main.dedServ) // do not run this code on the server
			{
				//AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/doometernal/MUSICdoometernalcultistbase"), ItemType("MUSICdoometernalcultistbase"), TileType("MUSICdoometernalcultistbase"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/misc/covidbinus"), ItemType("Covidbinus"), TileType("Covidbinus"));
			}
		}
	}
}