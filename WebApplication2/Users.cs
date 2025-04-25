using System.Threading.Tasks;

namespace WebApplication2
{
    public class Users { 
    public Users ()
        {}
    public Users(string login, string password)
        {

        }
    public Users(Guid id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
        public Guid id { get; set; }
        public string login { get; set; } = null!;
        public string password { get; set; } = null!;

        public static async Task<Users> Create(Guid id, string login, string password)
        {
            
            return new Users(id, login, password);
        }
    }
}
