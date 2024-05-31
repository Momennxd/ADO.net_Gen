using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SourceGenerator_Core
{
    internal static class clsGenCore
    {

        //get row info
        public static StringBuilder StringBuilderJoin(string Seperator, StringBuilder[] arrValues)
        {
            StringBuilder sVal = new StringBuilder();
            for (int i = 0; i < arrValues.Length; i++)
            {
                sVal.Append(arrValues[i]);

                if (i < arrValues.Length - 1)
                {
                    sVal.Append(Seperator);
                    sVal.Append(" ");
                }

            }

            return sVal;
        }

        public static StringBuilder StringBuilderJoin(string Seperator, string[] arrValues)
        {
            StringBuilder sVal = new StringBuilder();
            for (int i = 0; i < arrValues.Length; i++)
            {
                sVal.Append(arrValues[i]);

                if (i < arrValues.Length - 1)
                {
                    sVal.Append(Seperator);
                    sVal.Append(" ");
                }

            }

            return sVal;
        }


        public static StringBuilder GetParsForDataAccessSearch(clsMainComponents.stParameter SearchPar,
                                            clsMainComponents.stParameter[] Pars, bool AppendType = true)
        {
            StringBuilder sParameters = new StringBuilder();
            sParameters.Append("(");

            StringBuilder[] arrNonUniqePars = new StringBuilder[Pars.Length];

            //this loop adds the parameters to the 'arrNonUniqePars' and they are ready to 
            //be appended to the main 'sParameters'
            for (int i = 0; i < Pars.Length;i ++)
            {
                StringBuilder ParText = new StringBuilder();
                if (Pars[i].ID != SearchPar.ID)
                    ParText.Append("ref ");

                if (AppendType) ParText.Append(Pars[i].Type);
                ParText.Append(" ");
                ParText.Append(Pars[i].Name);

                arrNonUniqePars.SetValue(ParText, i);

            }

            sParameters.Append(StringBuilderJoin(",", arrNonUniqePars));
            sParameters.Append(")");

            return sParameters;

        }

        public static StringBuilder GetDataTransferFromReader(clsMainComponents.stParameter SearchPar,
                                            clsMainComponents.stParameter[] Pars)
        {
            StringBuilder sDataTransLine = new StringBuilder();

            for (int i = 0;i < Pars.Length;i ++)
            {
                if (Pars[i].ID != SearchPar.ID)
                {
                    if (!Pars[i].Nullable)
                        sDataTransLine.AppendLine(
                            $"{Pars[i].Name} = ({Pars[i].Type})Reader[\"{Pars[i].Name}\"];");
                    else
                    {                   
                        sDataTransLine.AppendLine($@"
                        if (Reader[""{Pars[i].Name}""] != DBNull.Value)
                        {{
                            {Pars[i].Name} = ({Pars[i].Type})Reader[""{Pars[i].Name}""];
                        }}");
                    }
                }
            }

            return sDataTransLine;

        }

        //add new row

        public static StringBuilder GetParametersFormatForAddNewFunc(clsMainComponents.stParameter[] Pars, bool AppendType)
        {
            StringBuilder sParameters = new StringBuilder();
            sParameters.Append("(");

            List<StringBuilder> arrNonUniqePars = new List<StringBuilder>();

            //this loop adds the parameters to the 'arrNonUniqePars' and they are ready to 
            //be appended to the main 'sParameters'
            for (int i = 0; i < Pars.Length; i++)
            {
                if (!Pars[i].IsPK)
                {
                    StringBuilder ParText = new StringBuilder();
                    if (AppendType) ParText.Append(Pars[i].Type);
                    ParText.Append(" ");
                    ParText.Append(Pars[i].Name);
                    arrNonUniqePars.Add(ParText);
                }

            }

            sParameters.Append(StringBuilderJoin(",", arrNonUniqePars.ToArray()));
            sParameters.Append(")");

            



            return sParameters;

        }

        /// <summary>
        /// this function gets the parameters of the query that adds new rows to a table
        /// </summary>
        /// <param name="Values">
        /// determine if the function returns parameters with @ sign or not
        /// </param>
        /// <returns></returns>
        public static StringBuilder GetAddNewQueryParameters(clsMainComponents.stParameter[] Pars, bool Values)
        {
            StringBuilder sQuery = new StringBuilder();
            sQuery.Append("(");
            List<StringBuilder> arrNonUniqePars = new List<StringBuilder>();
            StringBuilder ParText = new StringBuilder();

            if (!Values)
            {
                for (int i = 0; i < Pars.Length; i++)
                {
                    if (!Pars[i].IsPK)
                    {
                        ParText.Append(Pars[i].Name);
                        arrNonUniqePars.Add(ParText);
                        ParText = new StringBuilder();
                    }
                }
            }
            else
            {
                for (int i = 0; i < Pars.Length; i++)
                {
                    if (!Pars[i].IsPK)
                    {
                        ParText.Append("@");
                        ParText.Append(Pars[i].Name);
                        arrNonUniqePars.Add(ParText);
                        ParText = new StringBuilder();

                    }
                }
            }

            sQuery.Append(StringBuilderJoin(",", arrNonUniqePars.ToArray()));
            sQuery.Append(")");
            return sQuery;

        }


        public static StringBuilder GetAddingValuesToCommandPars(clsMainComponents.stParameter[] ParsToAdd)
        {
            StringBuilder sDataTransLine = new StringBuilder();

            for (int i = 0; i < ParsToAdd.Length; i++)
            {

                if (!ParsToAdd[i].Nullable)
                    sDataTransLine.AppendLine(
                        $"Command.Parameters.AddWithValue(\"@{ParsToAdd[i].Name}\", {ParsToAdd[i].Name});");
                else
                {
                    sDataTransLine.AppendLine($@"
                        if ({ParsToAdd[i].Name} != null && {ParsToAdd[i].Name}.ToString() != string.Empty)
                Command.Parameters.AddWithValue(""@{ParsToAdd[i].Name}"", {ParsToAdd[i].Name});
                        else
                Command.Parameters.AddWithValue(""@{ParsToAdd[i].Name}"", DBNull.Value);");
                }
                
            }

            return sDataTransLine;

        }



        //update row
        public static StringBuilder GetParametersFormatForUpdateFunc(clsMainComponents.stParameter[] Pars)
        {
            StringBuilder sParameters = new StringBuilder();
            sParameters.Append("(");

            List<StringBuilder> arrNonUniqePars = new List<StringBuilder>();

            //this loop adds the parameters to the 'arrNonUniqePars' and they are ready to 
            //be appended to the main 'sParameters'
            for (int i = 0; i < Pars.Length; i++)
            {
                
                StringBuilder ParText = new StringBuilder();
                ParText.Append(Pars[i].Type);
                ParText.Append(" ");
                ParText.Append(Pars[i].Name);
                arrNonUniqePars.Add(ParText);
                

            }

            sParameters.Append(StringBuilderJoin(",", arrNonUniqePars.ToArray()));
            sParameters.Append(")");





            return sParameters;

        }

        


        public static StringBuilder GetUpdateRowQuery(clsMainComponents MainCompos)
        {
            StringBuilder Query = new StringBuilder();

            Query.AppendLine($@"UPDATE {MainCompos.TableName} SET ");
            for (int i = 0;i < MainCompos.GetParametersLength();i++)
            {
                if (!MainCompos.GetParameter(i).IsPK)
                {
                    if (i < MainCompos.GetParametersLength() - 1)
                        Query.AppendLine("\t\t" + MainCompos.GetParameter(i).Name + " = @" +
                            MainCompos.GetParameter(i).Name + ",");
                    else
                        Query.AppendLine("\t\t" + MainCompos.GetParameter(i).Name + " = @" +
                            MainCompos.GetParameter(i).Name);

                }
               
            }

            clsMainComponents.stParameter Par = MainCompos.GetUniqeID();
            Query.AppendLine($"\t\t WHERE {Par.Name} = @{Par.Name}");
            return Query;
        }



        //business layer :

        /// <summary>
        /// this functions gets the main properties for the business layer for example
        /// firstName if the class had it as a property
        /// </summary>
        /// <returns></returns>
        public static StringBuilder GetMainBusinessLayerProperties(clsMainComponents.stParameter[] Pars)
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < Pars.Length ; i++)
            {
                sb.AppendLine($@"public {Pars[i].Type} {Pars[i].Name} {{ get; set; }}");
            }

            return sb;

        }

        /// <summary>
        /// this functions takes a varibale type in string format and gets the init value
        /// </summary>
        /// <param name="VarType">
        /// Varibale type
        /// </param>
        /// <returns>
        /// the initilizing value
        /// </returns>
        public static string GetInitValue(string VarType)
        {            
            switch (VarType)
            {
                case "string":
                    return $@"""""";
                case "DateTime":
                    return "DateTime.MinValue";
                case "char":
                    return "char.MinValue";
                case "bool":
                    return "false";
                case "byte":
                    return "0";
                default:
                    return "-1";

            }

        }


        public static string GetInitClassForBuisnessLayer(clsMainComponents.stParameter[] Pars)
        {
            StringBuilder InitilizedProperties = new StringBuilder();


            for ( int i = 0; i < Pars.Length; i++ )
            {
                InitilizedProperties.AppendLine($@"{Pars[i].Name} = {GetInitValue(Pars[i].Type)};");
            }

            return InitilizedProperties.ToString();

        }

        /// <summary>
        /// this functions gets the body of the constructure that sets the all the properties 
        /// it's used to update the current used object
        /// </summary>
        /// <param name="Pars">
        /// Properties to set
        /// </param>
        /// <returns>
        /// constructor body
        /// </returns>
        public static string GetConstructBodyForBuisnessLayer(clsMainComponents.stParameter[] Pars)
        {
            StringBuilder ConstrucBody = new StringBuilder();

            for (int i = 0; i < Pars.Length; i++)
            {
                ConstrucBody.AppendLine($@"this.{Pars[i].Name} = {Pars[i].Name};");
            }

            return ConstrucBody.ToString();
        }


        /// <summary>
        /// this functions gets all the paramters in the right format ex-> "this.FirstName"  
        /// for adding a new row function
        /// </summary>
        /// <param name="Pars"></param>
        /// <returns></returns>
        public static string GetParsForAdd_UpdateRowFunc(clsMainComponents.stParameter[] Pars, bool Add)
        {
            List<string> ParsFormatList = new List<string> ();

            //IMPORTANT
            //redunduncy in the code but efficincy in the speed to avoid checking
            //if the add is true each iteration
            //adding all the parameters except the Primary Key
            if (Add)
            {
                for (int i = 0; i < Pars.Length; i++)
                {
                    if (!Pars[i].IsPK)
                        ParsFormatList.Add($@"this.{Pars[i].Name}");
                }
            }
            else
            {
                for (int i = 0; i < Pars.Length; i++)
                {
                    ParsFormatList.Add($@"this.{Pars[i].Name}");
                }
            }

            return "(" + StringBuilderJoin(",", ParsFormatList.ToArray()) + ")";
        }

        /// <summary>
        /// this function gets the Initilizing Variables Text for finding a row in the business layer
        /// </summary>
        /// <param name="SearchByPar"></param>
        /// <returns>
        /// </returns>
        public static string GetInitilizingVariablesText(clsMainComponents.stParameter[] Properties,
            clsMainComponents.stParameter SearchByPar)
        {
            StringBuilder InitVarText = new StringBuilder();

            for (int i = 0; i < Properties.Length; i++)
            {
                if (Properties[i].ID != SearchByPar.ID)
                {
                    InitVarText.AppendLine(
                    $@"{Properties[i].Type} {Properties[i].Name} = {clsGenCore.GetInitValue(Properties[i].Type)};");
                }
                
            }

            return InitVarText.ToString();
        }

        /// <summary>
        /// this function gets the parameters format to init the class main constructor 
        /// </summary>
        /// <returns></returns>
        public static string GetAllParsToInitClassConstruct(clsMainComponents.stParameter[] Properties)
        {
            string[] PropertiesName = new string[Properties.Length];
            for (int i = 0; i < Properties.Length; i++)
            {
                PropertiesName[i] = Properties[i].Name;
            }

            return "(" + StringBuilderJoin(",", PropertiesName).ToString() + ")";
        }




    }
}