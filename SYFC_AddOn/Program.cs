using SYFC_AddOn.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SYFC_AddOn
{
    static class Program
    {

        public static SAPbobsCOM.Company oCompany;
        public static SAPbouiCOM.Application oApplication = null;
        public static SAPbobsCOM.Recordset oRecSet;
        public static int lErrCode = 0;
        public static int lRetCode = 0;
        public static int sDefaultValidDays = 30;
        public static string sDefaultTax = "NP";
        public static string sDefaultWhs = "MAIN";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Connect.ConnectUI();
                Connect.ConnectDI();
                Menu.Create();
                UDO.Create();
                SBOEvents.Initialize();

                Program.oApplication.StatusBar.SetText("Connected Successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Program.oApplication.StatusBar.SetText($"{(ex.InnerException?.Message ?? ex.Message)}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }

        
    }
}
