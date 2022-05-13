namespace zeaploy.Helpers
{
    public static class Locations 
    {
        // All locations
        public const string Copenhagen = "Copenhagen";
        public const string Valby = "Valby";
        public const string Roskilde = "Roskilde";
        public const string Helsigor = "Helsingør";
        public const string Horsholm = "Hørsholm";
        public const string Nastved = "Næstved";
        public const string Koge = "Køge";
        public const string Taastrup = "Taastrup";
        public const string Slagelse = "Slagelse";
        public const string Hillerod = "Hillerød";
        public const string Holbaek = "Holbæk";
        public const string Remote = "From home / Remote";

        // Locations that are displayed
        public static readonly ICollection<string> locations = new string[] {
            Copenhagen,
            Valby,
            Roskilde,
            Helsigor,
            Horsholm,
            Nastved,
            Koge,
            Taastrup,
            Slagelse,
            Hillerod,
            Holbaek,
            Remote,
        };
    }
}
