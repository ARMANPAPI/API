using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppLoginAtAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }
        HttpClient httpClient = new HttpClient();
        //private async Task<string> UserLogin(string username, string password)
        //{
            
        //    //try
        //    //{
        //    //    // Create a JSON object with the login credentials
        //    //    var loginData = new
        //    //    {
        //    //        Username = username,
        //    //        Password = password
        //    //    };

        //    //    // Serialize the JSON object into a string
        //    //    var jsonData = JsonConvert.SerializeObject(loginData);
        //    //    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //    //    // Send a POST request to the login API endpoint
        //    //    var response = await httpClient.PostAsync("https://api.example.com/login", content);

        //    //    // Check if the request was successful
        //    //    if (response.IsSuccessStatusCode)
        //    //    {
        //    //        // Read the response content as a string
        //    //        var responseContent = await response.Content.ReadAsStringAsync();

        //    //        // Parse the response JSON to get the token or other required information
        //    //        dynamic responseObject = JsonConvert.DeserializeObject(responseContent);
        //    //        string token = responseObject.Token;

        //    //        // Return the token
        //    //        return token;
        //    //    }
        //    //    else
        //    //    {
        //    //        // Handle the unsuccessful login response
        //    //        // For example, display an error message to the user
        //    //        return "Login failed. Please try again.";
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    // Handle any exceptions that occurred during the login process
        //    //    return "An error occurred: " + ex.Message;
        //    //}


        //}


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username=txtname.Text;
            string password=txtPassword.Text;

           // string token = await UserLogin(username, password);
        }
    }
}
