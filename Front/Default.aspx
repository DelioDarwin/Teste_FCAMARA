<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Front.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teste FCAMARA</title>
      <link rel="stylesheet" media="screen" href="css/vendor.min.css" />
      <link rel="stylesheet" media="screen" href="css/theme.min.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
        <nav aria-label="breadcrumb">
          <ol class="breadcrumb">
            <li class="mt-n1 mr-1"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-home"><path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z"></path><polyline points="9 22 9 12 15 12 15 22"></polyline></svg></li>
            <li class="breadcrumb-item"><span>Home</span>
            </li>
            <li class="breadcrumb-item"><span>Lista de Integrações</span>
            </li>
          </ol>
        </nav>
        <h1 class="page-title">Teste FCAMARA</h1><span class="d-block mt-2 text-muted"></span>
        <hr class="mt-4">
      </div>

     <div class="container pb-5 mb-4">
      <div class="row justify-content-center">
        <div class="col-lg-9">
          <!-- Post-->
          <div class="row pb-2">
            <div class="col-12"> 
              <h3 class="h4 mb-4">
                  <span class="post-title">Aplicação Interna</span></h3>
            </div>
            <div class="col-12">
                 <div class="table-responsive">                 
                 <asp:GridView CssClass="table" ID="grvAplicacaoInterna" runat="server" AutoGenerateColumns="false">
                     <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                    </Columns>
                 </asp:GridView>
                </div>
            </div>
          </div>
          <hr class="pb-5">

          <div class="row pb-2">
            <div class="col-12"> 
              <h3 class="h4 mb-4">
                  <span class="post-title">Aplicacao Externa 1</span></h3>
            </div>
            <div class="col-12">
                 <div class="table-responsive">                 
                 <asp:GridView CssClass="table" ID="grvAplicacoExterna1" runat="server"  AutoGenerateColumns="false">
                     <Columns>
                         <asp:BoundField DataField="Nome" HeaderText="Nome" />
                         <asp:BoundField DataField="Email" HeaderText="Email" />
                         <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                     </Columns>
                 </asp:GridView>
                </div>
            </div>
          </div>
          <hr class="pb-5">

          <div class="row pb-2">
           <div class="col-12"> 
             <h3 class="h4 mb-4"><span class="post-title">Aplicacao Externa 2</span></h3>
           </div>
           <div class="col-12">
                <div class="table-responsive">                 
                <asp:GridView CssClass="table" ID="grvAplicacoExterna2" runat="server"  AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                    </Columns>
                </asp:GridView>
               </div>
           </div>
         </div>
         <hr class="pb-5">


         <div class="row pb-2">
           <div class="col-12"> 
             <h3 class="h4 mb-4"><span class="post-title" style="color: darkred">Log de Erros</span></h3>
           </div>
           <div class="col-12">
                <div class="table-responsive">                 
                <asp:GridView CssClass="table" ID="grvLogErros" runat="server"  AutoGenerateColumns="false" BackColor="#ffeaea">
                    <Columns>
                        <asp:BoundField DataField="TipoErro" HeaderText="Tipo do Erro" />
                        <asp:BoundField DataField="Dados" HeaderText="Dados" />
                    </Columns>
                </asp:GridView>
               </div>
           </div>
         </div>
         <hr class="pb-5">
        
        </div>
      </div>
    </div>

    </form>
</body>
</html>
