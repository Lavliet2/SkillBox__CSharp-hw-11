namespace Homework_10
{
    public static class AccessMode
    {
        public static bool IsConsultantMode { get; private set; }

        public static void SetConsultantMode(bool isConsultantMode)
        {
            IsConsultantMode = isConsultantMode;
        }
    }
}
