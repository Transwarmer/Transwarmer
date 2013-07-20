using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace Transwarmer
{

	public class InputController : Node
	{
		public enum CharacterState
		{
			None,
			Shrink,
			Stretch,
			Morph,
			Fly
		};

		// シーン遷移用
		private const int morph_counter = 50;
		private const int clear_counter = 200;

	    private static float charge_time_top = 0.0f;
	    private static float charge_time_bottom = 0.0f;
	    private static float positionX = 100.0f;
	    private static float positionY = 100.0f;
	    private static int	bestStep = 50;
	    private static CharacterState state = CharacterState.None;
	    private static int	button_counter = 0;
	    private static GamePadButtons pre_buttons;

		public void resetPosition(float posX, float posY, int goodStep)
		{
			positionX = posX;
			positionY = posY;
			bestStep = goodStep;
			charge_time_top = 0.0f;
			charge_time_bottom = 0.0f;
			state = CharacterState.None;
			button_counter = 0;

			pre_buttons = GamePad.GetData(0).Buttons;
		}

		public void updateInput()
		{
	        var gamePadData = GamePad.GetData(0);
			// メイン処理

			// 今回のフレームで押し込まれたボタンの数をカウント(スタート/セレクトは除く)
			foreach (GamePadButtons item in Enum.GetValues(typeof(GamePadButtons))) {
				if(item.ToString() != "Enter" && item.ToString() != "Back" &&
						item.ToString() != "Start" && item.ToString() != "Select"){
					if(((gamePadData.Buttons & item) != 0) && ((pre_buttons & item) == 0))
						button_counter++;
				}
        	}
			// 連続して押されたボタンの数が一定数を超えたら状態遷移
			if(button_counter > clear_counter){
				state = CharacterState.Fly;
			}
        	else if(button_counter > morph_counter){
        		state = CharacterState.Morph;
        	}
        	pre_buttons = gamePadData.Buttons;

			if(state != CharacterState.Morph && state != CharacterState.Fly){
				int now_counter = button_counter;
				button_counter = 0;
				if(gamePadData.AnalogRightX > 0.2){
					if(charge_time_top > 0){
						float charge_time = ((charge_time_top > charge_time_bottom) ? charge_time_top : charge_time_bottom);
						float stepX = ((charge_time > bestStep) ? bestStep : charge_time);
						stepX = stepX * stepX / bestStep;
						float stepY = FMath.Sin(FMath.Atan(gamePadData.AnalogRightY / gamePadData.AnalogRightX));

						positionX += stepX * 1.0f;
						positionY += stepY * 1.0f;
						charge_time_top = 0;
						charge_time_bottom = 0; // 一応上側優先で
						state = CharacterState.Stretch;
					}
				}
				else if(gamePadData.AnalogRightX < -0.3){
					state = CharacterState.Shrink;
					charge_time_top += 1.0f;
				}
				else if(gamePadData.AnalogLeftX > 0.3){
					if(charge_time_bottom > 0){
						float charge_time = ((charge_time_top > charge_time_bottom) ? charge_time_top : charge_time_bottom);
						float stepX = ((charge_time > bestStep) ? bestStep : charge_time);
						stepX = stepX * stepX / bestStep;
						float stepY = FMath.Sin(FMath.Atan(gamePadData.AnalogLeftY / gamePadData.AnalogLeftX));

						positionX += stepX * 1.0f;
						positionY += stepY * 1.0f;
						charge_time_bottom = 0;
						charge_time_top = 0; // 一応上側優先で
						state = CharacterState.Stretch;
					}
				}
				else if(gamePadData.AnalogLeftX < -0.2){
					state = CharacterState.Shrink;
					charge_time_bottom += 1.0f;
				}
				else{
					state = 0;
					button_counter = now_counter;
				}
			}
			else{
			}
		}

		public CharacterState getState()
		{
			return state;
		}

		public float getPosX()
		{
			return positionX;
		}
		public float getPosY()
		{
			return positionY;
		}

		public override void Update (float dt)
		{
			base.Update (dt);

			updateInput();
			Console.WriteLine("State:" + state + " Count:" + button_counter );
		}
	}
}
