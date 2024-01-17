using Newtonsoft.Json;
using RestSharp;
using System.CodeDom.Compiler;
using System.Net;
using System.Net.Http;


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


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            // Call the API
            // uses RestSharp
            // Source (base address) https://localhost:5000/v1/api/

            var client = new RestClient("https://localhost:5000/v1/api/");
            

            var request = new RestRequest("iserver/auth/status");
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;

                // convert raw data
                result = JsonConvert.DeserializeObject<Auth_Status.Rootobject>(rawResponse);

                listBox1.Items.Add(rawResponse);
                if (result != null)     // if we have data... (not null)
                {
                    listBox1.Items.Add("Auth: " + result.authenticated);       // put object in listbox
                }
            }
        }
    }
}
