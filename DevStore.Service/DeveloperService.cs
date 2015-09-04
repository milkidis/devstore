using DevStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Configuration;

namespace DevStore.Service
{
    public class DeveloperService
    {
        const int pesoTotalRepository = 6;
        const int pesoTotalFollowers = 8;

        public List<Developer> page(int page = 1, int size = 40)
        {
            var credentials = new Octokit.Credentials(ConfigurationManager.AppSettings["user_git"], ConfigurationManager.AppSettings["pass_git"]);
            Octokit.Connection connection = new Connection(new ProductHeaderValue("DevStore"));
            Octokit.ApiConnection apiConn = new ApiConnection(connection);
            Octokit.SearchUsersRequest search = new SearchUsersRequest("a");
            search.AccountType = AccountSearchType.User;
            search.PerPage = size;
            search.Page = page;
            Octokit.UsersClient userCliente = new UsersClient(apiConn);
            Octokit.SearchClient searchUserService = new SearchClient(apiConn);
            SearchUsersResult usersResult = searchUserService.SearchUsers(search).Result;
            Octokit.GitHubClient gitClient = new GitHubClient(connection);
            Octokit.UsersClient userClient = new UsersClient(apiConn);
            List<Developer> developers = (from userGit in usersResult.Items
                                          select new Developer
                                          {
                                              User = userGit.Login,
                                              UrlAvatar = userGit.AvatarUrl.ToString(),
                                              TotalRepo = userGit.PublicRepos,
                                              TotalFollowers = userGit.Followers,
                                              Price = ((userGit.PublicRepos * pesoTotalRepository) + (userGit.Followers * pesoTotalFollowers)) / (pesoTotalRepository + pesoTotalFollowers)
                                          }).ToList();


            return developers;
        }
    }
}
