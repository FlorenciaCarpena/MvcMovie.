using LoginMVCClase.Models;

namespace LoginMVCClase.BaseDeDatosFicticia
{
    public class FakeUserDB
    {
        public static List<LoginModel> Users = new List<LoginModel>
        {
            new LoginModel
            {
                Id = 1,
                User="admin",
                Password="12345"
             },
            new LoginModel
            {
                Id=2,
                User="admin",
                Password="1234"
            }
        };
    }
}
