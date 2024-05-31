using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceGenerator_Core.Business_Gen
{
    public partial class clsBusinessLayerGen
    {

        //appending the main properties

        public static void AppendMainProperties()
        {
            //appending the mode for updating and adding
            _Source.AppendLine($@"public enum enMode {{eAddNew = 0,eUpdate = 1}}
                             public enMode mode = enMode.eAddNew;");

            //appending main porperties
            _Source.AppendLine($@"

                {clsGenCore.GetMainBusinessLayerProperties(_MainComponents.GetAllParameters())}

                      ");





        }
        
        /// <summary>
        /// this function appends the initilizer constructor for creting new object to ADD in the data base
        /// </summary>
        public static void AppendInitConstruct()
        {
            _Source.AppendLine($@"public {_MainComponents.ClassName}()
                            {{
                               {clsGenCore.GetInitClassForBuisnessLayer(_MainComponents.GetAllParameters())}
                                mode = enMode.eAddNew;
                             }}");

        }

        /// <summary>
        /// this function appends a constructor for updaing an exited object to update a row in the data base
        /// </summary>
        public static void AppendConstruct()
        {
            _Source.AppendLine($@" 
                          private {_MainComponents.ClassName} {
                clsGenCore.GetParametersFormatForUpdateFunc(_MainComponents.GetAllParameters())}
                {{

                    {clsGenCore.GetConstructBodyForBuisnessLayer(_MainComponents.GetAllParameters())}
                     mode = enMode.eUpdate;

                }}

                  ");
        }

        /// <summary>
        /// this function appends to the source the function that adds a new rocord to the data base
        /// </summary>
        public static void AppendAddNewFunction()
        {
            _Source.AppendLine($@"
                    bool _AddNewRow()
                           {{

                    this.{_UniqePar.Name} = {_DataAccessClassName}.AddNewRow{
                clsGenCore.GetParsForAdd_UpdateRowFunc(_MainComponents.GetAllParameters(), true)};

                return this.{_UniqePar.Name} != -1;

                }}");
        }

        /// <summary>
        /// this function appends to the source the function that Updates a rocord in the data base
        /// </summary>
        public static void AppendUpdateFunction()
        {
            _Source.AppendLine($@"
                    bool _UpdateRow()
                           {{

                    return {_DataAccessClassName}.UpdateRow{
                clsGenCore.GetParsForAdd_UpdateRowFunc(_MainComponents.GetAllParameters(), false)};


                }}");
        }

        public static void AppendFindFunction(clsMainComponents.stParameter SearchByPar)
        {
            _Source.AppendLine($@"
                     public static {_MainComponents.ClassName} FindBy{SearchByPar.Name}({SearchByPar.Type} {SearchByPar.Name})
                     {{

                            {clsGenCore.GetInitilizingVariablesText(_MainComponents.GetAllParameters(), SearchByPar)}

                        if ({_DataAccessClassName}.GetRowInfoBy{SearchByPar.Name}{clsGenCore.GetParsForDataAccessSearch(SearchByPar, _MainComponents.GetAllParameters(), false)})
                     {{

                          return new {_MainComponents.ClassName}{clsGenCore.GetAllParsToInitClassConstruct(_MainComponents.GetAllParameters())};
                        }}
                         else
                             return null;
                      }}



                    ");
        }

        public static void AppendAllFindFunctions()
        {
            foreach(clsMainComponents.stParameter Par in _MainComponents.GetAllParameters())
            {
                if (Par.SearchBy)
                    AppendFindFunction(Par);
            }
        }



        /// <summary>
        /// this functions appends the rest of the functions lke Delete row, GetNumberOfRows..etc
        /// </summary>
        public static void AppendTheRestOfTheFunctions()
        {
            _Source.AppendLine($@"
                     
        public static DataTable GetAllRows()
        {{
            DataTable DT = {_DataAccessClassName}.GetAllRows();
            return DT;
        }}

        public static int GetNumberOfRows()
        {{
            return {_DataAccessClassName}.GetNumberOfRows();
        }}

        public static bool DeleteRow({_UniqePar.Type} {_UniqePar.Name})
        {{
            return ({_DataAccessClassName}.DeleteRow({_UniqePar.Name}));
        }}

        public static bool DoesRowExist({_UniqePar.Type} {_UniqePar.Name})
        {{
            return ({_DataAccessClassName}.DoesRowExist({_UniqePar.Name}));
        }}

        public bool Save()
        {{
            switch (mode)
            {{
                case enMode.eAddNew:
                    {{
                        if (_AddNewRow())
                        {{
                            mode = enMode.eUpdate;
                            return true;
                        }}
                        else
                            return false;

                    }}
                case enMode.eUpdate:

                    return _UpdateRow();

            }}

            return false;
        }}



");
        }

    }
}
