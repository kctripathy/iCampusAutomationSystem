<%@ Page Title="" Language="C#" MasterPageFile="~/App_MasterPages/MicroERP-MasterPage.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="TCon.iCAS.WebApplication.Apps.Admin.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMicroERP" runat="server">
    <style type="text/css">
        .item-style {
            padding: 20px;
        }
        .drop-down {
            width: 100%;
            padding: 5px;
            font-size: 1.1em;
        }
    </style>
    <asp:UpdatePanel ID="updatePanel_ErrorLog" runat="server">
        <ContentTemplate>
        <h1 class="PageTitle">User Feedback:</h1>
            <ul id="ErrorLog">
           
                <li>
                    Choose a feedback category: <br />
                    <asp:DropDownList ID="ddl_Category" runat="server" OnSelectedIndexChanged="ddl_Category_SelectedIndexChanged" AutoPostBack="true" CssClass="drop-down" />
                </li >
                
                <li class="GridView">
                    <asp:GridView runat="server" 
                        ID="gview_Feedbacks"
                        AutoGenerateColumns="false" 
                        GridLines="Both" 
                        Width="99%">
                        <HeaderStyle CssClass="HeaderStyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="Feedback" ItemStyle-CssClass="item-style">
                                <ItemTemplate>
                                        Feedback for: <b><asp:Label runat="server" ID="Label7" Text='<%# Eval("category_desc") %>' /> </b>
                                       <br />Date: <asp:Label runat="server" ID="Label6" Text='<%# Eval("feedback_date") %>' /> 
                                       <br />Name: <asp:Label runat="server" ID="Label2" Text='<%# Eval("name") %>' /> 
                                        (<asp:Literal runat="server" ID="Label4" Text='<%# Eval("feedback_by") %>' />)
                                      <br />Email: <asp:Label runat="server" ID="Label3" Text='<%# Eval("email") %>' />
                                      <br />Phone: <asp:Label runat="server" ID="Label1" Text='<%# Eval("phone") %>' />
                                      <br />Desc: <asp:Label runat="server" ID="Label5" Text='<%# Eval("description") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </li>
            </ul>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
