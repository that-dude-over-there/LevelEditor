using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LevelEditor
{
	public class Tile
	{
		public Texture2D tex;
		public Vector2 pos;
		public string asset;

		public Tile(Texture2D tex,Vector2 pos)
		{
			this.tex=tex;
			this.pos=pos;
		}

		public void loadContent(ContentManager cManager)
		{
			tex=cManager.Load<Texture2D>(asset);
		}
		
		public void draw(SpriteBatch sBatch)
		{				
			sBatch.Draw(tex,pos,Color.White);
		}
	}
}
