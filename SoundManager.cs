using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;


namespace fourcolors
{
    class SoundManager
    {
        ContentManager content;
        public SoundEffect phaser;
        public SoundEffect electro;
        public SoundEffect explode;
        //public Song song1;

        private static SoundManager instance;

        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SoundManager();
                return instance;
            }
        }

        public void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            phaser = content.Load<SoundEffect>("Sound/phaser");
            electro = content.Load<SoundEffect>("Sound/DST_ElectroRock");
            explode = content.Load<SoundEffect>("Sound/missileexplode");
        }

        public void PlayPhaser(){ phaser.Play(); }

        public void PlayMusic(){ electro.Play(); }

        public void Playexplode(){ explode.Play(); }
    }
}
