using System.Data;

namespace api_veterinaria.src.shared.Interface
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
