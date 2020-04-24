import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { OrderService } from 'src/app/services/pages/order.service';
import { usuarioCadastroRoutingModule } from './usuario-cadastro-routing.module';
import { usuarioCadastroComponent} from './usuario-cadastro.component';

@NgModule({
  declarations: [
    usuarioCadastroComponent
  ],
  imports: [
    CommonModule,
    usuarioCadastroRoutingModule,
    ReactiveFormsModule,
    NgxMaskModule
  ],
  providers: [
    OrderService
  ],
  exports: [
    usuarioCadastroComponent
  ]
})
export class UsuarioCadastroModule { }
