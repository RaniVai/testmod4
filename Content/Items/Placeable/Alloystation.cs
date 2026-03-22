using Terraria.ID;
using Terraria.ModLoader;

namespace testmod4.Content.Items.Placeable
{
    public class Alloystation : ModItem
    {
        public override void SetDefaults()
        {
            // この一文で、先ほど作ったTileを設置するアイテムになります
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AlloyStationTile>());

            Item.width = 18;
            Item.height = 32;
            Item.value = 1500;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 10) // 鉄で作れるように仮設定
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
