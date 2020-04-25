<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="NAAC.aspx.cs" Inherits="LTPL.ICAS.WebApplication.NAAC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="innercontent">
        <h1 class="PageTitle">National Assessment and Accreditation Council (NAAC)</h1>
        <div class="row m-0 p-0">
            <div class="col-lg-3 col-sm-12">
                <a href="http://tsdcollege.in/Documents/ESTB_R_Y2020_M3_D22-H6_M51_S2.pdf" target="_blank">
                   <img src="./images/naac_certificate.jpg" alt="NAAC CERTIFICATE" class="img img-responsive img-thumbnail" style="height:250px; margin-top: 5px" />
                </a>
            </div>
            <div class="col-lg-9 col-sm-12">
                <div class="row mt-2 mb-2 p-2">
                    <div class="col-12" style="margin: 2px 0px 0px 4px">
                        <span class="PageSubtitle"><b>Downloadables:</b></span>
                    </div>
                </div>
                <asp:Literal runat="server" ID="lit_Content" Text="~" />
            </div>
        </div>        
    </div>

</asp:Content>
