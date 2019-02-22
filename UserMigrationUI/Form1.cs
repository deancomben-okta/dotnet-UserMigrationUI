using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using System.Configuration;

namespace UserMigrationUI
{
    public partial class Form1 : Form
    {
        private List<JObject> userlist;
        private ILogger logger;

        public Form1()
        {
            InitializeComponent();

            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug(LogLevel.Trace);
            this.logger = loggerFactory.CreateLogger("Logger");
            this.logger.LogDebug("Starting Logging");
        }

        private void start_btn_Click(object sender, EventArgs e)
        {

            //createUsers();

            BlockingCollection<JObject> blockingUserList = BlockingUserList(Convert.ToInt32(numericUpDown1.Value));

            int threads = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Threads"));

            for (int i = 0; i < threads; i++)
            {
                Task createUserTask = Task.Run(() => NonBlockingCreateUser(blockingUserList));
            }

        }

        private async void NonBlockingCreateUser(BlockingCollection<JObject> bc)
        {
            var threadID = Thread.CurrentThread.ManagedThreadId;
            while (!bc.IsCompleted)
            {
                var configuration = new Okta.Sdk.Configuration.OktaClientConfiguration
                {
                    OktaDomain = ConfigurationManager.AppSettings.Get("OktaOrgURL"),
                    Token = ConfigurationManager.AppSettings.Get("OktaAPIKey"),
                    MaxRetries = 10,
                    ConnectionTimeout = 5,
                    RequestTimeout = 120
                };
                //var client = new OktaClient(config);

                var httpClient = new System.Net.Http.HttpClient();
                var maxRetries = configuration.MaxRetries ?? OktaClientConfiguration.DefaultMaxRetries;
                var requestTimeout = configuration.RequestTimeout ?? OktaClientConfiguration.DefaultRequestTimeout;

                var client = new OktaClient(apiClientConfiguration: configuration, httpClient: httpClient, logger: this.logger, retryStrategy: new CustomRetryStrategy(maxRetries, requestTimeout, 1, logger));

                JObject user = null;
                try
                {
                    user = bc.Take();
                }
                catch (InvalidOperationException)
                {

                }
                if (user != null)
                {
                    //process
                    var uid = user.Value<JToken>("profile").Value<string>("login");
                    threadID = Thread.CurrentThread.ManagedThreadId;
                    //Console.WriteLine($"ThreadID: {threadID}, User: {uid}");
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        txtBox.AppendText($"ThreadID: {threadID}, Request: CreateUser, User: {uid}{Environment.NewLine}");
                    });

                    try
                    {
                        var result = await client.PostAsync<User>(new HttpRequest
                        {
                            Uri = $"/api/v1/users",
                            QueryParameters = new Dictionary<string, object>()
                            {
                                ["activate"] = false,
                            },
                            Payload = user
                        });

                        threadID = Thread.CurrentThread.ManagedThreadId;
                        //Console.WriteLine($"ThreadID: {threadID}, User: {uid}, Status: {result.Status}");
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            txtBox.AppendText($"ThreadID: {threadID}, Response: CreateUser, User: {uid}, Status: {result.Status}{Environment.NewLine}");
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            txtBox.AppendText(ex.Message + Environment.NewLine);
                        });
                    }
                }
                //Thread.SpinWait(5000000);
            }
            threadID = Thread.CurrentThread.ManagedThreadId;
            this.Invoke((MethodInvoker)delegate ()
            {
                txtBox.AppendText($"ThreadID: {threadID}, Processing Done!");
            });
        }

        private async void NonBlockingDeleteUser(BlockingCollection<JObject> bc)
        {
            var threadID = Thread.CurrentThread.ManagedThreadId;
            while (!bc.IsCompleted)
            {
                var configuration = new Okta.Sdk.Configuration.OktaClientConfiguration
                {
                    OktaDomain = ConfigurationManager.AppSettings.Get("OktaOrgURL"),
                    Token = ConfigurationManager.AppSettings.Get("OktaAPIKey"),
                    MaxRetries = 10,
                    ConnectionTimeout = 5,
                    RequestTimeout = 120
                };
                //var client = new OktaClient(config);

                var httpClient = new System.Net.Http.HttpClient();
                var maxRetries = configuration.MaxRetries ?? OktaClientConfiguration.DefaultMaxRetries;
                var requestTimeout = configuration.RequestTimeout ?? OktaClientConfiguration.DefaultRequestTimeout;

                var client = new OktaClient(apiClientConfiguration: configuration, httpClient: httpClient, logger: this.logger, retryStrategy: new CustomRetryStrategy(maxRetries, requestTimeout, 1, logger));

                JObject user = null;
                try
                {
                    user = bc.Take();
                }
                catch (InvalidOperationException)
                {

                }
                if (user != null)
                {
                    //process
                    var uid = user.Value<JToken>("profile").Value<string>("login");
                    threadID = Thread.CurrentThread.ManagedThreadId;
                    //Console.WriteLine($"ThreadID: {threadID}, User: {uid}");
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        txtBox.AppendText($"ThreadID: {threadID}, Request: DeleteUser, User: {uid}{Environment.NewLine}");
                    });

                    try
                    {
                        // Get User
                        var u = await client.Users.GetUserAsync(uid);

                        // First, deactivate the user
                        await u.DeactivateAsync();

                        // Then delete the user
                        await u.DeactivateOrDeleteAsync();



                        threadID = Thread.CurrentThread.ManagedThreadId;
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            txtBox.AppendText($"ThreadID: {threadID}, Response: DeleteUser, User: {uid}, Status: DELETED{Environment.NewLine}");
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            txtBox.AppendText(ex.Message + Environment.NewLine);
                        });
                    }
                }
                //Thread.SpinWait(5000000);
            }
            threadID = Thread.CurrentThread.ManagedThreadId;
            this.Invoke((MethodInvoker)delegate ()
            {
                txtBox.AppendText($"ThreadID: {threadID}, Processing Done!");
            });
        }

        private async void createUsers()
        {
            // Get lots of users
            userlist = UserList(Convert.ToInt32(numericUpDown1.Value));

            var configuration = new Okta.Sdk.Configuration.OktaClientConfiguration
            {
                OktaDomain = ConfigurationManager.AppSettings.Get("OktaOrgURL"),
                Token = ConfigurationManager.AppSettings.Get("OktaAPIKey"),
                MaxRetries = 10,
                ConnectionTimeout = 5,
                RequestTimeout = 120
            };
            //var client = new OktaClient(config);

            var httpClient = new System.Net.Http.HttpClient();
            var maxRetries = configuration.MaxRetries ?? OktaClientConfiguration.DefaultMaxRetries;
            var requestTimeout = configuration.RequestTimeout ?? OktaClientConfiguration.DefaultRequestTimeout;

            var client = new OktaClient(apiClientConfiguration: configuration, httpClient: httpClient, logger: this.logger, retryStrategy: new DefaultRetryStrategy(maxRetries, requestTimeout));

            foreach (var user in userlist)
            {

                try
                {
                    var result = await client.PostAsync<User>(new HttpRequest
                    {
                        Uri = $"/api/v1/users",
                        QueryParameters = new Dictionary<string, object>()
                        {
                            ["activate"] = false,
                        },
                        Payload = user
                    });

                    Console.WriteLine($"Login: {result.Profile.Login}, Status: {result.Status}");
                    txtBox.AppendText($"Login: {result.Profile.Login}, Status: {result.Status}{Environment.NewLine}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    txtBox.AppendText(ex.Message + Environment.NewLine);
                }
            } //end foreach
        }

        static List<JObject> UserList(int count)
        {
            List<JObject> users = new List<JObject>();
            for (int i = 0; i < count; i++)
            {
                var jsonObject = new JObject();
                dynamic user = jsonObject;
                user.profile = new JObject() as dynamic;
                user.profile.firstName = $"Anakin{i}";
                user.profile.lastName = $"Skywalker{i}";
                user.profile.email = $"darth.vader{i}@imperial-senate.gov";
                user.profile.login = $"darth.vader{i}@imperial-senate.gov";
                user.profile.memberNumber = "474839294";
                user.credentials = new JObject() as dynamic;
                user.credentials.password = new JObject() as dynamic;
                //user.credentials.password.value = "D1sturB1ng!";
                user.credentials.password.hash = new JObject() as dynamic;
                user.credentials.password.hash.algorithm = "BCRYPT";
                user.credentials.password.hash.workFactor = 10;
                user.credentials.password.hash.salt = "rwh3vH166HCH/NT9XV5FYu";
                user.credentials.password.hash.value = "qaMqvAPULkbiQzkTCWo5XDcvzpk8Tna";
                user.groupIds = new JArray();
                user.groupIds.Add("00gjcgmj8gGinzhpW0h7"); //Replace with Okta Group ID

                users.Add(user);
            }

            return users;
        }

        static BlockingCollection<JObject> BlockingUserList(int count)
        {
            BlockingCollection<JObject> users = new BlockingCollection<JObject>();
            for (int i = 0; i < count; i++)
            {
                var jsonObject = new JObject();
                dynamic user = jsonObject;
                user.profile = new JObject() as dynamic;
                user.profile.firstName = $"Anakin{i}";
                user.profile.lastName = $"Skywalker{i}";
                user.profile.email = $"darth.vader{i}@imperial-senate.gov";
                user.profile.login = $"darth.vader{i}@imperial-senate.gov";
                user.profile.memberNumber = "474839294";
                user.credentials = new JObject() as dynamic;
                user.credentials.password = new JObject() as dynamic;
                //user.credentials.password.value = "D1sturB1ng!";
                user.credentials.password.hash = new JObject() as dynamic;
                user.credentials.password.hash.algorithm = "BCRYPT";
                user.credentials.password.hash.workFactor = 10;
                user.credentials.password.hash.salt = "rwh3vH166HCH/NT9XV5FYu";
                user.credentials.password.hash.value = "qaMqvAPULkbiQzkTCWo5XDcvzpk8Tna";
                user.groupIds = new JArray();
                user.groupIds.Add("00gjcgmj8gGinzhpW0h7"); //Replace with Okta Group ID

                users.Add(user);
            }

            return users;
        }

        private async void delete_btn_Click(object sender, EventArgs e)
        {
            //DeleteUsers();

            BlockingCollection<JObject> blockingUserList = BlockingUserList(Convert.ToInt32(numericUpDown1.Value));

            int threads = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Threads"));

            for (int i = 0; i < threads; i++)
            {
                Task deleteUsersTask = Task.Run(() => NonBlockingDeleteUser(blockingUserList));
            }

        }

        private async void DeleteUsers()
        {
            // Get lots of users
            userlist = UserList(Convert.ToInt32(numericUpDown1.Value));

            var configuration = new Okta.Sdk.Configuration.OktaClientConfiguration
            {
                OktaDomain = ConfigurationManager.AppSettings.Get("OktaOrgURL"),
                Token = ConfigurationManager.AppSettings.Get("OktaAPIKey"),
                MaxRetries = 10,
                ConnectionTimeout = 5,
                RequestTimeout = 120
            };
            //var client = new OktaClient(config);

            var httpClient = new System.Net.Http.HttpClient();
            var maxRetries = configuration.MaxRetries ?? OktaClientConfiguration.DefaultMaxRetries;
            var requestTimeout = configuration.RequestTimeout ?? OktaClientConfiguration.DefaultRequestTimeout;

            var client = new OktaClient(apiClientConfiguration: configuration, httpClient: httpClient, logger: this.logger, retryStrategy: new DefaultRetryStrategy(maxRetries, requestTimeout));


            foreach (var user in userlist)
            {
                try
                {
                    // Get User
                    var uid = user.Value<JToken>("profile").Value<string>("login");
                    var u = await client.Users.GetUserAsync(uid);

                    // First, deactivate the user
                    await u.DeactivateAsync();

                    // Then delete the user
                    await u.DeactivateOrDeleteAsync();

                    Console.WriteLine($"Login: {u.Profile.Login}, Status: DELETED");
                    txtBox.AppendText($"Login: {u.Profile.Login}, Status: DELETED {Environment.NewLine}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    txtBox.AppendText(ex.Message + Environment.NewLine);
                }
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //
        }
    }
}
