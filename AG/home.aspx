<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AG._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="wrapper">
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0 text-dark">AGs disponíveis para o Projeto <%= nomeProjeto %> </h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Inicial</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
          
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->
    <!-- Main content -->
    

    <section class="content">
      <div class="row">
        <div class="col-12">
          <div class="card">
            <div class="card-header">
              <h3 class="card-title">Relação de AGs</h3>
            </div>
              <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="10000"></asp:Timer>
            <!-- /.card-header -->
              <div class="card-body">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                      <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" />
                      </Triggers>
                      <ContentTemplate>
                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" emptydatatext="Não existem AGs disponíveis!!" class="table table-bordered table-hover">
                          <Columns>
                            <asp:BoundField DataField="numero" HeaderText="Numero" ControlStyle-Font-Bold="true" />
                            <asp:BoundField DataField="nome" HeaderText="Projeto" ControlStyle-Font-Bold="true" />
                         </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- /.card-body -->

          </div>
          <!-- /.card -->

        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>

    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->
        
</div>
  <script type="text/javascript">
      $(function () {
      $('[data-toggle="tooltip"]').tooltip()
    })
  </script>   
    <!--
    <script>
            $(document).ready(function () {
            $('#<%= GridView1.ClientID%>').prepend($("<thead></thead>").append($("#<%= GridView1.ClientID%>").find("tr:first"))).DataTable({
                "bJQueryUI": true,
                "autoWidth": true,
                 
                "oLanguage": {
                    "sProcessing":   "Processando...",
                    "sLengthMenu":   "Mostrar _MENU_ registros",
                    "sZeroRecords":  "Não foram encontrados resultados",
                    "sInfo":         "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                    "sInfoEmpty":    "Mostrando de 0 até 0 de 0 registros",
                    "sInfoFiltered": "",
                    "sInfoPostFix":  "",
                    "sSearch":       "Pesquisar:",
                    "sUrl":          "",
                    "oPaginate": {
                        "sFirst":    "Primeiro",
                        "sPrevious": "Anterior",
                        "sNext":     "Seguinte",
                        "sLast":     "Último"
                    }
                }
            }) 
            });
    </script>
    -->
    <style>
        th{text-align:center;}
        td{text-align:center;}
        
    </style>
</asp:Content>
