namespace Balta.Domain.SharedContext;

public static class Configuration
{
    public static string Environment { get; set; } = string.Empty;
    public static SecurityConfiguration Security { get; set; } = new();
    public static DatabaseConfiguration Database { get; set; } = new();

    public class SecurityConfiguration
    {
        public string PasswordSaltKey { get; set; } = string.Empty;
        public short SaltSize { get; set; } = 16;
        public short KeySize { get; set; } = 32;
        public int Iterations { get; set; } = 1000;
        public char SplitChar { get; set; } = '.';
    }
    
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
}