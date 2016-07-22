using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;
using System.Threading;

namespace PowerBiRestAPI.Models {

  public class Dataset {
    public string id { get; set; }
    public string name { get; set; }
  }

  public class DatasetCollection {
    public List<Dataset> value { get; set; }
  }

  public class Contribution {
    public int ContributionID { get; set; }
    public string Contributor { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zip { get; set; }
    public string Gender { get; set; }
    public string Time { get; set; }
    public decimal Amount { get; set; }
  }

  class ContributionSet {
    public Contribution[] rows { get; set; }
  }

  class PowerBiWorkspaceManager {

    #region "Authentication Details"

    const string authority = "https://login.microsoftonline.com/common";

    const string resourceUriPowerBiService = "https://analysis.windows.net/powerbi/api";
    const string redirectUri = "https://localhost/PowerBiRestApiDemo";

    const string clientID = "0dbb0048-4ef7-4d9e-ba07-afad8170f1dd";

    protected string AccessToken = string.Empty;

    protected string rootUrlPowerBiService = "https://api.powerbi.com/v1.0/myorg/";


    protected void GetAccessToken() {

      // create new authentication context 
      var authenticationContext = new AuthenticationContext(authority);

      // use authentication context to trigger user sign-in and return access token 
      var userAuthnResult = authenticationContext.AcquireToken(resourceUriPowerBiService,
                                                               clientID,
                                                               new Uri(redirectUri),
                                                               PromptBehavior.RefreshSession);
      // cache access token in AccessToken field
      AccessToken = userAuthnResult.AccessToken;


    }

    #endregion

    #region "REST Operation utility methods"

    private string ExecuteGetRequest(string restUri) {

      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
      client.DefaultRequestHeaders.Add("Accept", "application/json");

      HttpResponseMessage response = client.GetAsync(restUri).Result;

      if (response.IsSuccessStatusCode) {
        return response.Content.ReadAsStringAsync().Result;
      }
      else {
        Console.WriteLine("ERROR during REST call with GET");
        return string.Empty;
      }
    }

    private string ExecutePostRequest(string restUri, string postBody) {

      try {
        HttpContent body = new StringContent(postBody);
        body.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
        HttpResponseMessage response = client.PostAsync(restUri, body).Result;

        if (response.IsSuccessStatusCode) {
          return response.Content.ReadAsStringAsync().Result;
        }
        else {
          Console.WriteLine();
          Console.WriteLine("ERROR during REST call with POST");
          Console.WriteLine();
          return string.Empty;
        }
      }
      catch {
        Console.WriteLine();
        Console.WriteLine("ERROR during REST call with POST");
        Console.WriteLine();
        return string.Empty;
      }
    }

    private string ExecuteDeleteRequest(string restUri) {
      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Add("Accept", "application/json");
      client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AccessToken);
      HttpResponseMessage response = client.DeleteAsync(restUri).Result;

      if (response.IsSuccessStatusCode) {
        return response.Content.ReadAsStringAsync().Result;
      }
      else {
        Console.WriteLine("ERROR during REST call with Delete");
        return string.Empty;
      }
    }

    #endregion

    public PowerBiWorkspaceManager() {
      GetAccessToken();
    }

    private bool DatasetExist(string datasetName) {
      string json = ExecuteGetRequest(rootUrlPowerBiService + "datasets/");
      DatasetCollection datasets = JsonConvert.DeserializeObject<DatasetCollection>(json);
      foreach (var ds in datasets.value) {
        if (ds.name.Equals(datasetName)) {
          ContributionsDatasetId = ds.id;
          return true;
        }
      }
      return false;
    }

    private string ContributionsDatasetId = string.Empty;

    public void CreateDataset() {
      string datasetName = "Campaign Contributions";
      if (DatasetExist(datasetName)) {
        DeleteRows();
        PopulateHelperTables();
        Console.WriteLine("Connecting to Power BI Dataset named '" + datasetName + "'...");
        Thread.Sleep(1500);
        Console.WriteLine("Connected to " + datasetName + " dataset");
        Console.WriteLine();
        return;
      }
      string restUrlDatasets = rootUrlPowerBiService + "datasets";
      string jsonNewDataset = Properties.Resources.NewDataset_json;

      string json = ExecutePostRequest(restUrlDatasets, jsonNewDataset);
      Dataset dataset = JsonConvert.DeserializeObject<Dataset>(json);

      ContributionsDatasetId = dataset.id;      
      PopulateHelperTables();
      Console.WriteLine("Creating new Power BI Dataset named " + datasetName + "...");
    }

    public void PopulateHelperTables() {

      string restUrlDatasets = rootUrlPowerBiService + "datasets";

      string jsonRowsGoal = @"{ ""rows"": [ { ""Value"": 1000000  }] }";
      string restUrlTableRowsGoal = string.Format("{0}/{1}/tables/ContributionsGoal/rows", restUrlDatasets, ContributionsDatasetId);
      ExecuteDeleteRequest(restUrlTableRowsGoal);
      ExecutePostRequest(restUrlTableRowsGoal, jsonRowsGoal);

      string jsonRowsMax = @"{ ""rows"": [ { ""Value"": 1250000  }] }";
      string restUrlTableRowsMax = string.Format("{0}/{1}/tables/ContributionsMax/rows", restUrlDatasets, ContributionsDatasetId);
      ExecuteDeleteRequest(restUrlTableRowsMax);
      ExecutePostRequest(restUrlTableRowsMax, jsonRowsMax);
    }

    public void DeleteRows() {
      string restUrlDatasets = rootUrlPowerBiService + "datasets";
      string restUrlTableRows = string.Format("{0}/{1}/tables/Contributions/rows", restUrlDatasets, ContributionsDatasetId);
      string json = ExecuteDeleteRequest(restUrlTableRows);
    }

    public void AddRows() {
      Console.Write(".");
      List<Contribution> contributionList = new List<Contribution>();
      foreach (var contribution in DataFactory.GetContributionList()) {
        contributionList.Add(new Contribution {
          ContributionID = contribution.ID,
          Contributor = contribution.FirstName + " " + contribution.LastName,
          City = contribution.City + ", " + contribution.State,
          State = contribution.State,
          Zip = contribution.ZipCode,
          Gender = contribution.Gender,
          Time = contribution.Time,
          Amount = contribution.Amount
        });
      }

      ContributionSet contributionSet = new ContributionSet {
        rows = contributionList.ToArray<Contribution>()
      };

      string jsonRows = JsonConvert.SerializeObject(contributionSet);

      string restUrlDatasets = rootUrlPowerBiService + "datasets";
      string restUrlTableRows = string.Format("{0}/{1}/tables/Contributions/rows", restUrlDatasets, ContributionsDatasetId);
      string json = ExecutePostRequest(restUrlTableRows, jsonRows);

    }

  }
}