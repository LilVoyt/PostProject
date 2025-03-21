using PostProject.DataAcces.Entities;

namespace PostProject.Application.Security.Jwt
{
    public interface IJwtHandler
    {
        string Handle(Client client);
    }
}