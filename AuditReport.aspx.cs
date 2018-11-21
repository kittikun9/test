using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Office.Interop.Excel;

public partial class AuditReport : System.Web.UI.Page
{
    ExecSQL s = new ExecSQL();
    string con = SqlHelper.GetConnectionString("Job_apl");
    string comm = "";
    System.Data.DataTable dt = new System.Data.DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Sessionuser();
        if (!IsPostBack)
        {
            Dropdownlist();
        }
    }
    public void Sessionuser()
    {
        if (Session["Account_User"] != null)
        {
            Session["Header"] = "Report";
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    public void Dropdownlist()
    {

        comm = " SELECT distinct CUSTOMER FROM[JOB_APL].[dbo].[report_operations] ";
        dt = s.ExecTable(comm, "Job_apl");
        DropDownListcustomer.Items.Add("-- Select Customer --");
        DropDownListcustomer.Items.Add("ALL");
        DropDownListcustomer.SelectedIndex = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DropDownListcustomer.Items.Add(dt.Rows[i]["CUSTOMER"].ToString());
            //DropDownListcustomer.DataValueField = dt.Rows[i]["jno"].ToString();
            //DropDownListcustomer.DataTextField = dt.Rows[i]["CUSTOMER"].ToString();
        }
    }


    protected void imExport_Click(object sender, ImageClickEventArgs e)
    {

        string test = DropDownListcustomer.Text;

        if (test == "ALL")
        {

            ExportData();

        }
        else
        {
            ExportData2();
        }
    }


    protected void imUpdate_Click(object sender, ImageClickEventArgs e)
    {
        UpdateExportData();
    }
    private void ExportData()
    {

        SqlConnection conn = new SqlConnection();
        string path = ConfigurationManager.ConnectionStrings["Job_apl"].ConnectionString;
        comm = "SELECT [ACPeriod],[CUSTOMER],[typeJob],[NameEng],[JNo],[JobStatus_],[CPolicyCode],[CustCode],[CSCode],[JobStatus],[JobType],[InvNo (Cust Inv)]";
        comm += ",[InvProductQty],[ImExDate],[DocDate],[CloseJobDate],[CloseJobTime],[DeclareType],[EDIdate],[DeclareNumber],[TotalContainer],[consigneecode]";
        comm += ",[CustID],[NameThai],[CSName],[CloseJobBy],[SERVICE-Customs-AMT],[SERVICE-Transport-AMT],[ADVANCE-AMT],[COST-Customs-AMT],[COST-Transport-AMT]";
        comm += ",CASE WHEN [referAll]  is null then 'NULL' else  [referAll] end as referAll,[Invdate],[Lastupdate],[PO_All],[PO_Amount] ";
        comm += ",CASE WHEN [PO_All]  is null then 'UnPaid' else  'Paid' end as [V-Payment],CASE WHEN [referAll]  is null then 'UnBilled' else  'Billed' end as Billing  ,[CustomerCode],[ETD],[ETA],[LoadDate],[Remark]";
        comm += " FROM [JOB_APL].[dbo].[report_operations]  where ACPeriod <>'A0' ";
        conn.ConnectionString = path;
        SqlDataAdapter Adp = new SqlDataAdapter(comm, conn);
        Adp.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            string filepath = Server.MapPath("~/Report/AuditReport.xlsx");
            FileInfo template = new FileInfo(filepath);
            ExcelPackage excel = new ExcelPackage(template);

            var sheetcracte = excel.Workbook.Worksheets["Editreport"];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sheetcracte.Cells[1, i + 1].Value = dt.Columns[i].ColumnName.ToString();
                sheetcracte.Cells[1, i + 1].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sheetcracte.Cells[i + 2, j + 1].Value = dt.Rows[i][j];

                }
            }
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + "AuditReport" + "_" + DateTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss") + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();

            }
        }
    }


    private void ExportData2()
    {
        string test = DropDownListcustomer.Text;

        SqlConnection conn = new SqlConnection();
        string path = ConfigurationManager.ConnectionStrings["Job_apl"].ConnectionString;


        comm = "SELECT [ACPeriod],[CUSTOMER],[typeJob],[NameEng],[JNo],[JobStatus_],[CPolicyCode],[CustCode],[CSCode],[JobStatus],[JobType],[InvNo (Cust Inv)]";
        comm += ",[InvProductQty],[ImExDate],[DocDate],[CloseJobDate],[CloseJobTime],[DeclareType],[EDIdate],[DeclareNumber],[TotalContainer],[consigneecode]";
        comm += ",[CustID],[NameThai],[CSName],[CloseJobBy],[SERVICE-Customs-AMT],[SERVICE-Transport-AMT],[ADVANCE-AMT],[COST-Customs-AMT],[COST-Transport-AMT]";
        comm += ",CASE WHEN [referAll]  is null then 'NULL' else  [referAll] end as referAll,[Invdate],[Lastupdate],[PO_All],[PO_Amount] ";
        comm += ",CASE WHEN [PO_All]  is null then 'UnPaid' else  'Paid' end as [V-Payment],CASE WHEN [referAll]  is null then 'UnBilled' else  'Billed' end as Billing  ,[CustomerCode],[ETD],[ETA],[LoadDate],[Remark]";
        comm += " FROM [JOB_APL].[dbo].[report_operations]  where customer = '" + test + "' and ACPeriod <>'A0' ";

        conn.ConnectionString = path;
        SqlDataAdapter Adp = new SqlDataAdapter(comm, conn);
        Adp.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            string filepath = Server.MapPath("~/Report/AuditReport.xlsx");
            FileInfo template = new FileInfo(filepath);
            ExcelPackage excel = new ExcelPackage(template);

            var sheetcracte = excel.Workbook.Worksheets["Editreport"];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sheetcracte.Cells[1, i + 1].Value = dt.Columns[i].ColumnName.ToString();
                sheetcracte.Cells[1, i + 1].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sheetcracte.Cells[i + 2, j + 1].Value = dt.Rows[i][j];

                }

            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + "AuditReport" + "_" + DateTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss") + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();

            }
        }
    }
    private void UpdateExportData()
    {

        SqlConnection conn = new SqlConnection();
        string path = ConfigurationManager.ConnectionStrings["Job_apl"].ConnectionString;
        comm = "EXECUTE [dbo].[Report_T1_Opration] ";
        conn.ConnectionString = path;
        SqlDataAdapter Adp = new SqlDataAdapter(comm, conn);
        Adp.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            string filepath = Server.MapPath("~/Report/AuditReport.xlsx");
            FileInfo template = new FileInfo(filepath);
            ExcelPackage excel = new ExcelPackage(template);

            var sheetcracte = excel.Workbook.Worksheets["Editreport"];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sheetcracte.Cells[1, i + 1].Value = dt.Columns[i].ColumnName.ToString();
                sheetcracte.Cells[1, i + 1].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                sheetcracte.Cells[1, i + 1].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sheetcracte.Cells[i + 2, j + 1].Value = dt.Rows[i][j];

                }
            }
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + "AuditReport" + "_" + DateTime.Now.ToString("dd_MMM_yyyy_HH_mm_ss") + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();

            }
        }
    }
}