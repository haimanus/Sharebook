<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefineRules.aspx.cs" Inherits="TM.Rules.Web.DefineRules" %>
<%@ Register assembly="CodeEffects.Rule" namespace="CodeEffects.Rule.Asp" tagprefix="rule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h2>
        Welcome to RULE DESIGNER !
    </h2>
    <table align="left" cellpadding="0" cellspacing="0" >
        <tr>
            <td colspan="2">
                <br />
                <span style="color: rgb(68, 68, 68); font-family: Tahoma, Geneva, Arial, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: justify; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(232, 242, 252); display: inline !important; float: none; ">
                With Rule Designer, business users can write complex rules simply by selecting 
                rule elements from the context-sensitive menu<br />
                <span>The rule editor below is pre-loaded<span class="Apple-converted-space">&nbsp;with 
                most of the parameter related to a stock or an option.</span></span><br />
                <br />
                </span>
                <br />
    <asp:GridView ID="grdRules" runat="server"  DataKeyNames="RuleID" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"  OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="RuleID" HeaderText="RuleID"                  SortExpression="RuleID" />
            <asp:BoundField DataField="RuleName" HeaderText="RuleName"                  SortExpression="RuleName" />
            <asp:BoundField DataField="RuleType" HeaderText="RuleType"                 SortExpression="RuleType" />
            <asp:BoundField DataField="RuleText" HeaderText="RuleText"                  SortExpression="RuleText" />
            <asp:BoundField DataField="RuleDescription" HeaderText="RuleDescription"                 SortExpression="RuleDescription" />
            <asp:BoundField DataField="ExecutionOrder" HeaderText="ExecutionOrder"                 SortExpression="ExecutionOrder" />                
            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />

           <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("RuleID") %>' CommandName="Delete" runat="server" CausesValidation="false">Delete</asp:LinkButton>
                    </ItemTemplate>
            </asp:TemplateField>
              
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
        <tr>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" 
                style="text-align: left; font-weight: 700; color: #FFFFFF;" 
                bgcolor="#516B92">
                <span class="style1">Add a new Rule</span><br />
            </td>
        </tr>
        <tr>
            <td colspan="2" 
               >

        	    <br />

        	Please define your rule in rule editor below
                <br />
                <br />
                Create rule for :
            <asp:DropDownList ID="ddlEntity" runat="server" 
                >
            </asp:DropDownList>
            &nbsp;<asp:Button ID="btnShowEnt" runat="server" Text="Apply" 
                onclick="btnShowEnt_Click" CausesValidation="False" 
                    UseSubmitBehavior="False" BackColor="#5D7B9D" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Bold="True" ForeColor="White" Width="87px" />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2" 
                >
                <rule:RuleEditor ID="ruleTestControl" runat="server" SourceAssembly="TM.Objects" SourceType="TM.Objects.TMStockEnt"  Mode="Execution"  ShowToolBar = "false"/>
    
                <br />
            </td>
        </tr>
        <tr>
            <td>
                Rule Name:</td>
            <td >
                <asp:TextBox ID="txtRuleName" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtRuleName" ErrorMessage="This is mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Rule Type:</td>
            <td >
                <asp:Label ID="lblRuleType" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Description (if any):</td>
            <td >
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="5000" Height="54px" 
                    TextMode="MultiLine" Width="186px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtDescription" ErrorMessage="This is mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Execution Order:</td>
            <td >
                <asp:TextBox ID="txtExecOrder" runat="server" Rows="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtExecOrder" ErrorMessage="This is mandatory"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ControlToValidate="txtExecOrder" ErrorMessage="Please enter a numeric value" 
                    MaximumValue="1000" MinimumValue="0" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                </td>
            <td >
    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                    Text="Add to the Rule List" BackColor="#6D8AAA" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Bold="True" ForeColor="White" Width="128px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
