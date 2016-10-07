<%@ Page Language="vb" AutoEventWireup="true" CodeFile="ShoppingCartTest.aspx.vb" Inherits="ShoppingCartTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
	<P>
				<asp:Label id="Label2" runat="server" Font-Names="Verdana" Font-Bold="True">Shopping Cart:</asp:Label></P>
			<asp:GridView id="gridCart" runat="server" AutoGenerateColumns="False" GridLines="Vertical" BorderColor="#CC9966"
				BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" Font-Names="Verdana"
				Font-Size="XX-Small"  OnSelectedIndexChanged="gridCart_SelectedIndexChanged">
				
				<SelectedRowStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedRowStyle>
				<RowStyle ForeColor="#330099" BorderStyle="None" BorderColor="White" BackColor="White"></RowStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle Height="2px" ForeColor="#330099" BackColor="Bisque"></FooterStyle>
				<Columns>
				
					<asp:BoundField DataField="ProductID" HeaderText="ID"></asp:BoundField>
					<asp:BoundField DataField="ProductName" HeaderText="Product Name"></asp:BoundField>
					<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}"></asp:BoundField>
					<asp:TemplateField HeaderText="Units">
						<HeaderStyle Width="5px"></HeaderStyle>
						<ItemTemplate>
							<asp:TextBox ID="TextBox1" runat="server" Font-Size="XX-Small" Width="31px" Text='<%#DataBinder.Eval(Container, "DataItem.Units")%>'>
							</asp:TextBox>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}"></asp:BoundField>
					<asp:CommandField ShowSelectButton="True" SelectText="Update" />
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:GridView>
			<P>
				<asp:Label id="Label1" runat="server" Font-Names="Verdana" Font-Bold="True">Product List:</asp:Label></P>
			<asp:GridView id="gridProducts" runat="server" Font-Size="XX-Small" Font-Names="Verdana" CellPadding="4"
				BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" DataKeyField="ProductID"
				GridLines="Vertical" AutoGenerateColumns="False" OnSelectedIndexChanged="gridProducts_SelectedIndexChanged" DataKeyNames="ProductID">
				<SelectedRowStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedRowStyle>
				<RowStyle ForeColor="#330099" BorderStyle="None" BorderColor="White" BackColor="White"></RowStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle Height="2px" ForeColor="#330099" BackColor="Bisque"></FooterStyle>
				<Columns>
					<asp:BoundField DataField="ProductID" HeaderText="ID"></asp:BoundField>
					<asp:BoundField DataField="ProductName" HeaderText="Product Name"></asp:BoundField>
					<asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}"></asp:BoundField>
					<asp:CommandField ShowSelectButton="True" SelectText="Add..." />
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:GridView>
	</div>
	</form>
</body>
</html>
