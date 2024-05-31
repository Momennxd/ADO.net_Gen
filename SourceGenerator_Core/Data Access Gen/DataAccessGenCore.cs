using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceGenerator_Core
{
    public partial class DataAccessGen
    {

        //get row info
        /// <summary>
        /// this function appends the functions that search for a record in the database based on the uniqe keys
        /// Note that : you can't search for record by a Non uniqe key
        /// </summary>
        private static void _AppendSearchForRecordFunctions()
        {
            foreach (clsMainComponents.stParameter Parameter in _MainComponents.GetAllParameters())
            {
                if (Parameter.SearchBy)
                {
                    _AppendSearchForRecordFunc(Parameter);
                }
            }
        }

        private static void _AppendSearchForRecordFunc(clsMainComponents.stParameter UniqeParameter)
        {
            _Source.AppendLine(_GetSearchForRecordFuncHeader(UniqeParameter).ToString());
            _Source.AppendLine(_GetSearchForRecordFuncBody1(UniqeParameter).ToString());
            _Source.AppendLine(_GetSearchForRecordFuncBody2(UniqeParameter).ToString());
            _Source.AppendLine();
        }


        private static StringBuilder _GetSearchForRecordFuncHeader(clsMainComponents.stParameter UniqeParameter)
        {
            StringBuilder FunctionsHeader = new StringBuilder();

            FunctionsHeader.Append($"\tpublic static bool GetRowInfoBy{UniqeParameter.Name}");
            FunctionsHeader.Append(clsGenCore.GetParsForDataAccessSearch(UniqeParameter,
                _MainComponents.GetAllParameters()));
            FunctionsHeader.AppendLine("{");

            return FunctionsHeader;
        }

        /// <summary>
        /// this function gets the first part of the function body before the "try catch"
        /// </summary>
        /// <param name="UniqeParameter">is the column that is used to searche for a row</param>
        /// <returns></returns>
        private static StringBuilder _GetSearchForRecordFuncBody1(clsMainComponents.stParameter UniqeParameter)
        {
            StringBuilder FunctionBody = new StringBuilder();

            FunctionBody.AppendLine(

                  $@"           bool IsFound = false;
                  
                  string connectionString = ""{_MainComponents.ConnectionString}"";
                  SqlConnection connection = new SqlConnection(connectionString);
                  
                  string Query = ""SELECT * FROM {_MainComponents.TableName} WHERE {UniqeParameter.Name} = @{UniqeParameter.Name}"";
                  
                  SqlCommand Command = new SqlCommand(Query, connection);
                  
                  Command.Parameters.AddWithValue(""@{UniqeParameter.Name}"", {UniqeParameter.Name});"
                               
                  );


            return FunctionBody;
        }

        /// <summary>
        /// this function gets the rest of the function body starting by the "try catch"
        /// </summary>
        /// <param name="UniqeParameter"> is the column that is used to searche for a row</param>
        /// <returns></returns>
        private static StringBuilder _GetSearchForRecordFuncBody2(clsMainComponents.stParameter UniqeParameter)
        {
            StringBuilder FunctionBody = new StringBuilder();

            FunctionBody.AppendLine($@"           try
            {{
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {{
                    IsFound = true;
                    {clsGenCore.GetDataTransferFromReader(UniqeParameter, _MainComponents.GetAllParameters())}
                    
                }}

                Reader.Close();

            }}
            catch (Exception ex)
            {{
                //
            }}
            finally
            {{
                connection.Close();
            }}

            return IsFound;


             }}");

            
            return FunctionBody;
        }



        //add new row

        static clsMainComponents.stParameter[] _GetAddNewFunToAddPars()
        {
            List<clsMainComponents.stParameter> ParsToAdd = new List<clsMainComponents.stParameter> ();
              
            for (int i = 0; i < _MainComponents.GetParametersLength(); i++)
            {
                if (!_MainComponents.GetParameter(i).IsPK)
                {
                    ParsToAdd.Add(_MainComponents.GetAllParameters()[i]);
                }
                    
            }

            return ParsToAdd.ToArray();

        }

        private static void _AppendAddNewFunctions(clsMainComponents.stParameter UniqeParameter)
        {
            StringBuilder AddNewText = new StringBuilder();

            AddNewText.Append($"\tpublic static int AddNewRow");
            AddNewText.Append(clsGenCore.GetParametersFormatForAddNewFunc(_MainComponents.GetAllParameters(), true));
            AddNewText.AppendLine("{");

            AddNewText.Append($@"
            {UniqeParameter.Type} {UniqeParameter.Name} = -1;
            
            string connectionString = ""{_MainComponents.ConnectionString}"";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query =  @""INSERT INTO {_MainComponents.TableName} 
                               {clsGenCore.GetAddNewQueryParameters(_MainComponents.GetAllParameters(), false)}     
                             VALUES
                               {clsGenCore.GetAddNewQueryParameters(_MainComponents.GetAllParameters(), true)}
                              SELECT SCOPE_IDENTITY();"";

            SqlCommand Command = new SqlCommand(Query, connection);

            {clsGenCore.GetAddingValuesToCommandPars(_GetAddNewFunToAddPars())}

             try
             {{
                 connection.Open();
             
                 object Result = Command.ExecuteScalar();
             
                 if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                 {{
                     {UniqeParameter.Name} = InsertedID;
                 }}
             
             }}
             catch (Exception ex)
             {{
                 //
             }}
             finally
             {{
                 connection.Close();
             }}
             
             
             return {UniqeParameter.Name};

        }}");

            _Source.Append(AddNewText);

        }



        //update row

        private static void _AppenUpdateFunction(clsMainComponents.stParameter UniqeParameter)
        {
            StringBuilder UpdateFunText = new StringBuilder();

            UpdateFunText.Append($"\tpublic static bool UpdateRow");
            UpdateFunText.Append(clsGenCore.GetParametersFormatForUpdateFunc(_MainComponents.GetAllParameters()));
            UpdateFunText.AppendLine($@"{{
                            
           int RowsAffected = 0;

            string connectionString = ""{_MainComponents.ConnectionString}"";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = $@""{clsGenCore.GetUpdateRowQuery(_MainComponents)}"";


            SqlCommand Command = new SqlCommand(Query, connection);


            {clsGenCore.GetAddingValuesToCommandPars(_MainComponents.GetAllParameters())}

            try
            {{
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }}
            catch (Exception ex)
            {{
                return false;
            }}
            finally
            {{
                connection.Close();
            }}

            return (RowsAffected > 0);

        }} ");


            _Source.Append(UpdateFunText);


        }


        //get all rows
        private static void _AppendGetAllRowsFunction()
        {

            _Source.AppendLine($@"
             public static DataTable GetAllRows() {{

            DataTable DT = new DataTable();

           string connectionString = ""{_MainComponents.ConnectionString}"";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = @""SELECT * FROM {_MainComponents.TableName}"";

            SqlCommand Command = new SqlCommand(Query, connection);

            try
            {{
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.HasRows)
                {{
                    DT.Load(Reader);
                }}

                Reader.Close();


            }}
            catch (Exception ex)
            {{
                //
            }}
            finally
            {{
                connection.Close();
            }}

            return DT;

            }}");

        }


        //get number of rows

        private static void _AppendGetNumberOfRows(clsMainComponents.stParameter UniqeParameter)
        {

            _Source.AppendLine($@"
        public static int GetNumberOfRows()
        {{
            int NumberOfRows = -1;

           string connectionString = ""{_MainComponents.ConnectionString}"";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = ""SELECT Count(*) FROM {_MainComponents.TableName} WHERE {UniqeParameter.Name} is not null"";

            SqlCommand Command = new SqlCommand(Query, connection);

            try
            {{
                connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int AcualNum))
                {{
                    NumberOfRows = AcualNum;
                }}


            }}
            catch (Exception ex)
            {{
                //
            }}
            finally
            {{
                connection.Close();
            }}

            return NumberOfRows;
            }}
