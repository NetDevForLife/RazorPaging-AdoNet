using System;
using System.Data;

namespace RazorPagingAdoNet.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static UserViewModel FromDataRow(DataRow courseRow)
        {
            var userViewModel = new UserViewModel {
                Cognome = Convert.ToString(courseRow["Cognome"]),
                Nome = Convert.ToString(courseRow["Nome"]),
                Email = Convert.ToString(courseRow["Email"]),
                Id = Convert.ToInt32(courseRow["Id"])
            };
            return userViewModel;
        }
    }
}