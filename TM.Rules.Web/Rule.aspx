<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Rule.aspx.cs" Inherits="TM.Rules.Web._Default" %>
<%@ Register assembly="CodeEffects.Rule" namespace="CodeEffects.Rule.Asp" tagprefix="rule" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to RULE ENGINE !
    </h2>
    
    <br />
    Rule engine is a tool to define rule and execute stock options based on that 
    rule.<br />
    <br />
    This is still under progress<br />
    <br />
    Watch this space later for more information or navigate to other menu items for 
    action !<br />
    <br />
    
    <br />
    <asp:Image ImageUrl="~/Images/HomeImage.png" runat="server" 
    ImageAlign="Middle" />
</asp:Content>
