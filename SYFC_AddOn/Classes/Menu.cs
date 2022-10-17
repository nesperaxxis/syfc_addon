using System;
using System.Collections.Generic;
using System.Text;

namespace SYFC_AddOn.Classes
{
    public static class Menu
    {
        public static void Create()
        {
            string _code = "AddOn";
            string _name = "AOR AddOn";

            if (Program.oApplication.Menus.Exists(_code)) Program.oApplication.Menus.RemoveEx(_code);
            Program.oApplication.Menus.Item("43520").SubMenus.Add(_code,_name, SAPbouiCOM.BoMenuType.mt_POPUP, 99);

            if (Program.oApplication.Menus.Exists("AOR")) Program.oApplication.Menus.RemoveEx("AOR");
            Program.oApplication.Menus.Item(_code).SubMenus.Add("AOR", "Approval of Requirement", SAPbouiCOM.BoMenuType.mt_STRING, 99);

            if (Program.oApplication.Menus.Exists("AORRpt")) Program.oApplication.Menus.RemoveEx("AORRpt");
            Program.oApplication.Menus.Item(_code).SubMenus.Add("AORRpt", "Approval of Requirement Listing", SAPbouiCOM.BoMenuType.mt_STRING, 99);

            if (Program.oApplication.Menus.Exists("AORSetup")) Program.oApplication.Menus.RemoveEx("AORSetup");
            Program.oApplication.Menus.Item(_code).SubMenus.Add("AORSetup", "AOR Default Setup", SAPbouiCOM.BoMenuType.mt_STRING, 99);
        }
    }
}
