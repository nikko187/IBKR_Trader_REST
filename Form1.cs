using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;


namespace IBKR_Trader_REST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // GLOBAL VARIABLES
        Auth_Status.Rootobject result;  // Store result of API conversion

        public static HttpClient _httpClient = new HttpClient();
        public static Uri BaseUri = new Uri("https://localhost:5000/v1/api/");

        public const string getAuthStatus = "iserver/auth/status";
        public const string tickle = "tickle";
        public const string getMarketDataSnapshot = "md/snapshot";

        private void btnRead_Click(object sender, EventArgs e)
        {
            GetData();
        }

        public async Task GetData()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseUri, getAuthStatus));

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string rawResponse = response.Content.ToString();
                        result = JsonConvert.DeserializeObject<Auth_Status.Rootobject>(rawResponse);
                        Debug.WriteLine(JsonConvert.SerializeObject(result));

                        if (result != null)
                        {
                            listBox1.Items.Add("Auth: " + result);
                        }
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Insert(0, "ex: " + ex);
                    }
                }
                
            }
            catch (Exception e) { MessageBox.Show(e.Message); } // SSL CONNECTION COULD NOT BE ESTABLISHED
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
