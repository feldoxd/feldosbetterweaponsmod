	using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Feldosbetterweaponsmod.Items.Weapons
{
	public class UpgradedChainGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Upgraded chain gun");
			Tooltip.SetDefault("'It costs $400 000 dollars to fire this weapon for 12 seconds'\n58% chance to not consume ammo");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 52;
			item.height = 32;
			item.useTime = 4;
			item.useAnimation = 2;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = Item.sellPrice(gold: 23);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item40;
			item.autoReuse = true;
			item.shoot = ProjectileID.PurificationPowder;
			item.shootSpeed = 24f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.FragmentVortex, 20);
			recipe.AddIngredient(ItemID.ChainGun);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .58f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2, 0);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 5f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.VortexBeaterRocket, damage, knockBack, player.whoAmI);
			return true;
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if (target.type >= NPCID.MoonLordCore || NPCID.MoonLordHand >= target.type || target.type >= NPCID.MoonLordHead)
				{
					damage -= 18;
				}
		}
	}
}