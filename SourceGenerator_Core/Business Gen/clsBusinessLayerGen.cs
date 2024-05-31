using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SourceGenerator_Core.Business_Gen
{
    /// <summary>
    /// This class is seperated to two main partial classes 
    /// one for the main functions and the other for the core functions
    /// </summary>
    public partial class clsBusinessLayerGen
    {

        private static StringBuilder _Source;

        private static clsMainComponents _MainComponents;

        private static string _DataAccessClassName;

        private static string _DataAcessNameSpace;

        private static clsMainComponents.stParameter _UniqePar;

        /// <summary>
        /// this class Initializes the header of the class (the libraries, 
        /// name space and the name of the class)
        /// </summary>
        private static void _Initialize()
        {
            _Source = new StringBuilder();

            _Source.AppendLine(
                $@" using System;
                    using System.Collections.Generic;
                    using System.Data;
                    using System.Data.SqlClient;
                    using System.Linq;
                    using System.Text;
                    using System.Threading.Tasks;
                    using {_DataAcessNameSpace};
                    
                    namespace {_MainComponents.NameSpace}
                    {{
                        public class {_MainComponents.ClassName}
                        {{ "
                );
        }


        /// <summary>
        /// this function closes the class brakets
        /// </summary>
        private static void _Uninitialize()
        {
            _Source.AppendLine($@"
                     }}
               }}");
        }


        private static void AppendMainFunctions()
        {
            AppendMainProperties();
            AppendInitConstruct();
            AppendConstruct();
            AppendAddNewFunction();
            AppendUpdateFunction();
            AppendAllFindFunctions();
            AppendTheRestOfTheFunctions();
        }










        /// <summary>
        /// this function genereate the buisness layer for the DataAccess Class 
        /// </summary>
        /// <param name="mainComponents"></param>
        /// <param name="DataAccessClassName"></param>
        /// <returns></returns>
        public static string Generate(clsMainComponents mainComponents, string DataAccessClassName, string DataAcessNameSpace)
        {
            _MainComponents = mainComponents;
            _DataAccessClassName = DataAccessClassName;
            _UniqePar = mainComponents.GetUniqeID();
            _DataAcessNameSpace = DataAcessNameSpace;

            _Initialize();
            AppendMainFunctions();
            _Uninitialize();

            return _Source.ToString();
        }

    }
}
