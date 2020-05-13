using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Direct.Shared;
using log4net;
using Direct.Shared.DataTableLibrary;
using System.Data;

namespace Direct.DataTableExtended.Library
{
    [DirectDom("DataTable Extended", "General")]
    public class DTExt : DirectDataTable 
    {
        private static readonly ILog logArchitect = LogManager.GetLogger(Loggers.LibraryObjects);

        public DTExt()
        {
            
        }

        public DTExt(Direct.Shared.IProject project) :
                base(project)
        {
        }

        [DirectDom("Add Column to datatable")]
        [DirectDomMethod("Add column {column} of type {type}")]
        [MethodDescriptionAttribute("Add a column of type (Text, Boolean, DateTime, Decimal or Number), make sure to use the exact spelling")]
        public bool AddColumnManual(string columname, string columntype)
        {         
            try
            {
                this.AddColumn(columname, columntype);
                if (logArchitect.IsDebugEnabled) { logArchitect.Debug("Direct.DataTableExtended.Library - Column Added: " + columname + " of type: " + columntype); }
                return true;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.DataTableExtended.Library -  Add Column Exception: ", e);
                return false;
            }
        }

        [DirectDom("Get Column Names")]
        [DirectDomMethod("Get column names")]
        [MethodDescriptionAttribute("Get all column names in sequence")]
        public DirectCollection<string> GetColumnNames()
        {
            try
            {
                DirectCollection<string> listOfColumns = new DirectCollection<string>();
                foreach (DataColumn column in this.DataTableWrapper.Columns)
                {
                    listOfColumns.Add(column.ColumnName);
                    if (logArchitect.IsDebugEnabled) { logArchitect.Debug("Direct.DataTableExtended.Library - Get Column: " + column.ColumnName); }
                }
                return listOfColumns;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.DataTableExtended.Library - Get Column Names - Exception: ", e);
                return null;
            }
        }

        [DirectDom("Delete Rows")]
        [DirectDomMethod("Delete all rows")]
        [MethodDescriptionAttribute("Delete all rows")]
        public bool DeleteAllRows()
        {
            try
            {
                this.DataTableWrapper.Rows.Clear();
                if (logArchitect.IsDebugEnabled) { logArchitect.Debug("Direct.DataTableExtended.Library - Rows Cleared"); }
                return true;
            }
            catch (Exception e)
            {
                logArchitect.Error("Direct.DataTableExtended.Library - Delete All Rows - Exception: ", e);
                return false;
            }
        }
    }
}
