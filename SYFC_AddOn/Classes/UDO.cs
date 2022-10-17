using SYFC_AddOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SYFC_AddOn.Classes
{
    public static class UDO
    {
        public static void Create()
        {
            ////AOR Setup
            CreateUDT("AORSetup", "AOR Default Setups", SAPbobsCOM.BoUTBTableType.bott_MasterData);
            CreateUDF("@AORSetup", "Code", "Code", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORSetup", "VldUntl", "Valid Until Days", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Quantity, 100);
            CreateUDF("@AORSetup", "DefaultTax", "Default Tax Code", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORSetup", "TranWH", "Transfer from Warehouse", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);

            ////AOR Header
            CreateUDT("AOR", "Approval of Requirement", SAPbobsCOM.BoUTBTableType.bott_Document);
            CreateUDF("@AOR", "Requester", "Requester", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "RequesterName", "Requester Name", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "Branch", "Branch", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "Department", "Department", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "AORRef", "AOR Reference", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "AORNum", "AOR Number", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "Status", "Status", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "DocDate", "Posting Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "ValidUntil", "Valid Until", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "ReqDate", "Required Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "Attachment", "Attachment", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "Attchmnt", "File Attachment", SAPbobsCOM.BoFieldTypes.db_Memo, SAPbobsCOM.BoFldSubTypes.st_Link, int.MaxValue);
            CreateUDF("@AOR", "ErrorMsg", "Error Message", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 200);
            CreateUDF("@AOR", "TotelBTax", "Total Before Tax", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AOR", "Tax", "Tax", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AOR", "TotalPDue", "Total Payment Due", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AOR", "Jstfcation", "Justification", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 300);
            CreateUDF("@AOR", "ApprDate", "Approve Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "ApprBy", "Approve By", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 200);
            CreateUDF("@AOR", "RejDate", "Reject Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "RejBy", "Reject By", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 200);
            CreateUDF("@AOR", "PreApprFlg", "Pre Approve Flag", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "PreApprFlg", "Pre Approve Flag", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "PRIDocNum", "PR I Doc Number", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "PRIDocEntry", "PR I Doc Entry", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "PRSDocNum", "PR S Doc Number", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "PRSDocEntry", "PR S Doc Entry", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "ITRDocNum", "ITR Doc Number", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "ITRDocEntry", "ITR Doc Entry", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR", "PostStatus", "Posting Status", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);

            ////AOR Lines
            CreateUDT("AOR_Lines", "AOR Lines", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            CreateUDF("@AOR_Lines", "GridRowNo", "Row Num", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "Type", "Type", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "Code", "Code", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "GLCode", "GL Code", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "Dscript", "Description", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "Whouse", "Warehouse", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "Qty", "Quantity", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Quantity, 100);
            CreateUDF("@AOR_Lines", "UOM", "UOM", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "GPrice", "Gross Price", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AOR_Lines", "LTotal", "Line Total", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AOR_Lines", "TGroup", "Tax Group", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "TAmount", "Tax Amount", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AOR_Lines", "GTotal", "Gross Total", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AOR_Lines", "TrgetDoc", "Target Document", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AOR_Lines", "ExpAcct", "Expense Account", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);


            CreateUDT("AORRpt", "Approval of Requirement Report", SAPbobsCOM.BoUTBTableType.bott_Document);
            CreateUDF("@AORRpt", "AORNumFR", "AOR Number", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRpt", "AORNumTo", "AOR Number", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRpt", "ReqFrom", "Requester From", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRpt", "ReqTo", "Requester To", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRpt", "DocDateFR", "Posting Date From", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRpt", "DocDateTO", "Posting Date To", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRpt", "AORStatus", "AOR Status", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRpt", "PostStatus", "Post Status", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);


            ////AOR Report
            CreateUDT("AORRptItems", "AOR List Items", SAPbobsCOM.BoUTBTableType.bott_DocumentLines);
            CreateUDF("@AORRptItems", "AORNum", "AOR Number", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "RequesterName", "Requester Name", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "Branch", "Branch", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "Department", "Department", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "Status", "Status", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "DocDate", "Posting Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "ValidUntil", "Valid Until", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "ReqDate", "Required Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "TotalPDue", "Total Payment Due", SAPbobsCOM.BoFieldTypes.db_Float, SAPbobsCOM.BoFldSubTypes.st_Price, 200);
            CreateUDF("@AORRptItems", "PostStatus", "Posting Status", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "ApprDate", "Approve Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "ApprBy", "Approve By", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 200);
            CreateUDF("@AORRptItems", "RejDate", "Reject Date", SAPbobsCOM.BoFieldTypes.db_Date, SAPbobsCOM.BoFldSubTypes.st_None, 100);
            CreateUDF("@AORRptItems", "RejBy", "Reject By", SAPbobsCOM.BoFieldTypes.db_Alpha, SAPbobsCOM.BoFldSubTypes.st_None, 200);
        

            //Create UDO 
            CreateUDO_AOR();
            CreateUDO_AORSetup();
            CreateUDO_AORLists();
        }

        static void CreateUDF(string udtName, string udfName, string udfDesc, SAPbobsCOM.BoFieldTypes udfType, SAPbobsCOM.BoFldSubTypes udfSubType, int udfEditSize, [Optional] string udfLinkTable, [Optional] IList<ValidValues> validvalues, [Optional] string defaultval)
        {
            SAPbobsCOM.UserFieldsMD oUDFMD = null;
            try
            {
                oUDFMD = (SAPbobsCOM.UserFieldsMD)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserFields);

                oUDFMD.TableName = udtName;
                oUDFMD.Name = udfName;
                oUDFMD.Description = udfDesc;
                oUDFMD.Type = udfType;
                oUDFMD.SubType = udfSubType;
                oUDFMD.EditSize = udfEditSize;
                oUDFMD.LinkedTable = udfLinkTable;

                if (validvalues != null)
                {
                    foreach (var item in validvalues)
                    {

                        oUDFMD.ValidValues.Add();
                        oUDFMD.ValidValues.Value = item.Value;
                        oUDFMD.ValidValues.Description = item.Description;
                    }
                }
                oUDFMD.DefaultValue = defaultval;

                Program.lRetCode = oUDFMD.Add();

                //string a = Program.oCompany.GetLastErrorDescription();

                GC.Collect();

                Program.oApplication.StatusBar.SetText(String.Format("UDF {0} Creation in UDT {1}", udfName, udtName), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Program.oApplication.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (oUDFMD != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oUDFMD);
                    oUDFMD = null;
                    GC.Collect();
                }
            }
        }

        static void CreateUDT(string udtName, string udtDesc, SAPbobsCOM.BoUTBTableType udtType)
        {
            SAPbobsCOM.UserTablesMD oUDTMD = null;
            try
            {
                oUDTMD = (SAPbobsCOM.UserTablesMD)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserTables);
                oUDTMD.TableName = udtName;
                oUDTMD.TableDescription = udtDesc;
                oUDTMD.TableType = udtType;

                Program.lRetCode = oUDTMD.Add();

                Program.oApplication.StatusBar.SetText(String.Format("UDT {0} Creation", udtName), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Program.oApplication.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (oUDTMD != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oUDTMD);
                    oUDTMD = null;
                    GC.Collect();
                }
            }
        }

        static void CreateUDO(string udoCode, string udoName, SAPbobsCOM.BoUDOObjType udoType, string mainTable, IList<string> childTableList, int fatherMenuID, string menuID, string menuCaption, int position, [Optional] IList<string> enchancedFormColumnList, [Optional] IList<string> findColumnList, [Optional] SAPbobsCOM.BoYesNoEnum canDefForm, SAPbobsCOM.BoYesNoEnum enhancedForm, SAPbobsCOM.BoYesNoEnum manageSeries, SAPbobsCOM.BoYesNoEnum haveMenuItem, SAPbobsCOM.BoYesNoEnum canDelete, SAPbobsCOM.BoYesNoEnum canCancel, SAPbobsCOM.BoYesNoEnum canClose, SAPbobsCOM.BoYesNoEnum canFind, SAPbobsCOM.BoYesNoEnum canNewForm)
        {
            SAPbobsCOM.IUserObjectsMD oUDOMD = null;

            try
            {
                oUDOMD = (SAPbobsCOM.IUserObjectsMD)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD);
                oUDOMD.Code = udoCode;
                oUDOMD.Name = udoName;
                oUDOMD.ObjectType = udoType;
                oUDOMD.TableName = mainTable;

                bool firstLine = true;
                foreach (var childTable in childTableList)
                {
                    if (firstLine)
                    {
                        firstLine = false;
                    }
                    else
                    {
                        oUDOMD.ChildTables.Add();
                    }
                    oUDOMD.ChildTables.TableName = childTable;
                }

                oUDOMD.CanCreateDefaultForm = canDefForm;
                oUDOMD.FatherMenuID = fatherMenuID;
                oUDOMD.MenuItem = haveMenuItem;
                oUDOMD.MenuCaption = menuCaption;
                oUDOMD.Position = position;
                oUDOMD.EnableEnhancedForm = enhancedForm;

                if (enchancedFormColumnList != null)
                {
                    firstLine = true;

                    SAPbobsCOM.IUserObjectMD_EnhancedFormColumns formColumns = oUDOMD.EnhancedFormColumns;

                    foreach (var enhanceFormColumn in enchancedFormColumnList)
                    {
                        if (firstLine)
                        {
                            firstLine = false;
                        }
                        else
                        {
                            formColumns.Add();
                        }
                        formColumns.ColumnAlias = enhanceFormColumn;
                        formColumns.ColumnDescription = enhanceFormColumn;
                    }

                }

                if (canFind == SAPbobsCOM.BoYesNoEnum.tYES && findColumnList != null && findColumnList.Count > 0 && firstLine == true)
                {
                    SAPbobsCOM.IUserObjectMD_FindColumns findColumns = oUDOMD.FindColumns;

                    foreach (var findColumn in findColumnList)
                    {
                        if (firstLine)
                        {
                            firstLine = false;
                        }
                        else
                        {
                            findColumns.Add();
                        }

                        findColumns.ColumnAlias = findColumn;
                        findColumns.ColumnDescription = findColumn;
                    }
                }

                oUDOMD.ManageSeries = manageSeries;

                oUDOMD.CanDelete = canDelete;
                oUDOMD.CanCancel = canCancel;
                oUDOMD.CanClose = canClose;
                oUDOMD.CanFind = canFind;
                oUDOMD.CanCreateDefaultForm = canNewForm;

                Program.lRetCode = oUDOMD.Add();

                if (Program.lRetCode != 0)
                {
                    Program.oApplication.StatusBar.SetText(Program.oCompany.GetLastErrorDescription(), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                }
                else
                {
                    Program.oApplication.StatusBar.SetText(String.Format("UDO {0}, {1} Registration", udoCode, udoName), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }

            }
            catch (Exception ex)
            {
                Program.oApplication.StatusBar.SetText(ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (oUDOMD != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(oUDOMD);
                    oUDOMD = null;
                    GC.Collect();
                }
            }
        }

        static void CreateUDO_AOR()
        {
            //TAS
            SAPbobsCOM.UserObjectsMD oudtMD = null;
            oudtMD = (SAPbobsCOM.UserObjectsMD)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD);

            if (oudtMD.GetByKey("AOR"))
            {
                return;
            }
            else
            {
                IList<string> enhancedFormColList = new List<string>();
                IList<string> findColumnList = new List<string>();

                CreateUDO("AOR",
                          "AOR",
                          SAPbobsCOM.BoUDOObjType.boud_Document,
                          "AOR",
                           new List<string>()
                           ,
                           47619,
                         "AOR",
                         "AOR",
                         1,
                         enhancedFormColList,
                         findColumnList,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES);
            }

        }
        static void CreateUDO_AORSetup()
        {
            //TAS
            SAPbobsCOM.UserObjectsMD oudtMD = null;
            oudtMD = (SAPbobsCOM.UserObjectsMD)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD);

            if (oudtMD.GetByKey("AORSetup"))
            {
                return;
            }
            else
            {
                IList<string> enhancedFormColList = new List<string>();
                IList<string> findColumnList = new List<string>();

                CreateUDO("AORSetup",
                          "AORSetup",
                          SAPbobsCOM.BoUDOObjType.boud_MasterData,
                          "AORSetup",
                           new List<string>()
                           ,
                           47619,
                         "AORSetup",
                         "AORSetup",
                         1,
                         enhancedFormColList,
                         findColumnList,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES);
            }

        }
        static void CreateUDO_AORLists()
        {
            //TAS
            SAPbobsCOM.UserObjectsMD oudtMD = null;
            oudtMD = (SAPbobsCOM.UserObjectsMD)Program.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oUserObjectsMD);

            if (oudtMD.GetByKey("AORRpt"))
            {
                return;
            }
            else
            {
                IList<string> enhancedFormColList = new List<string>();
                IList<string> findColumnList = new List<string>();

                CreateUDO("AORRpt",
                          "AORRpt",
                          SAPbobsCOM.BoUDOObjType.boud_Document,
                          "AORRpt",
                           new List<string>()
                           ,
                           47619,
                         "AORRpt",
                         "AORRpt",
                         1,
                         enhancedFormColList,
                         findColumnList,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tNO,
                         SAPbobsCOM.BoYesNoEnum.tYES,
                         SAPbobsCOM.BoYesNoEnum.tYES);
            }

        }
    }
}
