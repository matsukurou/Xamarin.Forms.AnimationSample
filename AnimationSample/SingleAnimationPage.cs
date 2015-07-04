using System;

using Xamarin.Forms;

namespace AnimationSample
{
	public class SingleAnimationPage : ContentPage
	{
		public SingleAnimationPage()
		{
			// アニメーション用のボックスを生成
			var boxView = new BoxView
			{
				Color = Color.Blue,
			};

			// アニメーション開始用のボタンを生成
			var button = new Button
			{
				Text = "Animation",
			};
			// ボタン押し時の挙動
			button.Clicked += (sender, e) => 
			{
				// 画面下までボックスをアニメーションさせる
				boxView.LayoutTo(new Rectangle(0, boxView.Y + boxView.Height, boxView.Width, boxView.Height));
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
			grid.Children.Add(boxView, 0, 1);

			// ページのコンテントにグリッドを設定
			Content = grid;
		}
	}
}


