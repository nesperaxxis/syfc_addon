using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SYFC_AddOn.Classes
{
    public static class CommonFunction
    {
        public static string GetSingleValue(string StrQuery)
        {
            try
            {
                Recordset oRecSet = default(Recordset);
                oRecSet = (Recordset)Program.oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                oRecSet.DoQuery(StrQuery);
                return Convert.ToString(oRecSet.Fields.Item(0).Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
