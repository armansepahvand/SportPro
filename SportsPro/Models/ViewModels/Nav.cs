namespace SportsPro.Models
{
    public static class Nav
    {
        ////View model for the active nav menu
        public static string Active(string value, string current) => 
            (value == current) ? "active" : "";
        public static string Active(int value, int current) =>
            (value == current) ? "active" : "";
    }
}
