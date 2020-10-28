using Terraria;
using Terraria.ModLoader;

namespace FractalaMod
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers, additions to knockback and crit, and our custom resource that governs the usage of the weapons of this damage class.
	public class TraperPlayer : ModPlayer
	{
		public static TraperPlayer ModPlayer(Player player) {
			return player.GetModPlayer<TraperPlayer>();
		}

		// Vanilla only really has damage multipliers in code
		// And crit and knockback is usually just added to
		// As a modder, you could make separate variables for multipliers and simple addition bonuses
		public float TraperDamageAdd;
		public float TraperDamageMult = 1f;
		public float TraperKnockback;
		public int TraperCrit;

		

	

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
			TraperDamageAdd = 0f;
			TraperDamageMult = 1f;
			TraperKnockback = 0f;
			TraperCrit = 0;
			
		}
		
		}
	}

