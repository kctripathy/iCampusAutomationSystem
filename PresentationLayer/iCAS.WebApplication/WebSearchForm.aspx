<%@ Page Language="C#"
    MasterPageFile="~/App_MasterPages/ICAS.Master"
    AutoEventWireup="true"
    CodeBehind="WebSearchForm.aspx.cs"
    Inherits="LTPL.ICAS.WebApplication.WebSearchForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <script>
            (function () {
                var cx = '015694938326608284122:iir1dnvwsju';
                var gcse = document.createElement('script');
                gcse.type = 'text/javascript';
                gcse.async = true;
                gcse.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') +
                    '//cse.google.com/cse.js?cx=' + cx;
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(gcse, s);
            })();
        </script>
        <gcse:search></gcse:search>

    </div>

</asp:Content>
