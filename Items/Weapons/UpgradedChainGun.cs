using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class UpgradedChainGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vortex chain gun");
			// Tooltip.SetDefault("'It costs $400 000 dollars to fire this weapon for 12 seconds.'\n58% chance to not consume ammo");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 30; // Sets the Item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 52; // hitbox width of the Item
			Item.height = 32; // hitbox height of the Item
			Item.useTime = 4; // The Item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 4; // The length of the Item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // how you use the Item (swinging, holding out, etc)
			Item.noMelee = true; //so the Item's animation doesn't do damage
			Item.knockBack = 2; // Sets the Item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.value = Item.sellPrice(gold: 23);
			Item.rare = ItemRarityID.Cyan; // the color that the Item's name will be in-game
			Item.UseSound = SoundID.Item40; // The sound that this Item plays when used.
			Item.autoReuse = true; // if you can hold click to automatically use it again
			Item.shoot = ProjectileID.PurificationPowder; //idk why but all the guns in the vanilla source have this //ProjectileID.PurificationPowder
			Item.shootSpeed = 24f; // the speed of the projectile (measured in pixels per frame)
			Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo Item that this weapon uses. Note that this is not an Item Id, but just a magic value.
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.IllegalGunParts)
			.AddIngredient(ItemID.FragmentVortex, 20)
			.AddIngredient(ItemID.ChainGun)
			.AddIngredient(ItemID.VortexBeater)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}

		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= 0.58f;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));

			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 10f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity, ProjectileID.VortexBeaterRocket, damage, knockback + 6, default, 1, 1);
			return true;
		}

		public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
		{
			if (target.type >= NPCID.MoonLordCore || NPCID.MoonLordHand >= target.type || target.type >= NPCID.MoonLordHead)
			{
				modifiers.SourceDamage -= 20;
			}
		}
	}
}