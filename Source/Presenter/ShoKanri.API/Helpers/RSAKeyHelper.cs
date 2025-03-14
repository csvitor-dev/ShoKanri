using System.Security.Cryptography;

namespace ShoKanri.API.Helpers;

internal static class RSAKeyHelper
{
    private static readonly RSA _private;
    private static readonly RSA _public;

    static RSAKeyHelper()
    {
        _private = RSA.Create(2048);
        _public = RSA.Create();

        _public.ImportParameters(_private.ExportParameters(includePrivateParameters: false));
    }

    internal static RSA PublicKey => _public;
    internal static RSA PrivateKey => _private;
}