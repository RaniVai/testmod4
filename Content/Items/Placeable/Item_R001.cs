using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace testmod4.Content.Items.Placeable
{
    public class Item_R001 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 59; // Influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.

            // The Chlorophyte Extractinator can exchange items. Here we tell it to allow a one-way exchanging of 5 ExampleBar for 2 ChlorophyteBar.
            ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 5, ItemID.ChlorophyteBar, 2);
        }

        public override void SetDefaults()
        {
            // ModContent.TileType returns the ID of the tile that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the tile provided to it through its generic type argument (the type in angle brackets)
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Item_R001>());
            Item.width = 20;
            Item.height = 20;
            Item.value = 750; // The cost of the item in copper coins. (1 = 1 copper, 100 = 1 silver, 1000 = 1 gold, 10000 = 1 platinum)
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()

        {
            // 新しいレシピを作成します（このアイテムを1個作る設定）
            Recipe recipe = CreateRecipe();

            // 【材料1】金鉱石（Gold Ore）を5個
            recipe.AddIngredient(ItemID.GoldOre, 5);

            // 【材料2】プラチナ鉱石（Platinum Ore）を5個
            recipe.AddIngredient(ItemID.PlatinumOre, 5);

            // 【場所】かまど（Furnace）のそばで作成可能にする
            recipe.AddTile(TileID.Furnaces);

            // このレシピをゲームに登録して完成！
            recipe.Register();
        }
    }
}
