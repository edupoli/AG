<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUsuarios.aspx.cs" Inherits="AG.ViewUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="wrapper">
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0 text-dark">Visualizar Cadastro de Usuários</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">home</a></li>
              <li class="breadcrumb-item active">Visualizar Cadastro de Usuários</li>
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
              <asp:Button Text="Voltar" CssClass="btn btn-sm btn-secondary" runat="server" ID="btnVoltar" OnClick="btnVoltar_Click"/>
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
                        <asp:TextBox runat="server" ID="nome" CssClass="form-control" ReadOnly="true" />
                    </div>
                  </div>
                <!-- /.form-group -->
                <div class="col">
                    <div class="form-group">
                      <label>E-Mail</label>
                        <asp:TextBox runat="server" ID="email" CssClass="form-control" ReadOnly="true" />
                    </div>
                </div>
               <div class="col">
                    <div class="form-group">
                      <label>Login</label>
                        <asp:TextBox runat="server" ID="login" CssClass="form-control" ReadOnly="true" />
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                      <label>Senha</label>
                        <asp:TextBox runat="server" ID="senha" CssClass="form-control" type="password" ReadOnly="true" />
                    </div>
                </div>
                <!-- /.form-group -->
            </div>
              <div class="row">
                <div class="col">
                <div class="form-group">
                  <label>Perfil</label>
                    <asp:DropDownList runat="server" ID="cboxPerfil" CssClass="form-control" readonly="true">
                        <asp:ListItem Text="Comum"  Value="comum"/>
                        <asp:ListItem Text="Administrador" Value="administrador" />
                        <asp:ListItem Text="Supervisor" Value="supervisor" />
                    </asp:DropDownList>
                </div>
                </div>
                <div class="col">
                    <div class="form-group">
                      <label>Projeto</label>
                        <asp:DropDownList runat="server" ID="cboxProjeto" CssClass="form-control" ReadOnly="true" >
                        </asp:DropDownList>
                    </div>
                </div>
                  <div class="col">
                    <div class="form-group">
                      <label>Cargo</label>
                        <asp:TextBox runat="server" ID="cargo" CssClass="form-control" ReadOnly="true"  />
                    </div>
                </div>
            </div>
                  <div class="col">
                    <div class="form-group">
                        <asp:Image runat="server" ID="imgSel" Width="160px" Height="160px" />
                    </div>
                </div>
            </div>
    </div>
      </div>
    </section>
      
        </div>
  </div>
    <script type="text/javascript">
        function sucesso() {
            toastr.success('Gravado com Sucesso!!!')        
      };
    </script>
    <script type="text/javascript">
        function erro() {
            toastr.error('Erro ao Gravar!!!')        
      };
    </script>

    <script>
    $('[data-mask]').inputmask()
    </script>
</asp:Content>
