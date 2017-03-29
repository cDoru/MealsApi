using AutoMapper;

namespace MealsApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEncryptor
    {
        string Encrypt(string val);
        string Decrypt(string val);
    }
}