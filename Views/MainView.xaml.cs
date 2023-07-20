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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EcommerceERPConnector_V1._0_.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        IJsonOperations _operations;
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
            Application.Current.Shutdown();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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

            string codeSource = @"
using System;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Logging;

namespace ConnectorGenerator
{ 
    class Program  
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello World!"");
            
        }
    }
}";
            BuildConnector("E:\\Projects\\Timsoft\\files\\EXE", codeSource);
        }

        #region methods related to Button_Click1

        #region Code Generator

        private string Generate ()
        {
            return "";
        }
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
                parameters.OutputAssembly = outputPath+"\\"+ "Out.exe";
                parameters.IncludeDebugInformation = true;
                parameters.ReferencedAssemblies.Add("System.dll");
                // Save the assembly as a physical file.
                parameters.GenerateInMemory = false;
                parameters.TempFiles = new TempFileCollection(outputPath, true);
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
