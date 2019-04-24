using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace UserMigrationUI
{
    public partial class Form1 : Form
    {
        private List<JObject> userlist;
        private ILogger logger;

        private string oktaOrgURL = ConfigurationManager.AppSettings.Get("OktaOrgURL");
        private string oktaAPIKey = ConfigurationManager.AppSettings.Get("OktaAPIKey");
        private int threads = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Threads"));

        private static int userCount = 0;
        private int userProcessedCount = 0;
        private DateTime startTime;
        private System.Windows.Forms.Timer statusTimer;

        private CancellationTokenSource tokenSource;
        private CancellationToken token;
        private ConcurrentBag<Task> bulkLoadTasks;

        public Form1()
        {
            InitializeComponent();

            ILoggerFactory loggerFactory = new LoggerFactory()
                .AddConsole()
                .AddDebug(LogLevel.Trace);
            this.logger = loggerFactory.CreateLogger("Logger");
            this.logger.LogDebug("Starting Logging");
        }

        private void TestDataStart_btn_Click(object sender, EventArgs e)
        {
            BlockingCollection<JObject> blockingUserList = BlockingUserList(Convert.ToInt32(numericUpDown1.Value));
            progressBar1.Maximum = userCount;

            testDataStart_btn.Enabled = false;
            testDataDelete_btn.Enabled = false;
            jsonFileStart_btn.Enabled = false;
            jsonFileDelete_btn.Enabled = false;
            jsonFileStop_btn.Enabled = false;
            testDataStop_btn.Enabled = true;

            txtBoxSuccess.Clear();
            txtBoxFailure.Clear();

            startTime = DateTime.Now;
            statusTimer.Start();

            oktaAPIKey = oktaAPIKey_txtBox.Text;
            oktaOrgURL = oktaOrgURL_txtBox.Text;
            threads = (int) numThreads_upDown.Value;

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            bulkLoadTasks = new ConcurrentBag<Task>();
            for (int i = 0; i < threads; i++)
            {
                Task bulkLoadTask = Task.Factory.StartNew( () => NonBlockingCreateUser(blockingUserList, token), token);
                bulkLoadTasks.Add(bulkLoadTask);
            }

            try
            {
                Task.WaitAll(bulkLoadTasks.ToArray());
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nAggregateException thrown with the following inner exceptions:");
                txtBoxFailure.AppendText($"AggregateException thrown with the following inner exceptions:{Environment.NewLine}");

                // Display information about each exception. 
                foreach (var v in e.InnerExceptions)
                {
                    if (v is TaskCanceledException)
                    {
                        Console.WriteLine("   TaskCanceledException: Task {0}",
                                          ((TaskCanceledException)v).Task.Id);
                        txtBoxFailure.AppendText($"   TaskCanceledException: Task {((TaskCanceledException)v).Task.Id}{Environment.NewLine}");
                    }
                    else
                    {
                        Console.WriteLine("   Exception: {0}", v.GetType().Name);
                        txtBoxFailure.AppendText($"   Exception: {v.GetType().Name}{Environment.NewLine}");
                    }
                }
                Console.WriteLine();
            }
            finally
            {
                tokenSource.Dispose();
                resetButtonsAndStopTimer();
            }           
        }

        private void JsonFileStart_btn_Click(object sender, EventArgs e)
        {
            if (jsonFilename_textBox.Text == "")
            {
                MessageBox.Show("JSON file must be specified.");
            }
            else
            {
                BlockingCollection<JObject> blockingUserList = new BlockingCollection<JObject>();

                testDataStart_btn.Enabled = false;
                testDataDelete_btn.Enabled = false;
                jsonFileStart_btn.Enabled = false;
                jsonFileDelete_btn.Enabled = false;
                testDataStop_btn.Enabled = false;
                jsonFileStop_btn.Enabled = true;

                using (StreamReader streamReader = new StreamReader(jsonFilename_textBox.Text))
                {
                    string json = streamReader.ReadToEnd();
                    dynamic userArray = JsonConvert.DeserializeObject(json);
                    blockingUserList = BlockingUserListFromJSONFile(userArray);
                }
                progressBar1.Maximum = userCount;

                txtBoxSuccess.Clear();
                txtBoxFailure.Clear();

                startTime = DateTime.Now;
                statusTimer.Start();

                oktaAPIKey = oktaAPIKey_txtBox.Text;
                oktaOrgURL = oktaOrgURL_txtBox.Text;
                threads = (int) numThreads_upDown.Value;

                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                bulkLoadTasks = new ConcurrentBag<Task>();
                for (int i = 0; i < threads; i++)
                {
                    Task bulkLoadTask = Task.Factory.StartNew(() => NonBlockingCreateUser(blockingUserList, token), token);
                    bulkLoadTasks.Add(bulkLoadTask);
                }

                try
                {
                    Task.WaitAll(bulkLoadTasks.ToArray());
                }
                catch (AggregateException e)
                {
                    Console.WriteLine("\nAggregateException thrown with the following inner exceptions:");
                    txtBoxFailure.AppendText($"AggregateException thrown with the following inner exceptions:{Environment.NewLine}");

                    // Display information about each exception. 
                    foreach (var v in e.InnerExceptions)
                    {
                        if (v is TaskCanceledException)
                        {
                            Console.WriteLine("   TaskCanceledException: Task {0}",
                                              ((TaskCanceledException)v).Task.Id);
                            txtBoxFailure.AppendText($"   TaskCanceledException: Task {((TaskCanceledException)v).Task.Id}{Environment.NewLine}");
                        }
                        else
                        {
                            Console.WriteLine("   Exception: {0}", v.GetType().Name);
                            txtBoxFailure.AppendText($"   Exception: {v.GetType().Name}{Environment.NewLine}");
                        }
                    }
                    Console.WriteLine();
                }
                finally
                {
                    tokenSource.Dispose();
                    resetButtonsAndStopTimer();
                }
            }
        }
        private void TestDataDelete_btn_Click(object sender, EventArgs e)
        {
            BlockingCollection<JObject> blockingUserList = BlockingUserList(Convert.ToInt32(numericUpDown1.Value));
            progressBar1.Maximum = userCount;

            testDataStart_btn.Enabled = false;
            testDataDelete_btn.Enabled = false;
            jsonFileStart_btn.Enabled = false;
            jsonFileDelete_btn.Enabled = false;
            jsonFileStop_btn.Enabled = false;
            testDataStop_btn.Enabled = true;

            txtBoxSuccess.Clear();
            txtBoxFailure.Clear();

            startTime = DateTime.Now;
            statusTimer.Start();

            oktaAPIKey = oktaAPIKey_txtBox.Text;
            oktaOrgURL = oktaOrgURL_txtBox.Text;
            threads = (int) numThreads_upDown.Value;

            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            bulkLoadTasks = new ConcurrentBag<Task>();
            for (int i = 0; i < threads; i++)
            {
                Task bulkLoadTask = Task.Factory.StartNew(() => NonBlockingDeleteUser(blockingUserList, token), token);
                bulkLoadTasks.Add(bulkLoadTask);
            }

            try
            {
                Task.WaitAll(bulkLoadTasks.ToArray());
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nAggregateException thrown with the following inner exceptions:");
                txtBoxFailure.AppendText($"AggregateException thrown with the following inner exceptions:{Environment.NewLine}");

                // Display information about each exception. 
                foreach (var v in e.InnerExceptions)
                {
                    if (v is TaskCanceledException)
                    {
                        Console.WriteLine("   TaskCanceledException: Task {0}",
                                          ((TaskCanceledException)v).Task.Id);
                        txtBoxFailure.AppendText($"   TaskCanceledException: Task {((TaskCanceledException)v).Task.Id}{Environment.NewLine}");
                    }
                    else
                    {
                        Console.WriteLine("   Exception: {0}", v.GetType().Name);
                        txtBoxFailure.AppendText($"   Exception: {v.GetType().Name}{Environment.NewLine}");
                    }
                }
                Console.WriteLine();
            }
            finally
            {
                tokenSource.Dispose();
                resetButtonsAndStopTimer();
            }
        }

        private void JsonFileDelete_btn_Click(object sender, EventArgs e)
        {
            if (jsonFilename_textBox.Text == "")
            {
                MessageBox.Show("JSON file must be specified.");
            }
            else
            {
                BlockingCollection<JObject> blockingUserList = new BlockingCollection<JObject>();

                testDataStart_btn.Enabled = false;
                testDataDelete_btn.Enabled = false;
                jsonFileStart_btn.Enabled = false;
                jsonFileDelete_btn.Enabled = false;
                testDataStop_btn.Enabled = false;
                jsonFileStop_btn.Enabled = true;

                using (StreamReader streamReader = new StreamReader(jsonFilename_textBox.Text))
                {
                    string json = streamReader.ReadToEnd();
                    dynamic userArray = JsonConvert.DeserializeObject(json);
                    blockingUserList = BlockingUserListFromJSONFile(userArray);
                }
                progressBar1.Maximum = userCount;

                txtBoxSuccess.Clear();
                txtBoxFailure.Clear();

                startTime = DateTime.Now;
                statusTimer.Start();

                oktaAPIKey = oktaAPIKey_txtBox.Text;
                oktaOrgURL = oktaOrgURL_txtBox.Text;
                threads = (int) numThreads_upDown.Value;

                tokenSource = new CancellationTokenSource();
                token = tokenSource.Token;
                bulkLoadTasks = new ConcurrentBag<Task>();
                for (int i = 0; i < threads; i++)
                {
                    Task bulkLoadTask = Task.Factory.StartNew(() => NonBlockingDeleteUser(blockingUserList, token), token);
                    bulkLoadTasks.Add(bulkLoadTask);
                }

                try
                {
                    Task.WaitAll(bulkLoadTasks.ToArray());
                }
                catch (AggregateException e)
                {
                    Console.WriteLine("\nAggregateException thrown with the following inner exceptions:");
                    txtBoxFailure.AppendText($"AggregateException thrown with the following inner exceptions:{Environment.NewLine}");

                    // Display information about each exception. 
                    foreach (var v in e.InnerExceptions)
                    {
                        if (v is TaskCanceledException)
                        {
                            Console.WriteLine("   TaskCanceledException: Task {0}",
                                              ((TaskCanceledException)v).Task.Id);
                            txtBoxFailure.AppendText($"   TaskCanceledException: Task {((TaskCanceledException)v).Task.Id}{Environment.NewLine}");
                        }
                        else
                        {
                            Console.WriteLine("   Exception: {0}", v.GetType().Name);
                            txtBoxFailure.AppendText($"   Exception: {v.GetType().Name}{Environment.NewLine}");
                        }
                    }
                    Console.WriteLine();
                }
                finally
                {
                    tokenSource.Dispose();
                    resetButtonsAndStopTimer();
                }
            }
        }

        private async void NonBlockingCreateUser(BlockingCollection<JObject> bc, CancellationToken ct)
        {
            var threadID = Thread.CurrentThread.ManagedThreadId;
            while (!bc.IsCompleted && !ct.IsCancellationRequested)
            {
                var configuration = new Okta.Sdk.Configuration.OktaClientConfiguration
                {
                    OktaDomain = oktaOrgURL,
                    Token = oktaAPIKey,
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
                        txtBoxSuccess.AppendText($"ThreadID: {threadID}, Request: CreateUser, User: {uid}{Environment.NewLine}");
                    });

                    try
                    {
                        JObject credentials = (JObject) user["credentials"];
                        JObject password = (JObject) credentials["password"];
                        password["value"] = "a@Z1" + Guid.NewGuid().ToString().Substring(0, 6);

                        var result = await client.PostAsync<User>(new HttpRequest
                        {
                            Uri = $"/api/v1/users",
                            QueryParameters = new Dictionary<string, object>()
                            {
                                ["activate"] = true,
                            },
                            Payload = user
                        });

                        threadID = Thread.CurrentThread.ManagedThreadId;
                        //Console.WriteLine($"ThreadID: {threadID}, User: {uid}, Status: {result.Status}");
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            if(result.Status == "ACTIVE")
                            {
                                txtBoxSuccess.AppendText($"ThreadID: {threadID}, Login: {uid}, Response: CreateUser, User: {uid}, Status: {result.Status}{Environment.NewLine}");
                            } else
                            {
                                txtBoxFailure.AppendText($"ThreadID: {threadID}, Login: {uid}, Response: CreateUser, User: {uid}, Status: {result.Status}{Environment.NewLine}");
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        threadID = Thread.CurrentThread.ManagedThreadId;
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            txtBoxFailure.AppendText($"ThreadID: { threadID}, Login: { uid}, Exception: {ex.Message}{Environment.NewLine}");

                        });
                    }

                    Interlocked.Increment(ref userProcessedCount);
                }
                //Thread.SpinWait(5000000);
            }
            threadID = Thread.CurrentThread.ManagedThreadId;
            this.Invoke((MethodInvoker)delegate ()
            {
                txtBoxSuccess.AppendText($"ThreadID: {threadID}, Processing Done!{Environment.NewLine}");
            });
        }

        private async void NonBlockingDeleteUser(BlockingCollection<JObject> bc, CancellationToken ct)
        {
            var threadID = Thread.CurrentThread.ManagedThreadId;
            while (!bc.IsCompleted && !ct.IsCancellationRequested)
            {
                var configuration = new Okta.Sdk.Configuration.OktaClientConfiguration
                {
                    OktaDomain = oktaOrgURL,
                    Token = oktaAPIKey,
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
                        txtBoxSuccess.AppendText($"ThreadID: {threadID}, Login: {uid}, Request: DeleteUser, User: {uid}{Environment.NewLine}");
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
                            txtBoxSuccess.AppendText($"ThreadID: {threadID}, Login: {uid}, Response: DeleteUser, User: {uid}, Status: DELETED{Environment.NewLine}");
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        threadID = Thread.CurrentThread.ManagedThreadId;
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            txtBoxFailure.AppendText($"ThreadID: { threadID}, Login: { uid}, Exception: {ex.Message}{Environment.NewLine}");
                        });
                    }

                    Interlocked.Increment(ref userProcessedCount);
                }
                //Thread.SpinWait(5000000);
            }
            threadID = Thread.CurrentThread.ManagedThreadId;
            this.Invoke((MethodInvoker)delegate ()
            {
                txtBoxSuccess.AppendText($"ThreadID: {threadID}, Processing Done!{Environment.NewLine}");
            });         
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

            userCount = count;
            return users;
        }

        static BlockingCollection<JObject> BlockingUserListFromJSONFile(dynamic userArray)
        {
            BlockingCollection<JObject> users = new BlockingCollection<JObject>();
            userCount = 0;
            foreach (var user in userArray)
            {
                users.Add(user);
                userCount++;
            }

            return users;
        }

        private void DisplayOpenFileDialog_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                jsonFilename_textBox.Text = openFileDialog1.FileName;
            }
        }

        private void TestDataStop_btn_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void JsonFileStop_btn_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oktaOrgURL_txtBox.Text = oktaOrgURL;
            oktaAPIKey_txtBox.Text = oktaAPIKey;
            numThreads_upDown.Value = threads;

            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Tick += new EventHandler(statusTimer_Tick);
            statusTimer.Interval = 1000; // in miliseconds

        }

        private void updateProgress()
        {
            int localUserProcessedCount = Interlocked.CompareExchange(ref userProcessedCount, 0, 0);
            progressBar1.Value = localUserProcessedCount;

            double numberOfSecondsElapsed = ((TimeSpan)(DateTime.Now - startTime)).TotalSeconds;
            double usersPerSecond = localUserProcessedCount / numberOfSecondsElapsed;
            double usersPerMinute = (numberOfSecondsElapsed < 60) ? (usersPerSecond * 60) : localUserProcessedCount / (numberOfSecondsElapsed / 60);

            progress_Lbl.Text = $"Processed {localUserProcessedCount} / {userCount} @ {usersPerSecond:N2} / sec ({usersPerMinute:N2} / min)";

            string elapsed = string.Format("{0:00}:{1:00}:{2:00}", numberOfSecondsElapsed / 3600, (numberOfSecondsElapsed / 60) % 60, numberOfSecondsElapsed % 60);
            double etcSeconds = (userCount - localUserProcessedCount) / usersPerSecond;
            string etc = string.Format("{0:00}:{1:00}:{2:00}", etcSeconds / 3600, (etcSeconds / 60) % 60, etcSeconds % 60);

            etc_Lbl.Text = $"Elapsed {elapsed}, ETC {etc}";
        }

        private void resetButtonsAndStopTimer()
        {
            statusTimer.Stop();

            userProcessedCount = 0;

            Console.WriteLine(progress_Lbl.Text);
            txtBoxSuccess.AppendText($"{progress_Lbl.Text} {Environment.NewLine}");

            progressBar1.Value = 0;
            progress_Lbl.Text = "";
            etc_Lbl.Text = "";

            testDataStart_btn.Enabled = true;
            testDataDelete_btn.Enabled = true;
            jsonFileStart_btn.Enabled = true;
            jsonFileDelete_btn.Enabled = true;
            jsonFileStop_btn.Enabled = false;
            testDataStop_btn.Enabled = false;
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                updateProgress();
            });
        }

    }
}
