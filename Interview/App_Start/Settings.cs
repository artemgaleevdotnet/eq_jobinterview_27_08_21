namespace Interview.App_Start
{
    using Interview.DomainModel;

    internal class Settings : ISettings
    {
        public string Path { get; set; }
    }
}