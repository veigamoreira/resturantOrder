import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/usuario/usuario-cadastro/usuario-cadastro.module').then(m => m.UsuarioCadastroModule)
  },
 
  {
    path: 'usuario-cadastro',
    loadChildren: () => import('./pages/usuario/usuario-cadastro/usuario-cadastro.module').then(m => m.UsuarioCadastroModule)
  },
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
