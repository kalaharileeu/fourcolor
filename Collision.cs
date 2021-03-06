﻿using Microsoft.Xna.Framework;

namespace fourcolors
{
    /// <summary>
    /// This is called from collsion manager to check if the rectangle collide
    /// </summary>
    public class Collision
    {

        const int s_buffer = 15;//use to be 4. Up to increase collision sensitivity

        public static bool RectRect(Rectangle A, Rectangle B)
        {
            int aHBuf = A.Height / s_buffer;
            int aWBuf = A.Width / s_buffer;

            int bHBuf = B.Height / s_buffer;
            int bWBuf = B.Width / s_buffer;

            // if the bottom of A is less than the top of B - no collision
              if ((A.Y + A.Height) - aHBuf <= B.Y + bHBuf) { return false; }

            // if the top of A is more than the bottom of B = no collision
            if (A.Y + aHBuf >= (B.Y + B.Height) - bHBuf) { return false; }

            // if the right of A is less than the left of B - no collision
            if ((A.X + A.Width) - aWBuf <= B.X + bWBuf) { return false; }

            // if the left of A is more than the right of B - no collision
            if (A.X + aWBuf >= (B.X + B.Width) - bWBuf) { return false; }

            // otherwise there has been a collision
            return true;
        }
    }
}
