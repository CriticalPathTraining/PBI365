using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace PowerBiRestAPI.Models {

  public class Dataset {
    public string id { get; set; }
    public string name { get; set; }
  }

  public class DatasetCollection {
    public List<Dataset> value { get; set; }
  }

  public class Contribution {
    public int ID { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Gender { get; set; }
    public double Amount { get; set; }
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
                                                               PromptBehavior.Auto);
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
        Console.WriteLine("ERROR during REST call with POST");
        return string.Empty;
      }
    }


    #endregion

    public PowerBiWorkspaceManager() {
      GetAccessToken();
    }

    public void DisplayDatasets() {

      Console.WriteLine();
      Console.WriteLine("DisplayDatasets executing");

      string restUrlDatasets = rootUrlPowerBiService + "datasets/";

      string json = ExecuteGetRequest(restUrlDatasets);
      Console.WriteLine(json);
      Console.WriteLine();

      DatasetCollection datasets = JsonConvert.DeserializeObject<DatasetCollection>(json);
      foreach (var ds in datasets.value) {
        string jsonDataset = ExecuteGetRequest(restUrlDatasets + ds.id + "/tables/");
        Console.WriteLine(ds.id);
        Console.WriteLine(ds.name);
        Console.WriteLine(jsonDataset);
        Console.WriteLine();
      }
      //var TenantDetailsList = JObject.Parse(json).SelectToken("value").ToObject<List<AzureTenantDetails>>();
      //var TenantDetails = TenantDetailsList.FirstOrDefault();
      //Console.WriteLine(" - Display Name: " + TenantDetails.displayName);
      //Console.WriteLine(" - Tenant City : " + TenantDetails.city);
      //Console.WriteLine(" - Tenant Phone: " + TenantDetails.telephoneNumber);
    }

    public bool DatasetExist(string datasetName) {
      string restUrlDatasets = rootUrlPowerBiService + "datasets/";

      string json = ExecuteGetRequest(restUrlDatasets);     
      DatasetCollection datasets = JsonConvert.DeserializeObject<DatasetCollection>(json);
      foreach (var ds in datasets.value) {
        if (ds.name.Equals(datasetName)) {
          DonationsDatasetId = ds.id;
          return true;
        }
      }

      return false;
    }

    string DonationsDatasetId = string.Empty;

    public void CreateDataset() {

      string datasetName = "Campaign Donations";
      if (DatasetExist(datasetName)) {
        Console.WriteLine("Dataset already exists");
        return;
      }

      Console.WriteLine("Creating Dataset");
      string restUrlDatasets = rootUrlPowerBiService + "datasets";
      string jsonNewDataset = Properties.Resources.NewDataset_json;

      string json = ExecutePostRequest(restUrlDatasets, jsonNewDataset);
      Dataset dataset = JsonConvert.DeserializeObject<Dataset>(json);

      DonationsDatasetId = dataset.id;

      Console.WriteLine("Dataset Created with ID of " + dataset.id);
      Console.WriteLine();

    }

    private int donationId = 0;

    public void AddRows() {
      Console.WriteLine("Adding rows...");


      var donarList = DataFactory.GetDonationList();

      List<Contribution> contributionList = new List<Contribution>();

      foreach (var donar in donarList) {
        Console.WriteLine("Adding " + donar.FirstName + " " + donar.LastName);
        donationId += 1;
        contributionList.Add(new Contribution {
          ID = donationId,
          Name = donar.FirstName + " " + donar.LastName,
          City = donar.City,
          State = donar.State,
          Zip = donar.ZipCode,
          Gender = donar.Gender,
          Amount = donar.Amount
        });
      }


      ContributionSet contributionSet = new ContributionSet {
        rows = contributionList.ToArray<Contribution>()
      };

      string jsonRows = JsonConvert.SerializeObject(contributionSet);

      string restUrlDatasets = rootUrlPowerBiService + "datasets";
      string restUrlTableRows = string.Format("{0}/{1}/tables/Donations/rows", restUrlDatasets, DonationsDatasetId);
      string json = ExecutePostRequest(restUrlTableRows, jsonRows);

    }
  }
}