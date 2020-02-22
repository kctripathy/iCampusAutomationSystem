<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/ICAS.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TCon.iCAS.WebApplication.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">
        #report_div {
            width: 100%;
        }

        #RPT_UL {
            margin: 0px;
            padding: 10px;
            height: 100%;
            width: 100%;
            list-style-type: none;
        }

            #RPT_UL li {
                display: block;
                float: left;
            }

        .MainPartition {
            overflow: hidden;
            margin-top: 10px;
            width: 49%;
        }

        #RPT_UL li.MainPartition ul {
            border: solid 1px #808080;
            margin: 0px;
            padding: 10px;
            height: 100%;
            width: 95%;
            min-height: 277px;
            list-style-type: none;
        }

            #RPT_UL li.MainPartition ul li.FiftyFifty {
                display: block;
                float: left;
                width: 49%;
                text-align: center;
                /*background-image: url('./images/report.png');*/
                background-position: left;
                background-repeat: no-repeat;
                cursor: none;
                /*margin: 5px 0px;*/
            }

                #RPT_UL li.MainPartition ul li.FiftyFifty input {
                    width: 70%;
                    padding: 5px;
                    cursor: pointer;
                }
    </style>



    <div id="report_div">
        <ul id="RPT_UL">
            <li class="MainPartition">
                

                <ul>
                    <li style="width: 100%; margin-bottom: 10px;">
                        <h3>Students Report:</h3>
                        Session::
                        <asp:DropDownList runat="server" ID="ddlSession">
                            <asp:ListItem Text="2017 - 2018" Value="38"></asp:ListItem>
                        </asp:DropDownList>
                    </li>

                    <li class="FiftyFifty">
                        <asp:Button Text="(+2) Students" OnClick="ExportExcelReport" runat="server" CommandName="2" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="(+3) Students" OnClick="ExportExcelReport" runat="server" CommandName="3" />
                    </li>

                    <%--<li class="FiftyFifty" style="margin-bottom: 30px; background-image: none;">
                        &nbsp;
                    </li>
                    <li class="FiftyFifty" style="margin-bottom: 30px; background-image: none;">
                         &nbsp;
                    </li>--%>
                    <li class="FiftyFifty">
                        <asp:Button Text="(+2) Students Feedback" OnClick="ExportExcelReport" runat="server" CommandName="0" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="(+3) Students Feedback" OnClick="ExportExcelReport" runat="server" CommandName="0" />
                    </li>

                    <%--<li class="FiftyFifty" style="margin-bottom: 30px; background-image: none;">
                        &nbsp;
                    </li>
                    <li class="FiftyFifty" style="margin-bottom: 30px; background-image: none;">
                         &nbsp;
                    </li>--%>

                    <li class="FiftyFifty">
                        <asp:Button Text="(+2) Subjects" OnClick="ExportExcelReport" runat="server" CommandName="41" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="(+3) Subjects" OnClick="ExportExcelReport" runat="server" CommandName="42" />
                    </li>


                </ul>
            </li>
            <li class="MainPartition">
                 
                <ul>
                    <li style="width: 100%; margin: 10px 0px 10px 0px;">
                        <h3>Staff Report:</h3>
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Staff Master File" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Staff Pay Components" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Student Attendance" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Student Marks" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Student Examination" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Student Exam Schedules" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                    <li style="width: 100%; margin: 30px 0px 0px 0px;">
                        <h3>Establishment Report:</h3>
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Notice, Circular, Tenders" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                    <li class="FiftyFifty">
                        <asp:Button Text="Recent Activities" OnClick="ExportExcelReport" runat="server" CommandName="4" />
                    </li>
                </ul>
            </li>
        </ul>


    </div>
    <div class ="innercontent">
        Display:<br />
        <asp:GridView ID="GridViewReport" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
z</div>
</asp:Content>
