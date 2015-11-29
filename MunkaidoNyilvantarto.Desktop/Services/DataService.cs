using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkaidoNyilvantarto.ViewModels.Issue;
using MunkaidoNyilvantarto.ViewModels.SpentTime;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace MunkaidoNyilvantarto.Desktop.Services
{
    public class DataService
    {
        public async Task<ServiceResult> Login(string userName, string password)
        {
            var client = ClientManager.GetClient();
            var values = new NameValueCollection { { "Email", userName }, { "Password", password } };

            var response = await client.UploadValuesTaskAsync(new Uri("http://localhost:2179/Account/LoginToDesktop"), "POST", values);
            var result = JsonConvert.DeserializeObject<ServiceResult>(Encoding.UTF8.GetString(response));

            return result;
        }

        public async Task<ServiceResult<List<IssueListViewModel>>> GetIssuesForUser()
        {
            var client = ClientManager.GetClient();

            var response = await client.DownloadStringTaskAsync(new Uri("http://localhost:2179/Issue/GetIssuesByUser"));
            var result = JsonConvert.DeserializeObject<ServiceResult<List<IssueListViewModel>>>(response);

            return result;
        }

        public async Task<ServiceResult<List<SpentTimeDesktopListViewModel>>> GetSpentTimesForUser()
        {
            var client = ClientManager.GetClient();

            var response = await client.DownloadStringTaskAsync(new Uri("http://localhost:2179/SpentTime/GetActualMonthSpentTimesByUser"));
            var result = JsonConvert.DeserializeObject<ServiceResult<List<SpentTimeDesktopListViewModel>>>(response);

            return result;
        }

        public async Task<ServiceResult> AddSpentTime(int issueId, DateTime date, double hour, string description)
        {
            var client = ClientManager.GetClient();
            var values = new NameValueCollection { { "IssueId", issueId.ToString() }, { "Date", date.ToString() }, { "Hour", hour.ToString()}, { "Description", description} };

            var response = await client.UploadValuesTaskAsync(new Uri("http://localhost:2179/SpentTime/Create"), "POST", values);
            var result = JsonConvert.DeserializeObject<ServiceResult>(Encoding.UTF8.GetString(response));

            return result;
        }
    }
}
