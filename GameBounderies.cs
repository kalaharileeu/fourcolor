
namespace fourcolors
{
    class GameBounderies
    {
        public int CameraXmax { get; } = 580;
        public int CameraXmin { get; } = 0;
        public int CameraYmax { get; } = 480;
        public int CameraYmin { get; } = 0;

        private static GameBounderies instance;

        public static GameBounderies Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameBounderies();
                return instance;
            }
        }
    }
}
