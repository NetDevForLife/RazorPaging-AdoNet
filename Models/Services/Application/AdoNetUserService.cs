using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RazorPagingAdoNet.Models.Services.Infrastructure;
using RazorPagingAdoNet.Models.ViewModels;

namespace RazorPagingAdoNet.Models.Services.Application
{
    public class AdoNetUserService : IUserService
    {
        private readonly ILogger<AdoNetUserService> logger;
        private readonly IDatabaseAccessor db;
        public AdoNetUserService(ILogger<AdoNetUserService> logger, IDatabaseAccessor db)
        {
            this.logger = logger;
            this.db = db;
        }

        public async Task<ListViewModel<UserViewModel>> GetUsersAsync()
        {
            FormattableString query = $@"SELECT Id, Cognome, Nome, Email FROM Utenti ORDER BY Id DESC;";
            DataSet dataSet = await db.QueryAsync(query);
            DataTable dataTable = dataSet.Tables[0];
            List<UserViewModel> userList = new ();
            foreach (DataRow userRow in dataTable.Rows)
            {
                UserViewModel userViewModel = UserViewModel.FromDataRow(userRow);
                userList.Add(userViewModel);
            }

            ListViewModel<UserViewModel> result = new ()
            {
                Results = userList,
            };

            return result;
        }
    }
}