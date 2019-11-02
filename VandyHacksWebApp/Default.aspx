<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VandyHacksWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <div class="jumbotron">
                <asp:Image ID="LeftPicture" AlternateText="Image Not Available" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="jumbotron">
                <asp:Image ID="CenterPicture" AlternateText="Image Not Available" runat="server" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="jumbotron">
                <asp:Image ID="RightPicture" AlternateText="Image Not Available" runat="server" />
            </div>
        </div>
    </div>
    <asp:Button runat="server" Text="Scan!" ID="ScanBtn" OnClick="ScanBtn_Click" />
</asp:Content>
