using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace LevelEditor
{
	public class LevelBuilder
	{
		Tile[] level;
		Texture2D cursor;
		Texture2D tex;
		MouseState mouseState;
		Vector2 cursorPos;
		bool pressed;
		int current;

		public LevelBuilder(Texture2D tex)
		{
			level=new Tile[64];
			cursorPos=new Vector2((mouseState.X/32)*32,(mouseState.Y/32)*32);
			pressed=false;
			this.tex=tex;

			for(int i=0;i<level.Length;i++)
			{
				level[i]=null;
			}
		}

		public void update()
		{
			mouseState=Mouse.GetState();
			cursorPos=new Vector2((mouseState.X/32)*32,(mouseState.Y/32)*32);
			if (!pressed)
			{
				if (mouseState.LeftButton==ButtonState.Pressed)
				{
					pressed=true;
					placeObj();
				}
			}

			if (mouseState.LeftButton==ButtonState.Released)
				pressed=false;
		}

		public void placeObj()
		{
			if (!checkPos(cursorPos))
			{
				if (current>=level.Length)
				{
					Tile[] temp=new Tile[level.Length+32];
					level.CopyTo(temp,0);
					level=temp;
				}

				level[current++]=new Tile(tex,cursorPos);
			}
		}

		public bool checkPos(Vector2 pos)
		{
			for(int i=0;i<level.Length;i++)
			{
				if (level[i]!=null)
				{
					if (level[i].pos==pos)
					{
						return(true);
					}
				}
			}
			return(false);
		}

		public void loadContent(ContentManager cManager)
		{
			cursor = cManager.Load<Texture2D>("cursor");
			for(int i=0;i<level.Length;i++)
			{
				if (level[i]!=null)
				{
					level[i].loadContent(cManager);
				}
				else
				return;
			}
		}

		public void draw(SpriteBatch sBatch)
		{
			for(int i=0;i<level.Length;i++)
			{
				if (level[i]!=null)
				{
					level[i].draw(sBatch);
				}
				else
				break;
			}
			sBatch.Draw(cursor, cursorPos, Color.White);
		}
	}
}