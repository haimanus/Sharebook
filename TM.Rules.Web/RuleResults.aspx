<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RuleResults.aspx.cs" Inherits="TM.Rules.Web.RuleResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    The results for the rule execution is available below.<br />
    <br />
    <table cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4"  ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RuleID" HeaderText="RuleID" 
                SortExpression="RuleID" />
            <asp:BoundField DataField="Symbol" HeaderText="Symbol" 
                SortExpression="Symbol" />
            <asp:BoundField DataField="Action" HeaderText="Action" 
                SortExpression="Action" />
            <asp:BoundField DataField="BidPrice" HeaderText="BidPrice" 
                SortExpression="BidPrice" />
            <asp:BoundField DataField="AskPrice" HeaderText="AskPrice" 
                SortExpression="AskPrice" />
            <asp:BoundField DataField="StrikePrice" HeaderText="StrikePrice" 
                SortExpression="StrikePrice" />
            <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" 
                SortExpression="ExpirationDate" />
            <asp:BoundField DataField="LastPrice" HeaderText="LastPrice" 
                SortExpression="LastPrice" />
            <asp:BoundField DataField="Volume" HeaderText="Volume" 
                SortExpression="Volume" />
            <asp:BoundField DataField="OpenInterest" HeaderText="OpenInterest" 
                SortExpression="OpenInterest" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
            </td>
        </tr>
        <tr><td><br /></td></tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        CellPadding="4"  ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RuleID" HeaderText="RuleID" 
                SortExpression="RuleID" />
            <asp:BoundField DataField="Symbol" HeaderText="Symbol" 
                SortExpression="Symbol" />
            <asp:BoundField DataField="Action" HeaderText="Action" 
                SortExpression="Action" />
            <asp:BoundField DataField="StrikePrice" HeaderText="StrikePrice" 
                SortExpression="StrikePrice" />
            <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" 
                SortExpression="ExpirationDate" />
            <asp:BoundField DataField="LastPrice" HeaderText="LastPrice" 
                SortExpression="LastPrice" />
            <asp:BoundField DataField="IV" HeaderText="IV" SortExpression="IV" />
            <asp:BoundField DataField="Delta" HeaderText="Delta" SortExpression="Delta" />
            <asp:BoundField DataField="Vega" HeaderText="Vega" SortExpression="Vega" />
            <asp:BoundField DataField="Gamma" HeaderText="Gamma" SortExpression="Gamma" />
            <asp:BoundField DataField="Theta" HeaderText="Theta" SortExpression="Theta" />
            <asp:BoundField DataField="Rho" HeaderText="Rho" SortExpression="Rho" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
