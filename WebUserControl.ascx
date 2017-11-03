<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>

<div class="row">
<div class="col-lg-4">
<div class="form-horizontal">

    <div class="form-group">
      <label class="col-lg-5 control-label">product Name</label>
        <div class="col-lg-7">
            <input id="TextProdName" type="text" runat="server" class="form-control"/>
        </div>
    </div>

     <div class="form-group">
      <label class="col-lg-5 control-label">Product Description</label>
        <div class="col-lg-7">
            <textarea id="TextProdDesc" runat="server" class="form-control"></textarea>
        </div>
    </div>

     <div class="form-group">
      <label class="col-lg-5 control-label">Photo Upload</label>
        <div class="col-lg-7">
            <asp:FileUpload ID="FileUpload1" runat="server" ViewStateMode="Enabled"/>
        </div>
    </div>

     <div class="form-group">
      <label class="col-lg-5 control-label">File Uplaod</label>
        <div class="col-lg-7">
           <asp:FileUpload ID="FileUpload2" runat="server" ViewStateMode="Enabled"/>
        </div>
    </div>

    <div class="form-group">

        <div class="col-lg-7 col-lg-offset-5">
            <asp:Button ID="testbtn" runat="server" Text="Save" CssClass="btn btn-primary"/>

        </div>
        
    </div>

</div>
    </div>
    </div>