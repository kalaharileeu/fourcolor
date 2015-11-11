Ways to load a new explosion:
-set up a xml file with parameters, see Content/GamePlay/Smallexplosion.xml
-Create Loader.Parameter in GameplayScreen.cs
-populate Loader.Parameter with xml serializer in GamplayScreen.cs
--Send it to BulletHandler.Instance. with Addloaderparameters

Collision detection
---Tile and Player.
Tile hanldes its own collision with Collsion.RectRect(). Tiles have "Passive" and "Solid" states, "Passive"
can not collide but "Solid" can
Tile should probably not handle its own collision. But I will leave it for now.
A player reference is sent to tile to the collsion detection, the tile.cs then set the dyingtiles to true

---Enemy Player and Player bullet collision
This is handled by the collision manager, with Collsion.RectRect() function.

Movement and scroll
---Tile (Environment)
Tiles do not move but they scroll, with a certian scroll speed. So the Update function check for collision
and the scroll function do the movement or scroll.