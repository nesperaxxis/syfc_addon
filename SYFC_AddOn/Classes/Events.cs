using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Text;

namespace SYFC_AddOn.Classes
{
    public static class SBOEvents
    {
        public static void Initialize()
        {

            Program.oApplication.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(OApplication_MenuEvent);
            Program.oApplication.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(OApplication_AppEvent);
            Program.oApplication.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(OApplication_ItemEvent);

            //var objFormCreationParams = new SAPbouiCOM.FormCreationParams();
            //var oXML = new System.Xml.XmlDocument();
            //oXML.Load(@"D:\Axxis\AddOn\UI_AddOn\AORReportForm.txt");
            //objFormCreationParams = (SAPbouiCOM.FormCreationParams)(Program.oApplication.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_FormCreationParams));
            //objFormCreationParams.XmlData = oXML.InnerXml;
            //objFormCreationParams.FormType = "MyFormType";
            //objFormCreationParams.UniqueID = "AORReportFrm";
            //Program.oApplication.Forms.AddEx(objFormCreationParams);

        }

        public static void OApplication_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {

        }
        public static void OApplication_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.BeforeAction == false && pVal.MenuUID == "AOR")
            {
                var form = Program.oApplication.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "AOR", "");
            }
            if (pVal.BeforeAction == false && pVal.MenuUID == "AORSetup")
            {
                var form = Program.oApplication.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "AORSetup", "");
            }
            if (pVal.BeforeAction == false && pVal.MenuUID == "AORRpt")
            {
                var form = Program.oApplication.OpenForm(SAPbouiCOM.BoFormObjectEnum.fo_UserDefinedObject, "AORRpt", "");
            }
        }
        public static void OApplication_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.FormTypeEx == "UDO_FT_AOR" &&  (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_ACTIVATE || pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_KEY_DOWN))
            {
                var oForm = Program.oApplication.Forms.Item(FormUID);
                SAPbouiCOM.Button btnReject = (SAPbouiCOM.Button)oForm.Items.Item("Item_13").Specific;
                SAPbouiCOM.Button btnRevert = (SAPbouiCOM.Button)oForm.Items.Item("Item_14").Specific;
                SAPbouiCOM.Button btnApprove = (SAPbouiCOM.Button)oForm.Items.Item("Item_5").Specific;
                SAPbouiCOM.Button btnForApprove = (SAPbouiCOM.Button)oForm.Items.Item("Item_17").Specific;
                SAPbouiCOM.EditText AORStatusTxt = (SAPbouiCOM.EditText)oForm.Items.Item("25_U_E").Specific;
                SAPbouiCOM.EditText selectedUser = (SAPbouiCOM.EditText)oForm.Items.Item("20_U_E").Specific;

                

                var docStatus = AORStatusTxt.Value?.ToString() ?? "open";
                btnApprove.Item.Visible = false;
                btnRevert.Item.Visible = false;
                btnReject.Item.Visible = false;
                btnForApprove.Item.Visible = false;

                if (String.IsNullOrEmpty(selectedUser.Value))
                {
                    return;
                }

                var currentUserType = CommonFunction.GetSingleValue($"SELECT \"U_AORUType\" FROM \"OUSR\" WHERE \"USER_CODE\" = '{Program.oApplication.Company.UserName ?? ""}'") ?? "";
                var selectedUserPreApproved = CommonFunction.GetSingleValue($"SELECT \"U_AORUType\" FROM \"OUSR\" WHERE \"USER_CODE\" = '{Program.oApplication.Company.UserName ?? ""}'") ?? "";


                if ((oForm.Mode == BoFormMode.fm_VIEW_MODE || oForm.Mode == BoFormMode.fm_UPDATE_MODE || oForm.Mode == BoFormMode.fm_OK_MODE))
                {
                    switch (docStatus.ToLower())
                    {
                        case "open":
                            btnRevert.Item.Visible = true;
                            break;
                        case "for approval":
                            btnRevert.Item.Visible = true;
                            btnReject.Item.Visible = true;
                            break;
                    }
                }
                if (!(oForm.Mode == BoFormMode.fm_VIEW_MODE && oForm.Mode == BoFormMode.fm_UPDATE_MODE))
                {                             
                    
                    switch (docStatus.ToLower())
                    {
                        case "for approval":
                        case "rejected":
                            btnForApprove.Item.Visible = true;
                            btnRevert.Item.Visible = true;
                            break;
                    }
                }
            }
            if (pVal.FormTypeEx == "UDO_FT_AOR" && pVal.BeforeAction == false && pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "20_U_E")
            {
                if (pVal.Before_Action == false)
                {
                    var oForm = Program.oApplication.Forms.Item(FormUID);
                    SAPbouiCOM.IChooseFromListEvent ev = (SAPbouiCOM.IChooseFromListEvent)pVal;
                    SAPbouiCOM.ChooseFromList chooser = oForm.ChooseFromLists.Item(ev.ChooseFromListUID);
                    DataTable dataTable = ev.SelectedObjects;
                    if (dataTable != null)
                    {
                        string code = (string)dataTable.GetValue("USER_CODE", 0);
                        string name = (string)dataTable.GetValue("U_NAME", 0);
                        int dept = (int)dataTable.GetValue("Department", 0);
                        int branch = (int)dataTable.GetValue("Branch", 0);
                        var myDBDataSource = oForm.DataSources.DBDataSources.Item("@AOR");
                        int.TryParse(CommonFunction.GetSingleValue("SELECT TOP 1 \"U_VldUntl\" FROM \"@AORSETUP\" ORDER BY \"CreateDate\" DESC"), out Program.sDefaultValidDays);
                        Program.sDefaultTax = CommonFunction.GetSingleValue("SELECT TOP 1 \"U_DefaultTax\" FROM \"@AORSETUP\" ORDER BY \"CreateDate\" DESC");
                        Program.sDefaultWhs = CommonFunction.GetSingleValue("SELECT TOP 1 \"U_TranWH\" FROM \"@AORSETUP\" ORDER BY \"CreateDate\" DESC");
                        var nextVal = oForm.BusinessObject.GetNextSerialNumber("97", oForm.BusinessObject.Type.ToString());
                        myDBDataSource.SetValue("U_AORNum", 0, nextVal.ToString());
                        myDBDataSource.SetValue("U_Requester", 0, code);
                        myDBDataSource.SetValue("U_RequesterName", 0, name);
                        myDBDataSource.SetValue("U_Department", 0, dept.ToString());
                        myDBDataSource.SetValue("U_Branch", 0, branch.ToString());                       
                        myDBDataSource.SetValue("U_DocDate", 0, DateTime.Now.Date.ToString("yyyyMMdd"));
                        myDBDataSource.SetValue("U_ValidUntil", 0, DateTime.Now.AddDays(Program.sDefaultValidDays).Date.ToString("yyyyMMdd"));
                    }
             
                }                
            }
            if (pVal.FormTypeEx == "UDO_FT_AOR" &&  pVal.BeforeAction == false && pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "0_U_G" && pVal.ColUID == "C_0_2")
            {
                if (pVal.Before_Action == true)
                {
                    //var oForm = Program.oApplication.Forms.Item(FormUID);
                    //SAPbouiCOM.IChooseFromListEvent ev = (SAPbouiCOM.IChooseFromListEvent)pVal;
                    //SAPbouiCOM.ChooseFromList objCHSFRMLIST = oForm.ChooseFromLists.Item(ev.ChooseFromListUID); 

                    //SAPbouiCOM.Conditions emptCond = new SAPbouiCOM.Conditions();

                    //objCHSFRMLIST.SetConditions(emptCond);

                    //SAPbouiCOM.Conditions objConditions = objCHSFRMLIST.GetConditions();

                    //SAPbouiCOM.Condition objCondition;

                    //objCondition = objConditions.Add();

                    //objCondition.Alias = "SLPCODE";

                    //objCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;

                    //objCondition.CondVal = "1";

                    //objCHSFRMLIST.SetConditions(objConditions);
                }
                if (pVal.Before_Action == false)
                {
                    var oForm = Program.oApplication.Forms.Item(FormUID);
                    SAPbouiCOM.IChooseFromListEvent ev = (SAPbouiCOM.IChooseFromListEvent)pVal;
                    SAPbouiCOM.ChooseFromList chooser = oForm.ChooseFromLists.Item(ev.ChooseFromListUID);
                    DataTable dataTable = ev.SelectedObjects;
                    if (dataTable != null)
                    {
                        string code = (string)dataTable.GetValue("ItemCode", 0);
                        string descrip = (string)dataTable.GetValue("ItemName", 0);
                        double onHand = (double)dataTable.GetValue("OnHand", 0);
                        SAPbouiCOM.Matrix oMtx = (SAPbouiCOM.Matrix)oForm.Items.Item(pVal.ItemUID).Specific;
                        oMtx.SetCellWithoutValidation(pVal.Row, "C_0_2", code);
                        oMtx.SetCellWithoutValidation(pVal.Row, "C_0_4", descrip);
                        oMtx.SetCellWithoutValidation(pVal.Row, "C_0_5", Program.sDefaultWhs);
                        oMtx.SetCellWithoutValidation(pVal.Row, "C_0_10", Program.sDefaultTax);
                        oMtx.SetCellWithoutValidation(pVal.Row, "C_0_7", CommonFunction.GetSingleValue($"SELECT \"InvntryUom\" FROM \"OITM\" WHERE \"ItemCode\" = '{code}'") ?? "");
                    }
                }                
            }
            if (pVal.FormTypeEx == "UDO_FT_AOR" && pVal.BeforeAction == false && pVal.EventType == SAPbouiCOM.BoEventTypes.et_KEY_DOWN && pVal.ItemUID == "0_U_G" && (pVal.ColUID == "C_0_6" || pVal.ColUID == "C_0_8"))
            {
                var oForm = Program.oApplication.Forms.Item(FormUID);
                SAPbouiCOM.Matrix oMtx = (SAPbouiCOM.Matrix)oForm.Items.Item(pVal.ItemUID).Specific;
                var qtyTxt = (SAPbouiCOM.EditText)oMtx.Columns.Item("C_0_6").Cells.Item(pVal.Row).Specific;
                var grossTxt = (SAPbouiCOM.EditText)oMtx.Columns.Item("C_0_8").Cells.Item(pVal.Row).Specific;
                var taxGroup = (SAPbouiCOM.EditText)oMtx.Columns.Item("C_0_10").Cells.Item(pVal.Row).Specific;

                Action calculateFooter = delegate 
                {
                    decimal totalBefTax = 0;
                    decimal totalTax = 0;
                    decimal totalPDue = 0;
                    for(int i = 1; i <= oMtx.RowCount; i++)
                    {
                        var _lineTotaltxt = (SAPbouiCOM.EditText)oMtx.Columns.Item("C_0_9").Cells.Item(i).Specific;
                        var _taxTxt = (SAPbouiCOM.EditText)oMtx.Columns.Item("C_0_11").Cells.Item(i).Specific;
                        if (!String.IsNullOrEmpty(_lineTotaltxt.Value))
                        {
                            totalBefTax += Decimal.Parse(_lineTotaltxt.Value);
                        }
                        if (!String.IsNullOrEmpty(_taxTxt.Value))
                        {
                            totalTax += Decimal.Parse(_taxTxt.Value);
                        }
                    }
                    var myDBDataSource = oForm.DataSources.DBDataSources.Item("@AOR");
                    myDBDataSource.SetValue("U_TotelBTax", 0, totalBefTax.ToString());
                    myDBDataSource.SetValue("U_Tax", 0, totalTax.ToString());
                    myDBDataSource.SetValue("U_TotalPDue", 0, (totalBefTax + totalTax).ToString());
                };
                

                if (!String.IsNullOrEmpty(qtyTxt.Value) && !String.IsNullOrEmpty(grossTxt.Value))
                {
                   var taxRate = CommonFunction.GetSingleValue($"SELECT TOP 1 \"Rate\" FROM \"OVTG\" WHERE \"Code\" = '{taxGroup.Value}' AND YEAR(CURRENT_DATE) >= YEAR(\"EffecDate\") ORDER BY \"EffecDate\" DESC") ?? "";
                   var lineTotal = (decimal.Parse(grossTxt.Value) * decimal.Parse(qtyTxt.Value));
                   var taxRatePrcnt = (decimal.Parse(taxRate) / 100);
                   var taxAmount = (taxRatePrcnt * lineTotal);

                   oMtx.SetCellWithoutValidation(pVal.Row, "C_0_9", lineTotal.ToString());
                   oMtx.SetCellWithoutValidation(pVal.Row, "C_0_11", taxAmount.ToString());
                   oMtx.SetCellWithoutValidation(pVal.Row, "C_0_12", (lineTotal + taxRatePrcnt).ToString());
                   calculateFooter();
                }
            }
            if (pVal.FormTypeEx == "UDO_FT_AOR" && pVal.BeforeAction == false && pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK 
                                                && (pVal.ItemUID == "Item_13" || pVal.ItemUID == "Item_14" || pVal.ItemUID == "Item_5" || pVal.ItemUID == "Item_17"))
            {
                var oForm = Program.oApplication.Forms.Item(FormUID);
                if (oForm.Mode == BoFormMode.fm_VIEW_MODE || oForm.Mode == BoFormMode.fm_UPDATE_MODE)
                {

                }
            }
            if (pVal.FormTypeEx == "UDO_FT_AOR" && pVal.BeforeAction == false && pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "0_U_G" && pVal.ColUID == "C_0_3")
            {
                if (pVal.Before_Action == false)
                {
                    var oForm = Program.oApplication.Forms.Item(FormUID);
                    SAPbouiCOM.Matrix oMtx = (SAPbouiCOM.Matrix)oForm.Items.Item(pVal.ItemUID).Specific;
                    SAPbouiCOM.IChooseFromListEvent ev = (SAPbouiCOM.IChooseFromListEvent)pVal;
                    SAPbouiCOM.ChooseFromList chooser = oForm.ChooseFromLists.Item(ev.ChooseFromListUID);
                    DataTable dataTable = ev.SelectedObjects;
                    if (dataTable != null)
                    {
                        var _type = (SAPbouiCOM.EditText)oMtx.Columns.Item(pVal.ColUID).Cells.Item(pVal.Row).Specific;
                        if (!String.IsNullOrEmpty(_type.Value) && _type.Value.ToLower() == "expense")
                        {
                            string code = (string)dataTable.GetValue("AcctCode", 0);
                            oMtx.SetCellWithoutValidation(pVal.Row, "C_0_3", code);
                        }
                        else
                        {
                            Program.oApplication.StatusBar.SetText("Not applicable for not expense type .", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        }                     
                    }
                }                   
            }          
        }
    }
}
