import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { usuarioCadastroComponent } from './usuario-cadastro.component';

const routes: Routes = [{
  path: '',
  component: usuarioCadastroComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class usuarioCadastroRoutingModule { }
