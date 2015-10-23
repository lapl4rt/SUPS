using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using DigDes.DSchool.SUPS.DataAccess.PresentData;

namespace DigDes.DSchool.SUPS.WebUI
{
    public partial class Guides : System.Web.UI.Page
    {
        public HttpPostedFile selectedFile;
        public byte[] binaryImagedata;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CargoGridView.SelectedIndex == -1)
            {
                CargoFV.Visible = EditButton.Enabled = SaveButton.Visible = 
                    CancelButton.Visible = DeleteButton.Enabled = false;
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = string.Empty;
                e.Row.Cells[1].Visible = false;
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackEventReference(CargoGridView, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:point";
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            EditButton.Enabled = DeleteButton.Enabled = true;
            EditButton.Visible = DeleteButton.Visible = true;
            CargoFV.Visible =  SaveButton.Visible = CancelButton.Visible = false;
            lblState.Text = " ";

            foreach (GridViewRow row in CargoGridView.Rows)
            {
                if (row.RowIndex == CargoGridView.SelectedIndex)
                {
                    row.Cells[0].CssClass = "arrow-active";
                }
                else 
                {
                    row.Cells[0].CssClass = "image-arrow";
                }
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int indexDel = CargoGridView.SelectedIndex;
            CargoGridView.DeleteRow(indexDel);
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            CargoFV.ChangeMode(FormViewMode.Edit);
            CargoFV.DataBind();
            if (CargoGridView.SelectedIndex != -1)
            {
                CargoFV.Visible = SaveButton.Visible = CancelButton.Visible = true;
                DeleteButton.Visible = EditButton.Visible = false;
                lblState.Text = "Редактирование: " + CargoGridView.Rows[CargoGridView.SelectedIndex].Cells[1].Text;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            CargoFV.ChangeMode(FormViewMode.Insert);
            CargoFV.Visible = SaveButton.Visible = CancelButton.Visible = true;
            DeleteButton.Visible = EditButton.Visible = false;
            lblState.Text = "Добавление нового груза: ";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (CargoFV.CurrentMode == FormViewMode.Edit)
            {
                CargoFV.UpdateItem(true);
                CargoGridView.DataBind();
            }

            else if (CargoFV.CurrentMode == FormViewMode.Insert)
            {
                CargoFV.InsertItem(true);
                CargoGridView.DataBind();
                CargoFV.ChangeMode(FormViewMode.ReadOnly);
                lblState.Text += "\nГруз успешно добавлен";
            }

            AddButton.Visible = DeleteButton.Visible = EditButton.Visible = true;
            CargoFV.Visible = CancelButton.Visible = SaveButton.Visible = CancelButton.Visible = false;
            lblState.Text = "";
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            CargoFV.ChangeMode(FormViewMode.ReadOnly);
            AddButton.Visible = EditButton.Visible = DeleteButton.Visible = true;
            CargoFV.Visible = CancelButton.Visible = SaveButton.Visible = false;
            lblState.Text = "";
            CargoFV.DataBind();
        }

        public string GetGridTextBoxValue(string tbID)
        {
            try
            {
                TextBox txt = (TextBox)CargoFV.FooterRow.FindControl(tbID);
                return txt.Text;
            }

            catch (Exception ex)
            {
                return string.Empty;
                throw ex;
            }
        }

        protected void CargoGridView_PageIndexChanged(object sender, EventArgs e)
        {
            SaveButton.Visible = CancelButton.Visible = CargoFV.Visible = false;
            CargoGridView.DataBind();
        }
    }
}