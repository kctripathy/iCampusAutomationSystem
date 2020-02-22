using System;
using System.Drawing;
using System.Windows.Forms;

namespace Micro.Commons
{
  //  public class FormFunctions
  //  {
  //      public static string GetActiveControlName(DevExpress.XtraEditors.XtraForm Frm)
  //      {
  //          Control c = Frm.ActiveControl;

  //          if (c is DevExpress.XtraLayout.LayoutControl)
  //          {
  //              if ((((DevExpress.XtraLayout.LayoutControl)Frm.ActiveControl).ActiveControl != null))
  //              {
  //                  c = ((DevExpress.XtraLayout.LayoutControl)Frm.ActiveControl).ActiveControl;
  //              }
  //          }
  //          if (c is DevExpress.XtraEditors.TextBoxMaskBox)
  //          {
  //              c = c.Parent;
  //          }

  //          return c.Name + "";
  //      }

  //      public static Control GetActiveControl(DevExpress.XtraEditors.XtraForm Frm)
  //      {
  //          Control c = Frm.ActiveControl;

  //          if (c is DevExpress.XtraLayout.LayoutControl)
  //          {
  //              if ((((DevExpress.XtraLayout.LayoutControl)Frm.ActiveControl).ActiveControl != null))
  //              {
  //                  c = ((DevExpress.XtraLayout.LayoutControl)Frm.ActiveControl).ActiveControl;
  //              }
  //          }
  //          if (c is DevExpress.XtraEditors.TextBoxMaskBox)
  //          {
  //              c = c.Parent;
  //          }

  //          return c;
  //      }

		//public static void SetFormControlsToCenter(DevExpress.XtraEditors.XtraForm frm,
		//	DevExpress.XtraEditors.PanelControl pnlHEADER,
		//	DevExpress.XtraEditors.PanelControl pnlDETAILS,
		//	DevExpress.XtraEditors.PanelControl pnlFOOTER)
		//{
		//	pnlDETAILS.Size = new Size(950, 500);
		//	pnlDETAILS.Left = (frm.Width - pnlDETAILS.Width) / 2;
		//	pnlDETAILS.Top = (frm.Height - pnlDETAILS.Height) / 2;
		//	pnlDETAILS.Top = pnlDETAILS.Top;
		//	//- 10
		//	//_with1.BackColor = _with1.DefaultBackColor;

		//	//FontDialog myFontDialog = default(FontDialog);
		//	//myFontDialog = new FontDialog();

		//	//MyControl.Font = New Font(MyControl.Font, MyControl.Font.Style Or FontStyle.Bold)

		//	pnlHEADER.Left = pnlDETAILS.Left;
		//	pnlHEADER.Top = pnlDETAILS.Top - 2 - pnlHEADER.Height;
		//	pnlHEADER.Width = pnlDETAILS.Width;
		//	//pnlHEADER.BackColor = FrmTitleColor;
		//	pnlHEADER.Font = new Font("Verdana", 15.75f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0));
		//	//.ForeColor = Color.CornflowerBlue
		//	pnlHEADER.ForeColor = Color.Black;
		//	pnlHEADER.BackColor = Color.Transparent;

		//	pnlFOOTER.Left = pnlDETAILS.Left;
		//	pnlFOOTER.Top = pnlDETAILS.Height + pnlDETAILS.Top + 2;
		//	pnlFOOTER.Width = pnlDETAILS.Width;


		//	//int Hgt=1; 
		//	//if(UCS==null)
		//	//{
		//	//    Hgt= pnlDETAILS.Height + pnlHEADER.Height + pnlFOOTER.Height + 20 ;
		//	//}
		//	//else
		//	//{
		//	//    Hgt= pnlDETAILS.Height + pnlHEADER.Height + pnlFOOTER.Height + 20 + UCS.Height;
		//	//}

		//	pnlHEADER.Top = frm.Height / 2;
		//	pnlDETAILS.Top = pnlHEADER.Top + pnlHEADER.Height + 2;
		//	pnlFOOTER.Top = pnlDETAILS.Top + pnlDETAILS.Height + 2;
		//}

  //      public static void ShowActiveControl(DevExpress.XtraEditors.XtraForm frm,ref Control LastControl)
  //      {

  //          Control CurrentControl= FormFunctions.GetActiveControl(frm);

  //          try
  //          {
  //              Application.DoEvents();


  //              if (CurrentControl.Name != LastControl.Name)
  //              {
  //                  LastControl.BackColor = Color.White;
  //              }
  //              Application.DoEvents();

  //              LastControl = CurrentControl;
  //              CurrentControl.BackColor = Color.GreenYellow;
  //              Application.DoEvents();
  //          }
  //          catch
  //          {
		//		return;
  //          }
  //      }
  //  }
}
