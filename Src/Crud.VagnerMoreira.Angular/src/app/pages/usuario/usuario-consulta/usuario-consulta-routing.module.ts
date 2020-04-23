import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { usuarioConsultaComponent } from './usuario-consulta.component';

const routes: Routes = [{
  path: '',
  component: usuarioConsultaComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class usuarioConsultaRoutingModule { }
