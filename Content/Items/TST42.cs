using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace testmod4.Content.Items // あなたのMOD名.フォルダ名
{
    // TutorialSwordという名前のアイテムを定義します（ModItemクラスを継承）
    public class TST42 : ModItem
    {
        // アイテムの基本的な名前や説明を設定する場所
        public override void SetStaticDefaults()
        {
            // ゲーム内で表示される名前（日本語OK）
            // DisplayName.SetDefault("チュートリアルソード"); // 旧Verの書き方
            // 1.4以降は言語ファイル(.hjson)推奨ですが、最初はコード内に書いても動きます。
        }

        // アイテムの性能（攻撃力、速さ、見た目など）を設定する場所
        public override void SetDefaults()
        {
            // --- 見た目とサイズ ---
            Item.width = 40;  // 剣の画像の横幅（ピクセル）
            Item.height = 40; // 剣の画像の縦幅（ピクセル）
            Item.rare = ItemRarityID.Green; // レア度（緑色）
            Item.value = Item.sellPrice(silver: 50); // 店での売却価格

            // --- 攻撃性能 ---
            Item.damage = 25;       // 攻撃力
            Item.DamageType = DamageClass.Melee; // ダメージの種類（近接）
            Item.knockBack = 6f;    // 敵を吹き飛ばす力

            // --- 振る動作 ---
            Item.useTime = 20;      // 攻撃の速さ（数字が小さいほど速い。フレーム単位）
            Item.useAnimation = 20; // 振るアニメーションの長さ（通常はuseTimeと同じにする）
            Item.useStyle = ItemUseStyleID.Swing; // 振るスタイル（1: 剣を振る）
            Item.useTurn = true;    // 振っている最中に方向転換できるか

            // --- 音と光 ---
            Item.UseSound = SoundID.Item1; // 振った時の音（シャキーン）
        }

        // --- レシピの追加（木材10個でクラフト可能にする） ---
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10) // 材料：木材10個
                .AddTile(TileID.WorkBenches)   // 作業台：ワークベンチ
                .Register();                   // 登録
        }
    }
}