Ways to load a new explosion:
-set up a xml file with parameters, see Content/GamePlay/Smallexplosion.xml
-Create Loader.Parameter in GameplayScreen.cs
-populate Loader.Parameter with xml serializer in GamplayScreen.cs
--Send it to BulletHandler.Instance. with Addloaderparameters
//***************************************Collsion**********************************************
Collision detection
---Tile and Player.
Tile hanldes its own collision with Collsion.RectRect(). Tiles have "Passive" and "Solid" states, "Passive"
can not collide but "Solid" can
Tile should probably not handle its own collision. But I will leave it for now.
A player reference is sent to tile to the collsion detection, the tile.cs then set the dyingtiles to true

Add Collsion to bullets or player//enemies
The Collsionmanage.Instance has the player position logged, it can also get all the bullet positions from 
form the BulletHandle.Instance in a list, it the usses the the Collision(Rect, Rect) function to check for collsions
true/false. 

---Enemy Player and Player bullet collision
This is handled by the collision manager, with Collsion.RectRect() function.
//**************************************Collision ENd******************************************
Movement and scroll
---Tile (Environment)
Tiles do not move but they scroll, with a certian scroll speed. So the Update function check for collision
and the scroll function do the movement or scroll.

Player behaviour
-player imartalit
The plyer need some hysteresis between dying - responing - dying. The are situation where this can happen too quick
in succession. Some immortality need to be in the proces to give a time delay betwwen responing - immortality(few seconds) - dying
- the player bullets needs to be limited, else it is too easy. Only 4 - 5 bullets allow at any one time in the bullet list

The ScoreManager
-The ScoreManager is a singleton class where plyars the mostly the collision functionality will register the score.
Incremment or decrement functions to add/ subtrack from the score
-ScoreManager should also increment and decrement lives.

GameGadget and EnemyGadget inherit from GameObject(Abstract)
-Both inherit from GameObject, subclasses instantiated by map.cs, xml deserialization
-Score uses a special oveloaded Image draw function, because it is a multi image sprite but 
the sprite is not animated by spritesheet effect. It is animated as the score ticks over.
So it is manual animation effect. Pretty happy with this outcome.
Lives will also use this overloaded draw function from Image class
All GameGadget that give info will probable be done by this manual animation effect.

Add Collsion to bullets or player//enemies
The Collsionmanage.Instance has the player position logged, it can also get all the bullet positions from 
form the BulletHandle.Instance in a list, it the usses the the Collision(Rect, Rect) function to check for collsions
true/false. 

The collsionmanager

What to do next.
-implement score/ lives
-Soundeffects for enemies to be sorted out
-bullet for intruder
-implement offscreen boundaries for player
-implement power for Boss, take multiple hits and bullets for boss
-implement multiple level game screens

