using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace testmod4.Content.Tiles
{
    public class AlloyStationTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // --- 基本設定 ---
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            // --- 3x5マスの詳細設定 ---
            TileObjectData.newTile.Width = 3;  // 横3マス
            TileObjectData.newTile.Height = 5; // 縦5マス

            // 各マスの高さ（16px）を指定。5マス分あるので5回書く
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;   // 各マスの幅
            TileObjectData.newTile.CoordinatePadding = 2; // 隙間の2px

            // 設置時にマウスで掴む位置（1, 4 なら下段中央）
            TileObjectData.newTile.Origin = new Point16(1, 4);

            // 地面の条件（平らな場所が必要かなど）
            TileObjectData.newTile.AnchorBottom = new AnchorData(Terraria.Enums.AnchorType.SolidTile | Terraria.Enums.AnchorType.SolidWithTop | Terraria.Enums.AnchorType.Table, TileObjectData.newTile.Width, 0);

            TileObjectData.addTile(Type);

            // --- アニメーション設定 (例: 4フレーム) ---
            Main.tileFrameCounter[Type] = 4;

            // マップ表示の色と名前
            AddMapEntry(new Color(255, 215, 0), CreateMapEntryName()); // 金色っぽい色

            // 作業台としての機能（WorkBenchesの代わりにFurnacesなども可）
            AdjTiles = new int[] { TileID.WorkBenches };
        }

        // アニメーションの速度設定
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            // 15チック（約0.25秒）ごとに1フレーム進む
            if (++frameCounter >= 6)
            {
                frameCounter = 0;
                frame++;
                if (frame >= 4) // 4枚目の次は0に戻る
                {
                    frame = 0;
                }
            }
        }

        // アニメーションを正しく描画するための計算
        // 縦に長いタイルの場合、この設定がないと表示がバグることがあります
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            // 1フレームの高さ = (16+2) * 5マス = 90px
            // これをアニメーションの現在の枚数分だけズラす
            frameYOffset = Main.tileFrame[type] * 90;
        }
    }
}
