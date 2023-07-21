using EcommerceERPConnector_V1._0_.Models;
using EcommerceERPConnector_V1._0_.Services;
using Microsoft.CSharp;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace EcommerceERPConnector_V1._0_.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        IJsonOperations _operations;
        string codeSource = "";
        public MainView()
        {
            InitializeComponent();
            _operations = new JsonOperations();
        }
        #region event
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ecommerceGetUrl = ecommerceGet.Text, erpGetUrl = erpGet.Text;
            IList<Dictionary<string, dynamic>> list = getRequest(ecommerceGetUrl, erpGetUrl);
            fillDataGrid(list);
        }
        #region methods related to Button_Click event

        #region Get columns values and types
        private IList<Dictionary<string, dynamic>> getRequest(string url1, string url2)
        {
            try
            {
                IList<Dictionary<string, dynamic>> list = new List<Dictionary<string, dynamic>>();
                for (int i = 0; i < 2; i++)
                {

                    url1 = "https://api.escuelajs.co/api/v1/auth/profile";
                    url2 = "https://localhost:7002/api/User/4";
                    dynamic jsonObj = _operations.stringToJObject(_operations.getJsonString(i == 0 ? url1 : url2, i == 0 ? true : false));
                    Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();
                    foreach (var j in jsonObj)
                    {
                        dict.Add(((JProperty)j).Name, ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)j).First).Type);
                    }
                    list.Add(dict);
                }
                return list;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
        #endregion

        #region Datagrid Mapper
        private void fillDataGrid(IList<Dictionary<string, dynamic>> list)
        {
            try
            {
                DataGrid dataGrid = dataTable;

                #region combo box items ecommerce obj
                var cbItems = new List<KeyValuePair<string, dynamic>>();
                foreach (KeyValuePair<string, dynamic> l in list[0])
                {
                    cbItems.Add(l);
                }
                cbItems.Add(new KeyValuePair<string, dynamic>());
                #endregion

                #region combo box items constratints list
                var ccItems = new List<string>();
                ccItems.Add("None");
                ccItems.Add("Start");
                ccItems.Add("End");
                #endregion

                #region prepare items list 
                List<Item> it = new List<Item>();
                int i = 0;
                foreach (KeyValuePair<string, dynamic> l in list[0])
                {
                    it.Add(new Item { isRemoved = false, cinstraintValue = "", constraint = ccItems[0], erpObj = l, manualInput = "", isEmpty = false, ecommerceObjList = cbItems, constraints = ccItems, ecommerceObj = cbItems[i] /*new KeyValuePair<string,dynamic>()*/ });
                    i++;
                }
                #endregion

                dataGrid.ItemsSource = it;
            }
            catch (Exception e) { Debug.WriteLine(e); }
        }
        #endregion

        #endregion
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            DataGrid dataGrid = dataTable;
            var row = dataGrid.ItemsSource.GetEnumerator;
            List<Item> attributeList = (List<Item>)row.Target;

            string getListUrl = getListEndpoint.Text;
            string postListUrl = PostListEndpoint.Text;
            // test data to be removed
            getListUrl = "https://api.escuelajs.co/api/v1/users";
            postListUrl = "https://localhost:7002/api/User";

            string getERPList = "https://localhost:7002/api/User";

            codeSource = @"
