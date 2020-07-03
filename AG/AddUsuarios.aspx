<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUsuarios.aspx.cs" Inherits="AG.AddUsuarios" %>

<%@ Register Assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">

  
  <link rel="stylesheet" href="../../plugins/select2/css/select2.min.css">
  <link rel="stylesheet" href="../../plugins/select2-bootstrap4-theme/select2-bootstrap4.min.css">
  

 <div class="wrapper">
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0 text-dark">Cadastro de Usuários</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">home</a></li>
              <li class="breadcrumb-item active">Cadastro de Usuários</li>
            </ol>
          </div><!-- /.col -->
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
    <!-- /.content-header -->
    <!-- Main content -->
        <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <!-- SELECT2 EXAMPLE -->
        <div class="card card-default">
          <div class="card-header">
            <h3 class="card-title"><i class="fas fa-user"></i></h3>
            <div class="card-tools">
              <asp:Button Text="Salvar" CssClass="btn btn-sm btn-info" runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" />
              <asp:Button Text="Voltar" CssClass="btn btn-sm btn-secondary" runat="server" ID="btnVoltar" OnClick="btnVoltar_Click" OnClientClick="voltarPagina();"/>
              <button type="button" class="btn btn-tool" data-card-widget="maximize"><i class="fas fa-expand"></i></button>
              <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
              <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-remove"></i></button>
            </div>
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                  <div class="col">
                    <div class="form-group">
                      <label>Nome</label>
                        <asp:TextBox runat="server" ID="nome" CssClass="form-control"  />
                    </div>
                  </div>
                <!-- /.form-group -->
                <div class="col">
                    <div class="form-group">
                      <label>E-Mail</label>
                        <asp:TextBox runat="server" ID="email" CssClass="form-control"  />
                    </div>
                </div>
               <div class="col">
                    <div class="form-group">
                      <label>Login</label>
                        <asp:TextBox runat="server" ID="login" CssClass="form-control"  />
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                      <label>Senha</label>
                        <asp:TextBox runat="server" ID="senha" CssClass="form-control" type="password" />
                    </div>
                </div>
                <!-- /.form-group -->
            </div>
              <div class="row">
                <div class="col">
                <div class="form-group">
                  <label>Perfil</label>
                    <asp:DropDownList runat="server" ID="cboxPerfil" CssClass="form-control" >
                        <asp:ListItem Text="Operador"  Value="Operador"/>
                        <asp:ListItem Text="Administrador" Value="Administrador" />
                        <asp:ListItem Text="Supervisor" Value="Supervisor" />
                    </asp:DropDownList>
                </div>
                </div>
                  <div class="col">
                    <div class="form-group">
                      <label>Projeto</label>
                        <asp:DropDownList runat="server" ID="cboxProjeto"  CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="nome" DataValueField="id" >
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:agConnectionString %>" ProviderName="<%$ ConnectionStrings:agConnectionString.ProviderName %>" SelectCommand="SELECT id, nome FROM projeto"></asp:SqlDataSource>
                    </div>
                </div>
                  <div class="col">
                    <div class="form-group">
                      <label>Cargo</label>
                        <asp:TextBox runat="server" ID="cargo" CssClass="form-control"   />
                    </div>
                </div>
            </div>
                  <div class="col">
                    <div class="form-group">
                        <asp:Label Text="" runat="server" ID="lblCaminhoImg" />
                        <asp:Image runat="server" ID="imgSel" Width="160px" Height="160px" />
                        <asp:FileUpload runat="server" ID="img" ToolTip="Selecione uma Imagem" CssClass="btn btn-secondary" /><br />
                        <asp:Button runat="server" ID="btnUpload" type="submit" Text="Upload" class="btn btn-primary" OnClick="btnUpload_Click" />
                        <asp:Label runat="server" id="StatusLabel" text="" ForeColor="Red" />
                    </div>
                </div>
            </div>
        </div>
      </div>
    </section>
      
        </div>
  </div>

<!-- Select2 -->
<script src="../../plugins/select2/js/select2.full.min.js"></script>

<script>
  $(function () {
    //Initialize Select2 Elements
    $('.select2').select2()

    //Initialize Select2 Elements
    $('.select2bs4').select2({
      theme: 'bootstrap4'
    })
  })
</script>
    <script type="text/javascript">
        function sucesso() {
            toastr.success('Gravado com Sucesso!!!')        
        };
        function uploadSucesso() {
            toastr.success('Upload da Imagem feito com Sucesso!!!')        
      };
    </script>
    <script type="text/javascript">
        function erro() {
            toastr.error('Erro ao Gravar!!!')        
        };
        function uploadErro() {
            toastr.error('Erro ao fazer Upload da Imagem!!!')        
      };
    </script>

    <script>
    $('[data-mask]').inputmask()
    </script>

    <script type="text/javascript">
        function NotificacaoErro() {
            toastr.options = {
              "closeButton": false,
              "debug": false,
              "newestOnTop": true,
              "progressBar": true,
              "positionClass": "toast-top-full-width",
              "preventDuplicates": true,
              "onclick": null,
              "showDuration": "300",
              "hideDuration": "1000",
              "timeOut": "8000",
              "extendedTimeOut": "1000",
              "showEasing": "swing",
              "hideEasing": "linear",
              "showMethod": "fadeIn",
              "hideMethod": "fadeOut"
            }
            toastr["error"]("<%= mensagem %> ", "Erro")
      };
    </script>
    <script type="text/javascript">
        function acessoNegado() {
            toastr.options = {
              "closeButton": false,
              "debug": false,
              "newestOnTop": true,
              "progressBar": true,
              "positionClass": "toast-top-full-width",
              "preventDuplicates": true,
              "onclick": null,
              "showDuration": "300",
              "hideDuration": "1000",
              "timeOut": "8000",
              "extendedTimeOut": "1000",
              "showEasing": "swing",
              "hideEasing": "linear",
              "showMethod": "fadeIn",
              "hideMethod": "fadeOut"
            }
            toastr["info"]("Acesso restrito a usuarios Administradores. ", "Erro")
        };
    </script>
    <script type="text/javascript">
function voltarPagina()
{
    history.go(-1);
}
</script>

    

</asp:Content>