");
        }

        //delete row
        private static void _AppendDeleteRows(clsMainComponents.stParameter UniqeParameter)
        {

            _Source.AppendLine($@" public static bool DeleteRow({UniqeParameter.Type} {UniqeParameter.Name})
        {{

            int RowsAffected = 0;

           string connectionString = ""{_MainComponents.ConnectionString}"";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = ""DELETE {_MainComponents.TableName} WHERE {UniqeParameter.Name} = @{UniqeParameter.Name}"";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue(""@{UniqeParameter.Name}"", {UniqeParameter.Name});


            try
            {{
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }}
            catch (Exception ex)
            {{
                //
            }}
            finally
            {{
                connection.Close();
            }}

            return (RowsAffected > 0);

}}


");
        }


        //does row exist
        private static void _AppendDoesRowExistFunc(clsMainComponents.stParameter UniqeParameter)
        {

            _Source.AppendLine($@" public static bool DoesRowExist({UniqeParameter.Type} {UniqeParameter.Name})
        {{
            bool IsFound = false;

            string connectionString = ""{_MainComponents.ConnectionString}"";
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = ""SELECT Found=1 FROM {_MainComponents.TableName} WHERE {UniqeParameter.Name} = @{UniqeParameter.Name}"";

            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue(""@{UniqeParameter.Name}"", {UniqeParameter.Name});


            try
            {{
                connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null)
                {{
                    IsFound = true;
                }}

            }}
            catch (Exception ex)
            {{
                //
            }}
            finally
            {{
                connection.Close();
            }}

            return IsFound;
        }}");
        }

    }
}
