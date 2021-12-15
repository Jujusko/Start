namespace Start
{
    public class AllData
    {
        private static AllData instance;
        public User user;

        private AllData()
        {
            user = new("null");
        }

        public static AllData GetInstance()
        {
            if (instance == null)
                instance = new AllData();
            return instance;
        }
    }
}
