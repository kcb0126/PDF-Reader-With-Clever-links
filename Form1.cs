using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PDFXCviewAxLib;
using System.IO;

namespace View
{
    public partial class Form1 : Form
    {
        private int iActiveDocID;

        public Form1()
        {
            InitializeComponent();

            axCoPDFXCview1.SetProperty("View.Bars[#33009].Visible", 1);
            axCoPDFXCview1.SetProperty("View.Bars[#32908].Visible", 1);
            axCoPDFXCview1.SetProperty("View.Bars[#32929].Visible", 1);
            axCoPDFXCview1.SetProperty("View.Bars[#32924].Visible", 1);
            axCoPDFXCview1.SetProperty("View.Bars[#32925].Visible", 1);
            axCoPDFXCview1.SetProperty("View.Bars[#33000].Visible", 1);
            axCoPDFXCview1.SetProperty("View.Bars[#33138].Visible", 1);
        }

        public void ShowErrorMessage(int HResult)
        {
            string str;
            if (HResult != 0)
            {
                try
                {
                    axCoPDFXCview1.GetTextFromResult(HResult, out str);
                    MessageBox.Show(str);
                }
                catch
                {
                    MessageBox.Show("error in GetTextFromResult");
                }
            }
        }

        private void axCoPDFXCview1_OnEvent(object sender, AxPDFXCviewAxLib._IPDFXCviewEvents_OnEventEvent e)
        {
            if(e.name == "Prompts.ConfirmOpenSite")
            {
                object dataOut;
                axCoPDFXCview1.GetProperty("Prompts.ConfirmOpenSite.Name", out dataOut, 0);
                string uri = dataOut.ToString();
                if(uri.EndsWith("/"))
                {
                    uri = uri.Substring(0, uri.Length - 1);
                }


                if (uri.ToLower().StartsWith("popup://"))
                {

                    object pdfFilename;
                    axCoPDFXCview1.GetDocumentProperty(0, "FileName", out pdfFilename, 0);

                    string filename = uri.Substring(8);
                    string pdfLocation = Path.GetDirectoryName(pdfFilename.ToString());
                    string popuppath = Path.Combine(pdfLocation, filename);
                    if(!File.Exists(popuppath))
                    {
                        return;
                    }
                    StreamReader reader = new StreamReader(popuppath);
                    string popupcontents = reader.ReadToEnd();
                    reader.Close();
                    var mousePos = System.Windows.Forms.Cursor.Position;
                    popup1.Left = Math.Min(mousePos.X - this.Left, this.Width - popup1.Width - 20);
                    popup1.Top = Math.Min(mousePos.Y - this.Top - 20, this.Height - popup1.Height);
                    popup1.PopupPath = popuppath;
                    popup1.Comment = popupcontents;
                    popup1.Visible = true;
                    
                    lblShadow.Left = popup1.Left + 5;
                    lblShadow.Top = popup1.Top + 5;
                    lblShadow.Width = popup1.Width;
                    lblShadow.Height = popup1.Height;
                    lblShadow.Visible = true;

                    axCoPDFXCview1.set_Property("Prompts.ConfirmOpenSite.UserChoice", 0, "No");
                }
                else if(uri.ToLower().StartsWith("command://"))
                {
                    string command = uri.Substring(10);
                    int spacepos = command.IndexOf(' ');
                    if (spacepos == -1)
                    {
                        System.Diagnostics.Process.Start(command);
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(command.Substring(0, spacepos), command.Substring(spacepos));
                    }
                    axCoPDFXCview1.set_Property("Prompts.ConfirmOpenSite.UserChoice", 0, "No");
                }

                // axCoPDFXCview1.set_Property("Prompts.ConfirmOpenSite.Name", 0, "https://bing.com");
            }

            switch (e.type)
            {
                case (int)PXCVA_EventTypes.PXCVA_OnPropertyChanged:
                    OnPropertyChanged(e.name);
            	break;
            }
        }

        private void OnPropertyChanged(string sName)
        {
	        string sPropName = sName;
	        int iCount;
	        object vDataOut;

	        if (sName == "Documents.Active")
	        {
                try
                {
                    axCoPDFXCview1.GetActiveDocument(out iActiveDocID);
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(System.Runtime.InteropServices.Marshal.GetHRForException(ex));
                    return;
                }

                //If we are opening a new document or changing active document in MDI mode
                if (iActiveDocID >= 0)
                {
				    sPropName = "FileName";
                    try
                    {
                        axCoPDFXCview1.GetDocumentProperty(iActiveDocID, sPropName, out vDataOut, 0);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(System.Runtime.InteropServices.Marshal.GetHRForException(ex));
                        return;
                    }

				    string sPrefix = "Documents[#" + iActiveDocID.ToString() + "].";
                }
			    //If we are closing document
			    else
			    {
			    }
            }
            else
            {
		        bool bVisible;
		        int iID = 0;
		        int iType = 0;
		        int iEaten = 0;
		        string sProperName = "";
		        string sID = "";
                try
                {
                    axCoPDFXCview1.GetViewObjectFromName(sName, out iType, out iID, out sProperName, out iEaten);
                }
                catch (Exception ex)
                {
                    return;
                }
                if (iID == -1 || sName.Substring(iEaten).CompareTo("Visible") != 0)
		        {
			        return;
		        }

                if (!TryGetProperty(sName, out vDataOut)) return;
		        bVisible = (int)vDataOut == 0 ? false : true;
                sID = iID.ToString();

            }
        }

        private bool TryGetProperty(string sName, out object dataOut)
        {
            bool bRes = false;
            try
            {
                axCoPDFXCview1.GetProperty(sName, out dataOut);
                bRes = true;
            }
            catch (Exception ex)
            {
                ShowErrorMessage(System.Runtime.InteropServices.Marshal.GetHRForException(ex));
                dataOut = null;
            }
            return bRes;
        }

        private void popup1_Click(object sender, EventArgs e)
        {
            popup1.Visible = false;
            lblShadow.Visible = false;
        }
    }
}
