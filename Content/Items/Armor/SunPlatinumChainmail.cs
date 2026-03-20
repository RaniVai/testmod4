using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using testmod4.Content.Items.Placeable;

namespace testmod4.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class SunPlatinumChainmail : ModItem
    {

        public override void SetDefaults()
        {

            Item.defense = 8; // 防御力
            Item.value = 10000; // 売値 (1ゴールド)
            Item.rare = 2; // レア度
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Item_R001>(), 12);
            recipe.AddTile(TileID.Anvils); // レシピに必要な作業台（金床）
            recipe.Register();
        }
    }
}
