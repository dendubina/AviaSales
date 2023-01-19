namespace AviaSales.Infrastructure.Services.Options;

internal class EmailOptions
{
    public string Host { get; set; }

    public ushort Port { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FromName { get; set; }
}