using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace EcommerceERPConnector_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(getData("+"\""+  getListUrl + "\" " + " , "+"\"" + postListUrl + "\" "+ " , "+ "\"" + getERPList + "\" " + " , " + " \""+settings["ecommerceToken"].Value+ "\" " + @"));
            string x =Console.ReadLine();
        }

        #region Get Info
        private static string getData (string getEcomUrl, string postUrl, string getERPList, string token)
        {
            var jsonArray = new JArray();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;            
            WebClient wc = new WebClient();
            wc.Headers.Add(""Authorization"", ""Bearer "" + ""token"" );

            string res1 = wc.DownloadString(getEcomUrl);
            JArray ecomList = JArray.Parse(res1);

            string res2 = wc.DownloadString(getERPList);
            JArray erpList = JArray.Parse(res2);
            
            int newItems = ecomList.Count - erpList.Count;
            JObject obj = (JObject)ecomList[ecomList.Count - newItems];
                //var jsonArray = new JArray();
                Dictionary<string, dynamic> ecomObj = new Dictionary<string, dynamic>();

                //transfer each attribute into dictionarry
                foreach (var j in obj)
                {
                    ecomObj.Add(j.Key, j.Value.ToString());
                }

                string attribute;
                dynamic value = null;
                var _json = new JObject();
                ";
            JArray j = SourceGenerator_Sample(attributeList, getListUrl, postListUrl,getERPList, settings["ecommerceToken"].Value);
            codeSource += @"
                    Console.WriteLine(jsonArray);
                    return ""new"";
                    }
                    #endregion
                    }
                    }
                    ";
            BuildConnector("E:\\Projects\\Timsoft\\files\\EXE", codeSource);
        }

        #region methods related to Button_Click1

        #region Code Generator

        private JArray SourceGenerator_Sample(dynamic attributeList, string ecomGetEndpoint, string erpPostEndpoint, string erpGetEndpoint, string token)
        {
            try
            {
                var jsonArray = new JArray();

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebClient wc = new WebClient();
                wc.Headers.Add("Authorization", "Bearer " + "token");

                string res1 = wc.DownloadString(ecomGetEndpoint);
                JArray ecomList = JArray.Parse(res1);

                string res2 = wc.DownloadString(erpGetEndpoint);
                JArray erpList = JArray.Parse(res2);

                int newItems = ecomList.Count - erpList.Count;
                while (newItems > 0)
                {
                    JObject obj = (JObject)ecomList[ecomList.Count - newItems];
                    Dictionary<string, dynamic> ecomObj = new Dictionary<string, dynamic>();
                    //transfer each attribute into dictionarry
                    foreach (var j in obj)
                    {
                        ecomObj.Add(j.Key, j.Value.ToString());
                    };
                    var _json = new JObject();
                    _json = JObject.Parse(@"{ }");
                    string attribute;
                    StringBuilder s= new StringBuilder();
                    s.Append(@"
                    _json = JObject.Parse(@""{ }"");");
                    for (int i = 0; i < ecomObj.Count; i++)
                    {
                        s.Append(@"
                        attribute = "+"\""+ attributeList[i].erpObj.Key+"\""+@";
                        
                        ");
                        attribute = attributeList[i].erpObj.Key;
                        dynamic value = null;

                        //step 0
                        if (!attributeList[i].isRemoved)
                        {
                            //step1 1
                            if (attributeList[i].isEmpty == true)
                            {
                                _json.Add(attribute, generattJsonDefaultValue(attributeList[i].erpObj.Value));
                                s.Append(@" _json.Add(attribute, " + "\"" +generattJsonDefaultValue(attributeList[i].erpObj.Value)+"\"" + ");");
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(attributeList[i].manualInput))
                                {
                                    //test 2
                                    value = replaceVariables(attributeList[i].manualInput, ecomObj);
                                    s.Append(@"value = " + "\"" + replaceVariables(attributeList[i].manualInput, ecomObj) + "\"" + ";");
                                }
                                if (!attributeList[i].ecommerceObj.Equals(default(KeyValuePair<string, dynamic>)))
                                {
                                    //test 3
                                    value += ecomObj.Where(pair => pair.Key == attributeList[i].ecommerceObj.Key).ToList().FirstOrDefault().Value;
                                    s.Append("value += " + "\"" + ecomObj.Where(pair => pair.Key == attributeList[i].ecommerceObj.Key).ToList().FirstOrDefault().Value + "\""+";");
                                }


                                //test 4 + 5
                                switch (attributeList[i].constraint)
                                {
                                    case "None": break;
                                    case "Start": value = attributeList[i].cinstraintValue + value; s.Append("value = " + "\"" + attributeList[i].cinstraintValue + value + "\""+""); break;
                                    case "End": value = value + attributeList[i].cinstraintValue; s.Append("value = " + "\"" + value + attributeList[i].cinstraintValue + "\"" + ""); break;
                                }
                                s.Append("_json.Add(attribute, value);value=null;");
                                _json.Add(attribute, value);
                            }
                        }

                    }
                    s.Append("jsonArray.Add(_json);");
                    jsonArray.Add(_json);
                    s.Append("newItems--;");
                    newItems--;
                    codeSource +=s.ToString();
                }
                
                return jsonArray;
                
            }
            catch (Exception e) { Debug.WriteLine(e); return null; }
            
        }
        #region generate Json Default Value
        private dynamic generattJsonDefaultValue(dynamic type)
        {
            switch (Convert.ToString(type))
            {
                case "None": return null;
                case "Object": return null;
                case "Array": return Array.Empty<object>();
                case "Constructor": return null;
                case "Property": return null;
                case "Comment": return null;
                case "Integer": return 0;
                case "Float": return 0;
                case "String": return "";
                case "Boolean": return false;
                case "Null": return null;
                case "Undefinded": return null;
                case "Date": return "";
                case "Raw": return null;
                case "Guid": return "";
                case "Uri": return "";
                case "Timespan": return "";
            }
            return null;
        }
        #endregion
        #region replace Variables
        private string replaceVariables(string value, Dictionary<string, dynamic> ecomObj)
        {
            string pattern = @"\{([^}]*)\}";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(value);

            //replace value between brackets with captured object values
            string replaced = Regex.Replace(value, pattern, (match) => { return ecomObj.Where(pair => pair.Key == match.Groups[1].Value).ToList().FirstOrDefault().Value; });

            return replaced;
        }
        #endregion
        #endregion

        #region Build EXE
        public void BuildConnector( string outputPath, string codeSource)
        {
            try
            {
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();

                //generate exe, not dll
                parameters.GenerateExecutable = true;
                // Set the assembly file name to generate.
                parameters.OutputAssembly ="Out.exe";
                parameters.IncludeDebugInformation = true;
                parameters.ReferencedAssemblies.AddRange(new string[] { "System.dll", "System.Net.dll", "Newtonsoft.Json.dll", "System.Core.dll", "Microsoft.CSharp.dll" });
                // Save the assembly as a physical file.
                parameters.GenerateInMemory = false;
                //parameters.TempFiles = new TempFileCollection(outputPath, true);
                // Set compiler argument to optimize output.
                parameters.CompilerOptions = "/optimize";
                
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, codeSource);
            }
            catch (Exception ex) { }
        }
        #endregion

        #endregion

    }
}
