<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projetos.aspx.cs" Inherits="AG.Projetos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
    <div class="wrapper">
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid">
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0 text-dark">Projetos</h1>
          </div><!-- /.col -->
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
              <li class="breadcrumb-item"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Grupo de Usuários</li>
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
              <h3 class="card-title">Projetos</h3>
            </div>
            <!-- /.card-header -->
              <div class="card-body">
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" emptydatatext="Não existem dados Cadastrados!!" class="table table-bordered table-hover">
              <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="nome" HeaderText="Nome" />
            
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:LinkButton class="btn badge-secondary" Text="" data-toggle="tooltip" title="Visualizar" data-placement="auto" ID="btnVisualizar" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="btnVisualizar_Click" ><i class="far fa-eye"></i></asp:LinkButton>
                    <asp:LinkButton class="btn badge-info" Text="" data-toggle="tooltip" title="Editar" data-placement="auto" ID="btnEditar" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="btnEditar_Click" ><i class="fas fa-edit"></i></asp:LinkButton>
                    <asp:LinkButton class="btn badge-danger" Text="" data-toggle="tooltip" title="Excluir" data-placement="auto" ID="btnExcluir" runat="server" CommandArgument='<%# Eval("id") %>' OnClick="btnExcluir_Click" OnClientClick="return confirm('Tem Certeza que deseja Excluir ?')" ><i class="fas fa-trash"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
          </asp:GridView>
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
      function sucesso() {
        toastr.success('Deletado com Sucesso!!!')        
      };
  </script>
    <script type="text/javascript">
        function erro() {
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
            toastr["error"]("Não é possível deletar esse registro, pois esta sendo utilizado no cadastro de um ou mais Usuarios. ", "Erro")
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
            toastr["info"]("Acesso somente a usuarios Administradores. ", "Erro")
      };
    </script>
</asp:Content>
