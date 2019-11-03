<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VandyHacksWebApp._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
    
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-4">
                <div class="text-center">
                    <asp:Image ImageAlign="Middle" Height="250" Width="350" ID="LeftPicture" AlternateText="" runat="server" />
                </div>
            </div>
        
            <div class="col-md-4">
                <div class="text-center">
                    <asp:Label runat="server" ID="PlaceholderLbl" Text="Nothing to show yet! Please scan your hand to see the glove that will fit you!" ></asp:Label>
                    <asp:Image ImageAlign="Middle" Height="250" Width="350" ID="CenterPicture" AlternateText="" runat="server" />
                </div>
            </div>
            <div class="col-md-4" style="vertical-align:middle">
                    
                <div class="jumbotron" style="background-color:gray" runat="server" id="superJumbo">
                    <div class="text-center" style="height: 52px; vertical-align:middle">
                        <div style="vertical-align:middle">
                            <asp:Label runat="server" ID="gloveLabel" Font-Bold="true" Font-Size="XX-Large" Text="X-Large" ></asp:Label>
                        </div>                    
                    </div>
                </div>
            </div>
        </div>

        
        
        
        
        <div class="row">
            <div class="col-md-4">
                <div class="text-center">
                    <asp:Label ID="picLbl1" runat="server" Text="Inital Picture"></asp:Label>
                </div>
            </div>
        
            <div class="col-md-4">
                <div class="text-center">
                    <asp:Label ID="picLbl2" runat="server" Text="Key Points"></asp:Label>
                </div>
            </div>
        
            <div class="col-md-4">
                <div class="text-center">
                </div>
            </div>
        </div>
    </div>
        <div class="row">
            <div class="col-md-5">
                <div class="text-center">
                    <asp:Button runat="server" ID="chooseGloveTypeBtn" OnClick="chooseGloveTypeBtn_Click" CssClass="btn btn-pill" />
                </div>
            </div>
            <div class="col-md-2">
                <div class="text-center">
                    <asp:Button runat="server" Text="Scan!" CssClass="btn btn-pill" BackColor="Lime" ID="ScanBtn" OnClick="ScanBtn_Click" Font-Bold="True" ForeColor="Black" Font-Size="Medium" />
                </div>
            </div>
            <div class="col-md-5">
                <div class="text-center">
                    <asp:Label runat="server" ID="sizeLabel"></asp:Label> 
                </div>
            </div>
        </div>
        <div class="mt-2"></div>
        <div class="mt-2"></div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <div class="text-center">
                    <asp:Label runat="server" ID="InstructionsLbl" Text="Place your hand in the middle of the platform with your fingers spread apart. Keep your hand held against the bottom and press the scan button. Hold your hand still until the pictures generate, this shouldn't take more than a few seconds."></asp:Label> 
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
</asp:Content>
