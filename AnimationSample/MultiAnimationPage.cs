using System;

using Xamarin.Forms;

namespace AnimationSample
{
	public class MultiAnimationPage : ContentPage
	{
		public MultiAnimationPage()
		{
			// 移動値算出用のボックスを生成
			var boxViewBackground = new BoxView
			{
				Color = Color.Transparent,
			};

			// 全面アニメーション用のボックスを生成
			var boxViewFront = new BoxView
			{
				Color = Color.Blue,
				IsVisible = false,
			};

			// 背面アニメーション用のボックスを生成
			var boxViewBack = new BoxView
			{
				Color = Color.Red,
			};

			// アニメーション開始用のボタンを生成
			var button = new Button
			{
				Text = "Animation",
			};

			// ボタン押し時の挙動
			button.Clicked += (sender, e) => 
			{
				var box = boxViewBackground;
				// 下降アニメーション用のレクタングル
				var moveDownRect = new Rectangle(0, box.Y + box.Height, box.Width, box.Height);
				// 上昇アニメーション用のレクタングル
				var moveUpRect = new Rectangle(0, box.Y, box.Width, box.Height);
				boxViewFront.IsVisible = true;

				if (boxViewFront.Y == boxViewBackground.Y)
				{
					// 現在地から指定位置までボックスをアニメーションさせる
					boxViewFront.LayoutTo(moveDownRect);
				}
				else
				{
					// 現在地から指定位置まで、指定時間かけてボックスをアニメーションさせる
					boxViewFront.LayoutTo(moveUpRect, 1000);
				}
			};

			// レイアウト用のグリッドを生成
			var grid = new Grid
			{
				// 画面縦いっぱいに表示する
				VerticalOptions = LayoutOptions.FillAndExpand,

				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				},
			};
			// グリッドにパーツを設定
			grid.Children.Add(button, 0, 0);
			grid.Children.Add(boxViewBackground, 0, 1);
			grid.Children.Add(boxViewBack, 0, 1);
			grid.Children.Add(boxViewFront, 0, 1);

			// ページのコンテントにグリッドを設定
			Content = grid;
		}
	}
}


