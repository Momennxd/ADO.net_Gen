using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGenerator_Core
{
    public class clsMainComponents
    {

        public struct stParameter
        {
            public int ID {  get; set; }

            public string Type { get; set; }

            public string Name {  get; set; }

            /// <summary>
            /// this property represents the Uniqe Keys in a table which could be searched by for a record.
            /// </summary>
            public bool SearchBy { get; set; }

            /// <summary>
            /// represents if the attribute is  Primary Key
            /// </summary>
            public bool IsPK { get; set; }

            public bool Nullable { get; set; }
         
        }

        private int _ParIDCounter = 1;


        /// <summary>
        /// this property is set private to prevent any errors while creating an ID 
        /// to the creating of the ID happens inside the object in the GetParameter() function
        /// </summary>
        private List<stParameter> _Parameters = new List<stParameter>();

        public string NameSpace {  get; set; }

        public string ClassName { get; set; }

        public string TableName { get; set; }
       
        public string ConnectionString { get; set; }

        public stParameter GetUniqeID()
        {
      
            for (int i = 0; i < _Parameters.Count; i++)
            {
                if (_Parameters[i].IsPK)
                    return _Parameters[i];
            }
        
            return _Parameters[0];
        }

        /// <summary>
        /// this functions adds a paramerter to the Parameters struct by using try catch method
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Type"></param>
        /// <param name="Name"></param>
        /// <param name="SearchBy">
        /// is the column used to search by in the table note that it has to be uniqe 
        /// default value is ID
        /// </param> 
        /// <param name="IsPK"></param>
        /// <param name="Nullable"></param>
        /// <returns></returns>
        public bool AddParamerter(string Type, string Name, bool SearchBy, bool IsPK, bool Nullable)
        {
            stParameter sPar = new stParameter();
            sPar.ID = _ParIDCounter;
            sPar.Type = Type;
            sPar.Name = Name;
            sPar.SearchBy = SearchBy;
            sPar.IsPK = IsPK;
            sPar.Nullable = Nullable;

            try
            {
                _Parameters.Add(sPar);
                _ParIDCounter++;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public stParameter GetParameter(int Index)
        {
            return _Parameters[Index];
        }

        public int GetParametersLength()
        {
            return this._Parameters.Count;
        }

        public stParameter[] GetAllParameters()
        {
            return this._Parameters.ToArray();
        }


        public clsMainComponents(string TableName, string NameSpace, string ClassName, string ConnectionString) 
        { 
            this.TableName = TableName;
            this.NameSpace = NameSpace;
            this.ClassName = ClassName;
            this.ConnectionString = ConnectionString;
        }

        public clsMainComponents()
        {
            this.TableName = "";
            this.NameSpace = "";
            this.ClassName = "";
            this.ConnectionString = "";

        }

    }
}
