import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'usuario-consulta',
    loadChildren: () => import('./pages/usuario/usuario-consulta/usuario-consulta.module').then(m => m.UsuarioConsultaModule)
  },
  {
    path: 'usuario-cadastro',
    loadChildren: () => import('./pages/usuario/usuario-cadastro/usuario-cadastro.module').then(m => m.UsuarioCadastroModule)
  },
  {
    path: 'usuario-cadastro/:id',
    loadChildren: () => import('./pages/usuario/usuario-cadastro/usuario-cadastro.module').then(m => m.UsuarioCadastroModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
