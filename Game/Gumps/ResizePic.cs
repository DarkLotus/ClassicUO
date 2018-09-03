﻿using ClassicUO.Game.Renderer;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicUO.Game.Gumps
{
    public class ResizePic : GumpControl
    {
        private readonly SpriteTexture[] _gumpTexture = new SpriteTexture[9];
        private Graphic _graphic;

        public ResizePic() : base()
        {
            CanMove = true;
            CanCloseWithRightClick = true;
        }

        public ResizePic(in string[] parts)
        {
            X = int.Parse(parts[1]);
            Y = int.Parse(parts[2]);
            _graphic = Graphic.Parse(parts[3]);
            Width = int.Parse(parts[4]);
            Height = int.Parse(parts[5]);
        }


        public override void Update(in double frameMS)
        {
            if (_gumpTexture[0] == null)
            {
                for (int i = 0; i < _gumpTexture.Length; i++)
                {
                    _gumpTexture[i] = TextureManager.GetOrCreateGumpTexture((Graphic)(_graphic + i));
                }
            }

            base.Update(frameMS);
        }

        public override bool Draw(in SpriteBatch3D spriteBatch, in Vector3 position)
        {
            for (int i = 0; i < _gumpTexture.Length; i++)
            {
                _gumpTexture[i].Ticks = World.Ticks;
            }

            int centerWidth = Width - _gumpTexture[0].Width - _gumpTexture[2].Width;
            int centerHeight = Height - _gumpTexture[0].Height - _gumpTexture[6].Height;
            int line2Y = (int)position.Y + _gumpTexture[0].Height;
            int line3Y = (int)position.Y + Height - _gumpTexture[6].Height;
            // top row
            spriteBatch.Draw2D(_gumpTexture[0], new Vector3(position.X, position.Y, 0), Vector3.Zero);
            spriteBatch.Draw2DTiled(_gumpTexture[1], new Rectangle((int)position.X + _gumpTexture[0].Width, (int)position.Y, centerWidth, _gumpTexture[0].Height), Vector3.Zero);
            spriteBatch.Draw2D(_gumpTexture[2], new Vector3(position.X + Width - _gumpTexture[2].Width, position.Y, 0), Vector3.Zero);
            // middle
            spriteBatch.Draw2DTiled(_gumpTexture[3], new Rectangle((int)position.X, line2Y, _gumpTexture[3].Width, centerHeight), Vector3.Zero);
            spriteBatch.Draw2DTiled(_gumpTexture[4], new Rectangle((int)position.X + _gumpTexture[3].Width, line2Y, centerWidth, centerHeight), Vector3.Zero);
            spriteBatch.Draw2DTiled(_gumpTexture[5], new Rectangle((int)position.X + Width - _gumpTexture[5].Width, line2Y, _gumpTexture[5].Width, centerHeight), Vector3.Zero);
            // bottom
            spriteBatch.Draw2D(_gumpTexture[6], new Vector3(position.X, line3Y, 0), Vector3.Zero);
            spriteBatch.Draw2DTiled(_gumpTexture[7], new Rectangle((int)position.X + _gumpTexture[6].Width, line3Y, centerWidth, _gumpTexture[6].Height), Vector3.Zero);
            spriteBatch.Draw2D(_gumpTexture[8], new Vector3(position.X + Width - _gumpTexture[8].Width, line3Y, 0), Vector3.Zero);


            return base.Draw(spriteBatch, position);
        }
    }
}