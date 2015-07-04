using System;

using Xamarin.Forms;

namespace AnimationSample
{
	public class MultiAnimationPage : ContentPage
	{
		public MultiAnimationPage()
		{
			#region アニメーション用のボックスの生成
			// 移動値算出用のボックスを生成
			var boxViewBackground = new BoxView
			{
				Color = Color.Transparent,
			};

			// 全面アニメーション用のボックスを生成
			var boxViewFront = new BoxView
			{
				Color = Color.Blue,
			};

			// 背面アニメーション用のボックスを生成
			var boxViewBack = new BoxView
			{
				Color = Color.Red,
			};
			#endregion

			#region アニメーション制御用のボタン類の設定
			// 移動アニメーション制御用のボタンを生成
			var buttonMove = new Button
			{
				Text = "Animation",
			};
			// ボタン押し時の挙動
			buttonMove.Clicked += (sender, e) => 
			{
				var box = boxViewBackground;
				// 下降アニメーション用のレクタングル
				var moveDownRect = new Rectangle(0, box.Y + box.Height, box.Width, box.Height);
				// 上昇アニメーション用のレクタングル
				var moveUpRect = new Rectangle(0, box.Y, box.Width, box.Height);

				if (boxViewFront.Y == boxViewBackground.Y)
				{
					// 現在のレイアウトから指定のレイアウトにアニメーションさせる
					// ここではRectangleのサイズを変更していないので、単なる下方への移動アニメーション
					boxViewFront.LayoutTo(moveDownRect);
				}
				else
				{
					// 現在のレイアウトから指定のレイアウトに、指定時間かけてボックスをアニメーションさせる
					// ここではRectangleのサイズを変更していないので、単なる上方への移動アニメーション
					boxViewFront.LayoutTo(moveUpRect, 1000);
				}
			};

			// 拡大縮小アニメ制御用のボタンを生成
			var buttonScale = new Button
			{
				Text = "Scale",
			};
			// ボタン押し時の挙動
			buttonScale.Clicked += (sender, e) => 
			{
				if (boxViewFront.Scale == 1)
				{
					// ボックスのスケールが1だった場合
					// 指定秒かけてScaleを0にする
					boxViewFront.ScaleTo(0, 500);
				}
				else
				{
					// ボックスのスケールが0だった場合
					// 指定秒かけてScaleを1にする
					boxViewFront.ScaleTo(1, 1000);
				}
			};

			// 回転アニメ制御用のボタンを生成
			var buttonRelRotate = new Button
			{
				Text = "RelRotate",
			};
			// ボタン押し時の挙動
			buttonRelRotate.Clicked += (sender, e) => 
			{
				// ボタンが押されるたびにボックスを30度ずつ回転させる
				boxViewFront.RelRotateTo(30, 500);
			};				
			#endregion

			#region レイアウト関連
			// ボタン用のレイアウト
			var stack = new StackLayout
			{
				Children = 
				{
					buttonMove,
					buttonScale,
					buttonRelRotate,
				},
			};

			// ページ全体のレイアウト用のグリッドを生成
			var grid = new Grid
			{
				// 画面縦いっぱいに表示する
				VerticalOptions = LayoutOptions.FillAndExpand,

				RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				},
			};
			// グリッドにパーツを設定
			grid.Children.Add(stack, 0, 0);
			grid.Children.Add(boxViewBackground, 0, 1);
			grid.Children.Add(boxViewBack, 0, 1);
			grid.Children.Add(boxViewFront, 0, 1);

			// ページのコンテントにグリッドを設定
			Content = grid;
			#endregion
		}
	}
}


