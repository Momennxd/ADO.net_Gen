using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGenerator_Core
{
    /// <summary>
    /// This class is seperated to two main partial classes 
    /// one for the main functions and the other for the core functions
    /// </summary>
    public partial class DataAccessGen
    {



        private static StringBuilder _Source;

        private static clsMainComponents _MainComponents;

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
                    
                    namespace {_MainComponents.NameSpace}
                    {{
                        public class {_MainComponents.ClassName}
                        {{ "
                );
        }

        private static void _Uninitialize()
        {
            _Source.AppendLine($@"
                     }}
               }}");
        }

        private static void _AppendMainFunctions()
        {
            clsMainComponents.stParameter UniqPar = _MainComponents.GetUniqeID();

            _AppendSearchForRecordFunctions();

            _AppendAddNewFunctions(UniqPar);
            _AppenUpdateFunction(UniqPar);
            _AppendGetAllRowsFunction();
            _AppendGetNumberOfRows(UniqPar);
            _AppendDeleteRows(UniqPar);
            _AppendDoesRowExistFunc(UniqPar);
        }



        public static string Generate(clsMainComponents mainComponents)
        {
            _MainComponents = mainComponents;

            _Initialize();
            _AppendMainFunctions();
            _Uninitialize();

            return _Source.ToString();
        }

    }
}
